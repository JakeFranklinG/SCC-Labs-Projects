using System.Net.NetworkInformation;
using System.Text;

namespace WebPinger
{
    class Program
    {
        // ─── Top 10 Favorite Websites ────────────────────────────────────────────
        private static readonly List<(string Name, string Host)> Websites = new()
        {
            ("Google",          "google.com"),
            ("YouTube",         "youtube.com"),
            ("GitHub",          "github.com"),
            ("Wikipedia",       "wikipedia.org"),
            ("Reddit",          "reddit.com"),
            ("Stack Overflow",  "stackoverflow.com"),
            ("Cloudflare",      "cloudflare.com"),
            ("Apple",           "apple.com"),
            ("Discord",         "discord.com"),
            ("OpenAI",          "openai.com"),
        };

        private const int PingCount = 5;    // pings per site
        private const int TimeoutMs = 3000; // 3-second timeout per ping
        private const string OutputFile = "PingResults.txt";

        // ─── Entry Point ──────────────────────────────────────────────────────────
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║           WebPinger — Network Ping Analyzer          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine($"  Pinging {Websites.Count} websites × {PingCount} packets each...\n");

            var allResults = new List<SiteResult>();

            foreach (var (name, host) in Websites)
            {
                Console.Write($"  Pinging {name,-18} ({host}) ... ");
                var result = await PingSiteAsync(name, host);
                allResults.Add(result);
                PrintSummaryLine(result);
            }

            Console.WriteLine();
            WriteReportFile(allResults);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ✔  Report saved → {Path.GetFullPath(OutputFile)}");
            Console.ResetColor();
            Console.WriteLine("\n  Press any key to exit.");
            Console.ReadKey();
        }

        // ─── Ping a Single Website ────────────────────────────────────────────────
        static async Task<SiteResult> PingSiteAsync(string name, string host)
        {
            var result = new SiteResult
            {
                Name = name,
                Host = host,
                Timestamp = DateTime.Now,
                PingReplies = new List<PingReply?>()
            };

            using var pingSender = new Ping();
            var options = new PingOptions { DontFragment = true };
            byte[] buffer = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz012345"); // 32-byte payload

            for (int i = 0; i < PingCount; i++)
            {
                try
                {
                    PingReply reply = await pingSender.SendPingAsync(host, TimeoutMs, buffer, options);
                    result.PingReplies.Add(reply);
                }
                catch
                {
                    result.PingReplies.Add(null); // unreachable / DNS fail
                }
                await Task.Delay(200); // short gap between pings
            }

            return result;
        }

        // ─── Console Summary Line ─────────────────────────────────────────────────
        static void PrintSummaryLine(SiteResult r)
        {
            long? avg = r.AverageRoundTrip;
            if (avg == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UNREACHABLE");
            }
            else
            {
                Console.ForegroundColor = avg < 100 ? ConsoleColor.Green :
                                          avg < 250 ? ConsoleColor.Yellow :
                                                      ConsoleColor.Red;
                Console.WriteLine($"avg {avg} ms  (min {r.MinRoundTrip} / max {r.MaxRoundTrip} ms)  loss {r.PacketLoss:F0}%");
            }
            Console.ResetColor();
        }

        // ─── Write Full Report File ───────────────────────────────────────────────
        static void WriteReportFile(List<SiteResult> results)
        {
            var sb = new StringBuilder();

            // ── Header ────────────────────────────────────────────────────────────
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine("   WebPinger — Detailed Network Ping Report");
            sb.AppendLine($"   Generated : {DateTime.Now:dddd, MMMM dd, yyyy  HH:mm:ss}");
            sb.AppendLine($"   Machine   : {Environment.MachineName}");
            sb.AppendLine($"   OS        : {System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
            sb.AppendLine($"   Pings/Site: {PingCount}   Timeout: {TimeoutMs} ms   Payload: 32 bytes");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine();

            // ── Per-site detail ───────────────────────────────────────────────────
            int siteNum = 0;
            foreach (var r in results)
            {
                siteNum++;
                sb.AppendLine($"┌─ Site #{siteNum:D2} ──────────────────────────────────────────────────────");
                sb.AppendLine($"│  Name     : {r.Name}");
                sb.AppendLine($"│  Host     : {r.Host}");
                sb.AppendLine($"│  Tested   : {r.Timestamp:HH:mm:ss}");
                sb.AppendLine("│");

                int seq = 0;
                foreach (var reply in r.PingReplies)
                {
                    seq++;
                    if (reply == null)
                    {
                        sb.AppendLine($"│  Ping #{seq}: Request failed / DNS error");
                    }
                    else if (reply.Status == IPStatus.Success)
                    {
                        sb.AppendLine($"│  Ping #{seq}: Reply from {reply.Address,-20} " +
                                      $"bytes={reply.Buffer.Length}  " +
                                      $"time={reply.RoundtripTime} ms  " +
                                      $"TTL={reply.Options?.Ttl ?? 0}");
                    }
                    else
                    {
                        sb.AppendLine($"│  Ping #{seq}: {reply.Status}");
                    }
                }

                sb.AppendLine("│");
                sb.AppendLine("│  ── Statistics ──────────────────────────────────");
                sb.AppendLine($"│  Packets Sent     : {PingCount}");
                sb.AppendLine($"│  Packets Received : {r.SuccessCount}");
                sb.AppendLine($"│  Packets Lost     : {PingCount - r.SuccessCount}");
                sb.AppendLine($"│  Packet Loss      : {r.PacketLoss:F1} %");

                if (r.AverageRoundTrip != null)
                {
                    sb.AppendLine($"│  Min RTT          : {r.MinRoundTrip} ms");
                    sb.AppendLine($"│  Max RTT          : {r.MaxRoundTrip} ms");
                    sb.AppendLine($"│  Avg RTT          : {r.AverageRoundTrip} ms");
                    sb.AppendLine($"│  Jitter (max-min) : {r.MaxRoundTrip - r.MinRoundTrip} ms");
                    sb.AppendLine($"│  Quality          : {r.QualityRating}");
                }
                else
                {
                    sb.AppendLine("│  Result           : HOST UNREACHABLE");
                }

                sb.AppendLine("└──────────────────────────────────────────────────────────────");
                sb.AppendLine();
            }

            // ── Summary Table ─────────────────────────────────────────────────────
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine("   SUMMARY TABLE");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine($"   {"#",-3} {"Website",-18} {"Host",-22} {"Avg(ms)",8} {"Min(ms)",8} {"Max(ms)",8} {"Loss%",7} {"Quality",-12}");
            sb.AppendLine("   " + new string('-', 90));

            int i = 0;
            foreach (var r in results)
            {
                i++;
                string avg = r.AverageRoundTrip?.ToString() ?? "N/A";
                string min = r.MinRoundTrip?.ToString() ?? "N/A";
                string max = r.MaxRoundTrip?.ToString() ?? "N/A";
                string loss = $"{r.PacketLoss:F1}%";
                string quality = r.AverageRoundTrip == null ? "UNREACHABLE" : r.QualityRating;

                sb.AppendLine($"   {i,-3} {r.Name,-18} {r.Host,-22} {avg,8} {min,8} {max,8} {loss,7} {quality,-12}");
            }

            sb.AppendLine();
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine("   QUALITY SCALE: Excellent <50ms | Good 50-99ms | Fair 100-249ms | Poor ≥250ms");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");

            File.WriteAllText(OutputFile, sb.ToString());
        }
    }

    // ─── Data Model ───────────────────────────────────────────────────────────────
    class SiteResult
    {
        public string Name { get; set; } = "";
        public string Host { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public List<PingReply?> PingReplies { get; set; } = new();

        public int SuccessCount =>
            PingReplies.Count(r => r?.Status == IPStatus.Success);

        public double PacketLoss =>
            PingReplies.Count == 0 ? 100.0
            : (1.0 - (double)SuccessCount / PingReplies.Count) * 100.0;

        public long? MinRoundTrip =>
            SuccessCount == 0 ? null
            : PingReplies.Where(r => r?.Status == IPStatus.Success)
                         .Min(r => r!.RoundtripTime);

        public long? MaxRoundTrip =>
            SuccessCount == 0 ? null
            : PingReplies.Where(r => r?.Status == IPStatus.Success)
                         .Max(r => r!.RoundtripTime);

        public long? AverageRoundTrip =>
            SuccessCount == 0 ? null
            : (long)PingReplies.Where(r => r?.Status == IPStatus.Success)
                                .Average(r => r!.RoundtripTime);

        public string QualityRating => AverageRoundTrip switch
        {
            null => "UNREACHABLE",
            < 50 => "Excellent",
            < 100 => "Good",
            < 250 => "Fair",
            _ => "Poor"
        };
    }
}
