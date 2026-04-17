# State Database - Database Setup Instructions

## Step 1: Create the Database

1. Open **Visual Studio**
2. Go to **View → SQL Server Object Explorer** (or press `Ctrl+\, Ctrl+S`)
3. Expand **(localdb)\MSSQLLocalDB**
4. Right-click **Databases** → **Add New Database**
5. Name it: `StateDatabase`
6. Click **OK**

## Step 2: Create the States Table

1. In **SQL Server Object Explorer**, expand your new **StateDatabase**
2. Right-click **Tables** → **Add New Table**
3. Paste the following SQL script into the T-SQL editor:

```sql
CREATE TABLE [dbo].[States]
(
    [StateId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [StateName] NVARCHAR(50) NOT NULL,
    [Population] INT NOT NULL,
    [FlagDescription] NVARCHAR(500) NOT NULL,
    [StateFlower] NVARCHAR(100) NOT NULL,
    [StateBird] NVARCHAR(100) NOT NULL,
    [StateColors] NVARCHAR(100) NOT NULL,
    [LargestCity1] NVARCHAR(100) NOT NULL,
    [LargestCity2] NVARCHAR(100) NOT NULL,
    [LargestCity3] NVARCHAR(100) NOT NULL,
    [StateCapitol] NVARCHAR(100) NOT NULL,
    [MedianIncome] DECIMAL(18, 2) NOT NULL,
    [ComputerJobsPercentage] DECIMAL(5, 2) NOT NULL
)
```

4. Click **Update** (top-left corner)
5. Click **Update Database** in the preview window

---

## Step 3: Insert All 50 States Data

1. Right-click **StateDatabase** → **New Query**
2. Paste the following complete INSERT script:

```sql
-- Insert all 50 US States into the States table

INSERT INTO States (StateName, Population, FlagDescription, StateFlower, StateBird, StateColors, LargestCity1, LargestCity2, LargestCity3, StateCapitol, MedianIncome, ComputerJobsPercentage)
VALUES 
('Alabama', 5237750, 'Crimson background with white X cross', 'Camellia', 'Yellowhammer', 'Crimson / White', 'Huntsville', 'Montgomery', 'Birmingham', 'Montgomery', 31232, 3.1),
('Alaska', 747379, 'Dark blue with gold Big Dipper stars', 'Forget-me-not', 'Willow Ptarmigan', 'Dark Blue / Gold', 'Anchorage', 'Juneau', 'Fairbanks', 'Juneau', 46819, 7.6),
('Arizona', 7801100, 'Setting sun rays with copper star', 'Saguaro Cactus Blossom', 'Cactus Wren', 'Red / Yellow / Copper / Blue', 'Phoenix', 'Tucson', 'Mesa', 'Phoenix', 41272, 5.1),
('Arkansas', 3126140, 'Red with blue diamond and stars', 'Apple Blossom', 'Mockingbird', 'Red / White / Blue', 'Little Rock', 'Fayetteville', 'Fort Smith', 'Little Rock', 30682, 5.8),
('California', 39896400, 'Grizzly bear and California Republic text', 'Golden Poppy', 'California Valley Quail', 'White / Green / Red / Gold', 'Los Angeles', 'San Diego', 'San Jose', 'Sacramento', 50251, 1.4),
('Colorado', 6069800, 'Blue stripes with red C and gold disk', 'Columbine', 'Lark Bunting', 'Blue / White / Red / Gold', 'Denver', 'Colorado Springs', 'Aurora', 'Denver', 49447, 4.8),
('Connecticut', 3739160, 'Blue with white shield and grapevines', 'Mountain Laurel', 'American Robin', 'Blue / White / Gold', 'Bridgeport', 'Stamford', 'New Haven', 'Hartford', 44224, 6.6),
('Delaware', 1082900, 'Blue with buff diamond and state seal', 'Peach Blossom', 'Blue Hen Chicken', 'Blue / Buff / Gold / White', 'Wilmington', 'Dover', 'Newark', 'Dover', 42168, 33.5),
('Florida', 24306900, 'White with red X cross and seal', 'Orange Blossom', 'Mockingbird', 'White / Red / Blue', 'Jacksonville', 'Miami', 'Tampa', 'Tallahassee', 39438, 3.5),
('Georgia', 11413800, 'Red with blue canton and white stars', 'Cherokee Rose', 'Brown Thrasher', 'Red / White / Blue / Gold', 'Atlanta', 'Columbus', 'Augusta', 'Atlanta', 40028, 2.6),
('Hawaii', 1455660, 'Red and white stripes with Union Jack', 'Hibiscus', 'Nene (Hawaiian Goose)', 'Red / White / Blue', 'Honolulu', 'East Honolulu', 'Pearl City', 'Honolulu', 44402, 9.1),
('Idaho', 2062610, 'Dark blue with state seal and figures', 'Syringa', 'Mountain Bluebird', 'Dark Blue / Gold / White', 'Boise', 'Meridian', 'Nampa', 'Boise', 35951, 9.1),
('Illinois', 12846000, 'White with eagle holding state motto', 'Native Violet', 'Cardinal', 'White / Blue / Gold / Red', 'Chicago', 'Aurora', 'Naperville', 'Springfield', 41888, 2.5),
('Indiana', 7012560, 'Dark blue with golden torch and stars', 'Peony', 'Cardinal', 'Dark Blue / Gold / White', 'Indianapolis', 'Fort Wayne', 'Evansville', 'Indianapolis', 36674, 4.1),
('Iowa', 3287640, 'Blue white red stripes with eagle', 'Wild Rose', 'Eastern Goldfinch', 'Blue / White / Red / Gold', 'Des Moines', 'Cedar Rapids', 'Davenport', 'Des Moines', 37172, 3.2),
('Kansas', 3008820, 'Dark blue with seal and sunflower', 'Native Sunflower', 'Western Meadowlark', 'Dark Blue / Gold / Red / White', 'Wichita', 'Overland Park', 'Kansas City', 'Topeka', 36534, 4.8),
('Kentucky', 4663930, 'Navy blue with seal and goldenrod', 'Goldenrod', 'Kentucky Cardinal', 'Navy Blue / Gold / White', 'Louisville', 'Lexington', 'Bowling Green', 'Frankfort', 31481, 6.3),
('Louisiana', 4617080, 'Azure blue with pelican feeding young', 'Magnolia', 'Pelican', 'Azure Blue / White / Brown', 'New Orleans', 'Baton Rouge', 'Shreveport', 'Baton Rouge', 29921, 4.2),
('Maine', 1415740, 'Blue with coat of arms and motto', 'White Pine Cone and Tassel', 'Chickadee', 'Blue / Gold / White', 'Portland', 'Lewiston', 'Bangor', 'Augusta', 36001, 12.9),
('Maryland', 6355540, 'Blue yellow black red cross pattern', 'Black-Eyed Susan', 'Baltimore Oriole', 'Blue / Yellow / Black / Red / White', 'Baltimore', 'Columbia', 'Germantown', 'Annapolis', 52519, 3.5),
('Massachusetts', 7275380, 'Blue with Native American and star', 'Mayflower', 'Chickadee', 'Blue / White / Gold', 'Boston', 'Worcester', 'Springfield', 'Boston', 45920, 3.6),
('Michigan', 10254700, 'Blue with elk and moose shield', 'Apple Blossom', 'Robin', 'Blue / Gold / White / Brown', 'Detroit', 'Grand Rapids', 'Warren', 'Lansing', 36687, 8.4),
('Minnesota', 5873360, 'Blue with seal and flower wreath', 'Pink and White Lady''s Slipper', 'Common Loon', 'Blue / Gold / Red / White', 'Minneapolis', 'Saint Paul', 'Rochester', 'St. Paul', 43172, 2.6),
('Mississippi', 2942790, 'Blue white red bars with magnolia', 'Magnolia', 'Mockingbird', 'Blue / White / Red / Gold', 'Jackson', 'Gulfport', 'Southaven', 'Jackson', 27205, 13.5),
('Missouri', 6320320, 'Red white blue stripes with seal', 'Hawthorn', 'Bluebird', 'Red / White / Blue / Gold', 'Kansas City', 'Saint Louis', 'Springfield', 'Jefferson City', 36283, 3.4),
('Montana', 1149100, 'Dark blue with miner and mountains', 'Bitterroot', 'Western Meadowlark', 'Dark Blue / Gold / White / Brown', 'Billings', 'Missoula', 'Great Falls', 'Helena', 35369, 16.6),
('Nebraska', 2040670, 'Dark blue with steamboat and cabin', 'Goldenrod', 'Western Meadowlark', 'Dark Blue / Gold / White / Brown', 'Omaha', 'Lincoln', 'Bellevue', 'Lincoln', 38276, 17.2),
('Nevada', 3373680, 'Cobalt blue with silver star and sagebrush', 'Sagebrush', 'Mountain Bluebird', 'Cobalt Blue / Silver / Gold / Green', 'Las Vegas', 'Henderson', 'Reno', 'Carson City', 42034, 7.1),
('New Hampshire', 1422700, 'Deep blue with USS Raleigh frigate', 'Purple Lilac', 'Purple Finch', 'Deep Blue / Gold / White / Red', 'Manchester', 'Nashua', 'Concord', 'Concord', 45746, 3.8),
('New Jersey', 9743270, 'Blue with goddesses and three plows', 'Purple Violet', 'Eastern Goldfinch', 'Blue / Buff / Gold / White', 'Newark', 'Jersey City', 'Paterson', 'Trenton', 48523, 2.7),
('New Mexico', 2148440, 'Yellow with red Zia sun symbol', 'Yucca Flower', 'Roadrunner', 'Yellow / Red', 'Albuquerque', 'Las Cruces', 'Rio Rancho', 'Santa Fe', 35969, 10.4),
('New York', 20127000, 'Blue with goddesses and shield', 'Rose', 'Bluebird', 'Blue / Gold / White / Red', 'New York City', 'Buffalo', 'Yonkers', 'Albany', 42397, 1.8),
('North Carolina', 11375700, 'Red white stripes with blue canton and star', 'Dogwood', 'Cardinal', 'Red / White / Blue / Gold', 'Charlotte', 'Raleigh', 'Greensboro', 'Raleigh', 38073, 2.8),
('North Dakota', 811610, 'Deep blue with eagle and arrows', 'Wild Prairie Rose', 'Western Meadowlark', 'Deep Blue / Gold / Red / White', 'Fargo', 'Bismarck', 'Grand Forks', 'Bismarck', 39690, 5.8),
('Ohio', 12001800, 'Red white blue stripes with circle (burgee)', 'Scarlet Carnation', 'Cardinal', 'Red / White / Blue', 'Columbus', 'Cleveland', 'Cincinnati', 'Columbus', 36615, 4.0),
('Oklahoma', 4158420, 'Blue with Osage shield and feathers', 'Mistletoe', 'Scissor-Tailed Flycatcher', 'Blue / White / Brown / Gold', 'Oklahoma City', 'Tulsa', 'Norman', 'Oklahoma City', 32704, 3.6),
('Oregon', 4309810, 'Navy blue with beaver on reverse side', 'Oregon Grape', 'Western Meadowlark', 'Navy Blue / Gold / White / Green', 'Portland', 'Salem', 'Eugene', 'Salem', 39791, 8.2),
('Pennsylvania', 13200800, 'Deep blue with horses and eagle', 'Mountain Laurel', 'Ruffed Grouse', 'Deep Blue / Black / Gold / White', 'Philadelphia', 'Pittsburgh', 'Allentown', 'Harrisburg', 37725, 3.2),
('Rhode Island', 1130070, 'White with gold anchor and stars', 'Violet', 'Rhode Island Red', 'White / Gold / Blue', 'Providence', 'Cranston', 'Warwick', 'Providence', 42225, 10.1),
('South Carolina', 5660830, 'Dark blue with palmetto tree and crescent', 'Yellow Jessamine', 'Carolina Wren', 'Dark Blue / White', 'Charleston', 'Columbia', 'North Charleston', 'Columbia', 36564, 3.4),
('South Dakota', 937397, 'Blue with golden sun and seal', 'American Pasqueflower', 'Ring-Necked Pheasant', 'Blue / Gold / White', 'Sioux Falls', 'Rapid City', 'Aberdeen', 'Pierre', 37260, 18.9),
('Tennessee', 7386640, 'Red with blue circle and three stars', 'Iris', 'Mockingbird', 'Red / Blue / White', 'Nashville', 'Memphis', 'Knoxville', 'Nashville', 36264, 3.2),
('Texas', 32416700, 'Red white blue with lone star', 'Bluebonnet', 'Mockingbird', 'Red / White / Blue', 'Houston', 'San Antonio', 'Dallas', 'Austin', 41661, 2.4),
('Utah', 3624400, 'Dark blue with beehive and lilies', 'Sego Lily', 'California Gull', 'Dark Blue / Gold / White / Green', 'Salt Lake City', 'West Valley City', 'Provo', 'Salt Lake City', 44905, 5.5),
('Vermont', 648063, 'Blue with pine tree and cow', 'Red Clover', 'Hermit Thrush', 'Blue / Gold / White / Green', 'Burlington', 'South Burlington', 'Colchester', 'Montpelier', 39613, 13.2),
('Virginia', 8964220, 'Dark blue with liberty and tyranny figures', 'Dogwood', 'Cardinal', 'Dark Blue / Gold / White / Red', 'Virginia Beach', 'Norfolk', 'Chesapeake', 'Richmond', 46767, 2.3),
('Washington', 8159900, 'Green with George Washington bust', 'Western Rhododendron', 'Willow Goldfinch', 'Green / Blue / Gold / White', 'Seattle', 'Spokane', 'Tacoma', 'Olympia', 48386, 2.7),
('West Virginia', 1768950, 'Blue with farmer and miner figures', 'Big Rhododendron', 'Cardinal', 'Blue / White / Red / Gold', 'Charleston', 'Huntington', 'Morgantown', 'Charleston', 29140, 5.7),
('Wisconsin', 6022120, 'Blue with badger and state motto', 'Wood Violet', 'Robin', 'Blue / Gold / White / Brown', 'Milwaukee', 'Madison', 'Green Bay', 'Madison', 39966, 3.8),
('Wyoming', 592720, 'Blue with golden bison and seal', 'Indian Paintbrush', 'Meadowlark', 'Blue / Gold / White / Brown', 'Cheyenne', 'Casper', 'Laramie', 'Cheyenne', 38508, 5.1);
```

3. Click the green **Execute** button (or press `Ctrl+Shift+E`)
4. You should see: **"(50 rows affected)"**
5. Done! The database is now ready to use.
