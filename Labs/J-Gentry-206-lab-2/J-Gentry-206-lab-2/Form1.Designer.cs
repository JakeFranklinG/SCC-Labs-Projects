namespace J_Gentry_206_lab_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cityDBDataSet = new J_Gentry_206_lab_2.CityDBDataSet();
            this.cityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityTableAdapter = new J_Gentry_206_lab_2.CityDBDataSetTableAdapters.CityTableAdapter();
            this.tableAdapterManager = new J_Gentry_206_lab_2.CityDBDataSetTableAdapters.TableAdapterManager();
            this.cityBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cityBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cityDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gboxSorting = new System.Windows.Forms.GroupBox();
            this.butSortCity = new System.Windows.Forms.Button();
            this.butSortAscen = new System.Windows.Forms.Button();
            this.butSortDescen = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.lblTitleLow = new System.Windows.Forms.Label();
            this.lblTitleHigh = new System.Windows.Forms.Label();
            this.lblTitleAver = new System.Windows.Forms.Label();
            this.lblTitleTotal = new System.Windows.Forms.Label();
            this.butCal = new System.Windows.Forms.Button();
            this.lblOutputLow = new System.Windows.Forms.Label();
            this.lblOutputAver = new System.Windows.Forms.Label();
            this.lblOutputHigh = new System.Windows.Forms.Label();
            this.lblOutputTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cityDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingNavigator)).BeginInit();
            this.cityBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityDataGridView)).BeginInit();
            this.gboxSorting.SuspendLayout();
            this.SuspendLayout();
            // 
            // cityDBDataSet
            // 
            this.cityDBDataSet.DataSetName = "CityDBDataSet";
            this.cityDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cityBindingSource
            // 
            this.cityBindingSource.DataMember = "City";
            this.cityBindingSource.DataSource = this.cityDBDataSet;
            // 
            // cityTableAdapter
            // 
            this.cityTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CityTableAdapter = this.cityTableAdapter;
            this.tableAdapterManager.UpdateOrder = J_Gentry_206_lab_2.CityDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cityBindingNavigator
            // 
            this.cityBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.cityBindingNavigator.BindingSource = this.cityBindingSource;
            this.cityBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.cityBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.cityBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cityBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.cityBindingNavigatorSaveItem});
            this.cityBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.cityBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.cityBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.cityBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.cityBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.cityBindingNavigator.Name = "cityBindingNavigator";
            this.cityBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.cityBindingNavigator.Size = new System.Drawing.Size(1223, 27);
            this.cityBindingNavigator.TabIndex = 0;
            this.cityBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // cityBindingNavigatorSaveItem
            // 
            this.cityBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cityBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("cityBindingNavigatorSaveItem.Image")));
            this.cityBindingNavigatorSaveItem.Name = "cityBindingNavigatorSaveItem";
            this.cityBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.cityBindingNavigatorSaveItem.Text = "Save Data";
            this.cityBindingNavigatorSaveItem.Click += new System.EventHandler(this.cityBindingNavigatorSaveItem_Click);
            // 
            // cityDataGridView
            // 
            this.cityDataGridView.AutoGenerateColumns = false;
            this.cityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cityDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.cityDataGridView.DataSource = this.cityBindingSource;
            this.cityDataGridView.Location = new System.Drawing.Point(69, 66);
            this.cityDataGridView.Name = "cityDataGridView";
            this.cityDataGridView.RowHeadersWidth = 51;
            this.cityDataGridView.RowTemplate.Height = 24;
            this.cityDataGridView.Size = new System.Drawing.Size(721, 386);
            this.cityDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CityID";
            this.dataGridViewTextBoxColumn1.HeaderText = "CityID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "City";
            this.dataGridViewTextBoxColumn2.HeaderText = "City";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "State";
            this.dataGridViewTextBoxColumn3.HeaderText = "State";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Population";
            this.dataGridViewTextBoxColumn4.HeaderText = "Population";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // gboxSorting
            // 
            this.gboxSorting.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gboxSorting.Controls.Add(this.butSortCity);
            this.gboxSorting.Controls.Add(this.butSortAscen);
            this.gboxSorting.Controls.Add(this.butSortDescen);
            this.gboxSorting.Location = new System.Drawing.Point(861, 66);
            this.gboxSorting.Name = "gboxSorting";
            this.gboxSorting.Size = new System.Drawing.Size(293, 145);
            this.gboxSorting.TabIndex = 4;
            this.gboxSorting.TabStop = false;
            this.gboxSorting.Text = "Sorting the Database:";
            // 
            // butSortCity
            // 
            this.butSortCity.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butSortCity.Location = new System.Drawing.Point(21, 79);
            this.butSortCity.Name = "butSortCity";
            this.butSortCity.Size = new System.Drawing.Size(116, 52);
            this.butSortCity.TabIndex = 2;
            this.butSortCity.Text = "Sort by &City";
            this.butSortCity.UseVisualStyleBackColor = false;
            this.butSortCity.Click += new System.EventHandler(this.butSortCity_Click);
            // 
            // butSortAscen
            // 
            this.butSortAscen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butSortAscen.Location = new System.Drawing.Point(21, 21);
            this.butSortAscen.Name = "butSortAscen";
            this.butSortAscen.Size = new System.Drawing.Size(116, 52);
            this.butSortAscen.TabIndex = 0;
            this.butSortAscen.Text = "Sort in &Ascending Order";
            this.butSortAscen.UseVisualStyleBackColor = false;
            this.butSortAscen.Click += new System.EventHandler(this.butSortAscen_Click_1);
            // 
            // butSortDescen
            // 
            this.butSortDescen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butSortDescen.Location = new System.Drawing.Point(143, 21);
            this.butSortDescen.Name = "butSortDescen";
            this.butSortDescen.Size = new System.Drawing.Size(126, 52);
            this.butSortDescen.TabIndex = 1;
            this.butSortDescen.Text = "Sort in &Descending Order";
            this.butSortDescen.UseVisualStyleBackColor = false;
            this.butSortDescen.Click += new System.EventHandler(this.butSortDescen_Click_1);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(861, 244);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(116, 53);
            this.butClear.TabIndex = 5;
            this.butClear.Text = "Clea&r";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Location = new System.Drawing.Point(1038, 244);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(116, 53);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "E&xit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // lblTitleLow
            // 
            this.lblTitleLow.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLow.Location = new System.Drawing.Point(436, 516);
            this.lblTitleLow.Name = "lblTitleLow";
            this.lblTitleLow.Size = new System.Drawing.Size(84, 32);
            this.lblTitleLow.TabIndex = 29;
            this.lblTitleLow.Text = "Lowest:";
            // 
            // lblTitleHigh
            // 
            this.lblTitleHigh.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleHigh.Location = new System.Drawing.Point(196, 516);
            this.lblTitleHigh.Name = "lblTitleHigh";
            this.lblTitleHigh.Size = new System.Drawing.Size(84, 32);
            this.lblTitleHigh.TabIndex = 28;
            this.lblTitleHigh.Text = "Highest:";
            // 
            // lblTitleAver
            // 
            this.lblTitleAver.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleAver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAver.Location = new System.Drawing.Point(432, 473);
            this.lblTitleAver.Name = "lblTitleAver";
            this.lblTitleAver.Size = new System.Drawing.Size(88, 32);
            this.lblTitleAver.TabIndex = 27;
            this.lblTitleAver.Text = "Average:";
            // 
            // lblTitleTotal
            // 
            this.lblTitleTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTotal.Location = new System.Drawing.Point(217, 473);
            this.lblTitleTotal.Name = "lblTitleTotal";
            this.lblTitleTotal.Size = new System.Drawing.Size(63, 32);
            this.lblTitleTotal.TabIndex = 26;
            this.lblTitleTotal.Text = "Total:";
            // 
            // butCal
            // 
            this.butCal.Location = new System.Drawing.Point(349, 593);
            this.butCal.Name = "butCal";
            this.butCal.Size = new System.Drawing.Size(146, 62);
            this.butCal.TabIndex = 21;
            this.butCal.Text = "C&alculate";
            this.butCal.UseVisualStyleBackColor = true;
            this.butCal.Click += new System.EventHandler(this.butCal_Click);
            // 
            // lblOutputLow
            // 
            this.lblOutputLow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOutputLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutputLow.Location = new System.Drawing.Point(526, 512);
            this.lblOutputLow.Name = "lblOutputLow";
            this.lblOutputLow.Size = new System.Drawing.Size(98, 37);
            this.lblOutputLow.TabIndex = 25;
            this.lblOutputLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutputAver
            // 
            this.lblOutputAver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOutputAver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutputAver.Location = new System.Drawing.Point(526, 468);
            this.lblOutputAver.Name = "lblOutputAver";
            this.lblOutputAver.Size = new System.Drawing.Size(98, 38);
            this.lblOutputAver.TabIndex = 24;
            this.lblOutputAver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutputHigh
            // 
            this.lblOutputHigh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOutputHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutputHigh.Location = new System.Drawing.Point(288, 512);
            this.lblOutputHigh.Name = "lblOutputHigh";
            this.lblOutputHigh.Size = new System.Drawing.Size(97, 37);
            this.lblOutputHigh.TabIndex = 23;
            this.lblOutputHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutputTotal
            // 
            this.lblOutputTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOutputTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutputTotal.Location = new System.Drawing.Point(286, 468);
            this.lblOutputTotal.Name = "lblOutputTotal";
            this.lblOutputTotal.Size = new System.Drawing.Size(97, 37);
            this.lblOutputTotal.TabIndex = 22;
            this.lblOutputTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AcceptButton = this.butCal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(1223, 748);
            this.Controls.Add(this.lblTitleLow);
            this.Controls.Add(this.lblTitleHigh);
            this.Controls.Add(this.lblTitleAver);
            this.Controls.Add(this.lblTitleTotal);
            this.Controls.Add(this.butCal);
            this.Controls.Add(this.lblOutputLow);
            this.Controls.Add(this.lblOutputAver);
            this.Controls.Add(this.lblOutputHigh);
            this.Controls.Add(this.lblOutputTotal);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.gboxSorting);
            this.Controls.Add(this.cityDataGridView);
            this.Controls.Add(this.cityBindingNavigator);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jake Gentry Database";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cityDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingNavigator)).EndInit();
            this.cityBindingNavigator.ResumeLayout(false);
            this.cityBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityDataGridView)).EndInit();
            this.gboxSorting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CityDBDataSet cityDBDataSet;
        private System.Windows.Forms.BindingSource cityBindingSource;
        private CityDBDataSetTableAdapters.CityTableAdapter cityTableAdapter;
        private CityDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator cityBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton cityBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView cityDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox gboxSorting;
        private System.Windows.Forms.Button butSortCity;
        private System.Windows.Forms.Button butSortAscen;
        private System.Windows.Forms.Button butSortDescen;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Label lblTitleLow;
        private System.Windows.Forms.Label lblTitleHigh;
        private System.Windows.Forms.Label lblTitleAver;
        private System.Windows.Forms.Label lblTitleTotal;
        private System.Windows.Forms.Button butCal;
        private System.Windows.Forms.Label lblOutputLow;
        private System.Windows.Forms.Label lblOutputAver;
        private System.Windows.Forms.Label lblOutputHigh;
        private System.Windows.Forms.Label lblOutputTotal;
    }
}

