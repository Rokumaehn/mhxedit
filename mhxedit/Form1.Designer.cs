﻿namespace mhxedit
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRank = new System.Windows.Forms.TextBox();
            this.textBoxZenny = new System.Windows.Forms.TextBox();
            this.textBoxPlayTime = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2Search = new System.Windows.Forms.TabPage();
            this.listBoxSearchResults = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearchOverwrite = new System.Windows.Forms.Button();
            this.tabPage2Misc = new System.Windows.Forms.TabPage();
            this.buttonSetAllMax = new System.Windows.Forms.Button();
            this.buttonSetSelMax = new System.Windows.Forms.Button();
            this.tabPage2Fill = new System.Windows.Forms.TabPage();
            this.checkBoxFillSkipDummy = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxFillIncrement = new System.Windows.Forms.CheckBox();
            this.numItemAmount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numLoopCount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numStartID = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monHunItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2Misc.SuspendLayout();
            this.tabPage2Fill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numItemAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoopCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monHunItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripComboBox1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 23);
            this.toolStripMenuItem2.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Enabled = false;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Slot 1",
            "Slot 2",
            "Slot 3"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(32, 19);
            this.miOpen.Text = "toolStripMenuItem2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "system";
            this.openFileDialog1.Filter = "MHX Save File|system";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(639, 430);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBoxRank);
            this.tabPage1.Controls.Add(this.textBoxZenny);
            this.tabPage1.Controls.Add(this.textBoxPlayTime);
            this.tabPage1.Controls.Add(this.textBoxName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(631, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Character";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "HR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zenny";
            // 
            // textBoxRank
            // 
            this.textBoxRank.Location = new System.Drawing.Point(95, 85);
            this.textBoxRank.Name = "textBoxRank";
            this.textBoxRank.Size = new System.Drawing.Size(144, 20);
            this.textBoxRank.TabIndex = 5;
            // 
            // textBoxZenny
            // 
            this.textBoxZenny.Location = new System.Drawing.Point(95, 59);
            this.textBoxZenny.Name = "textBoxZenny";
            this.textBoxZenny.Size = new System.Drawing.Size(144, 20);
            this.textBoxZenny.TabIndex = 4;
            // 
            // textBoxPlayTime
            // 
            this.textBoxPlayTime.Location = new System.Drawing.Point(95, 33);
            this.textBoxPlayTime.Name = "textBoxPlayTime";
            this.textBoxPlayTime.Size = new System.Drawing.Size(144, 20);
            this.textBoxPlayTime.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(95, 7);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(144, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Play Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(631, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Item Box";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2Search);
            this.tabControl2.Controls.Add(this.tabPage2Misc);
            this.tabControl2.Controls.Add(this.tabPage2Fill);
            this.tabControl2.Location = new System.Drawing.Point(375, 9);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(250, 389);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPage2Search
            // 
            this.tabPage2Search.Controls.Add(this.listBoxSearchResults);
            this.tabPage2Search.Controls.Add(this.numericUpDown1);
            this.tabPage2Search.Controls.Add(this.label5);
            this.tabPage2Search.Controls.Add(this.label6);
            this.tabPage2Search.Controls.Add(this.textBoxSearch);
            this.tabPage2Search.Controls.Add(this.buttonSearchOverwrite);
            this.tabPage2Search.Location = new System.Drawing.Point(4, 22);
            this.tabPage2Search.Name = "tabPage2Search";
            this.tabPage2Search.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2Search.Size = new System.Drawing.Size(242, 363);
            this.tabPage2Search.TabIndex = 0;
            this.tabPage2Search.Text = "Search";
            this.tabPage2Search.UseVisualStyleBackColor = true;
            // 
            // listBoxSearchResults
            // 
            this.listBoxSearchResults.FormattingEnabled = true;
            this.listBoxSearchResults.Location = new System.Drawing.Point(6, 26);
            this.listBoxSearchResults.Name = "listBoxSearchResults";
            this.listBoxSearchResults.Size = new System.Drawing.Size(227, 95);
            this.listBoxSearchResults.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(130, 135);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Search an Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Count";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(88, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(145, 20);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // buttonSearchOverwrite
            // 
            this.buttonSearchOverwrite.Location = new System.Drawing.Point(6, 128);
            this.buttonSearchOverwrite.Name = "buttonSearchOverwrite";
            this.buttonSearchOverwrite.Size = new System.Drawing.Size(75, 30);
            this.buttonSearchOverwrite.TabIndex = 4;
            this.buttonSearchOverwrite.Text = "Overwrite";
            this.buttonSearchOverwrite.UseVisualStyleBackColor = true;
            this.buttonSearchOverwrite.Click += new System.EventHandler(this.buttonSearchOverwrite_Click);
            // 
            // tabPage2Misc
            // 
            this.tabPage2Misc.Controls.Add(this.buttonSetAllMax);
            this.tabPage2Misc.Controls.Add(this.buttonSetSelMax);
            this.tabPage2Misc.Location = new System.Drawing.Point(4, 22);
            this.tabPage2Misc.Name = "tabPage2Misc";
            this.tabPage2Misc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2Misc.Size = new System.Drawing.Size(242, 363);
            this.tabPage2Misc.TabIndex = 1;
            this.tabPage2Misc.Text = "Misc";
            this.tabPage2Misc.UseVisualStyleBackColor = true;
            // 
            // buttonSetAllMax
            // 
            this.buttonSetAllMax.Location = new System.Drawing.Point(7, 44);
            this.buttonSetAllMax.Name = "buttonSetAllMax";
            this.buttonSetAllMax.Size = new System.Drawing.Size(98, 31);
            this.buttonSetAllMax.TabIndex = 1;
            this.buttonSetAllMax.Text = "Set all Max";
            this.buttonSetAllMax.UseVisualStyleBackColor = true;
            this.buttonSetAllMax.Click += new System.EventHandler(this.buttonSetAllMax_Click);
            // 
            // buttonSetSelMax
            // 
            this.buttonSetSelMax.Location = new System.Drawing.Point(7, 7);
            this.buttonSetSelMax.Name = "buttonSetSelMax";
            this.buttonSetSelMax.Size = new System.Drawing.Size(98, 31);
            this.buttonSetSelMax.TabIndex = 0;
            this.buttonSetSelMax.Text = "Set selected Max";
            this.buttonSetSelMax.UseVisualStyleBackColor = true;
            this.buttonSetSelMax.Click += new System.EventHandler(this.buttonSetSelMax_Click);
            // 
            // tabPage2Fill
            // 
            this.tabPage2Fill.Controls.Add(this.checkBoxFillSkipDummy);
            this.tabPage2Fill.Controls.Add(this.button1);
            this.tabPage2Fill.Controls.Add(this.checkBoxFillIncrement);
            this.tabPage2Fill.Controls.Add(this.numItemAmount);
            this.tabPage2Fill.Controls.Add(this.label10);
            this.tabPage2Fill.Controls.Add(this.numLoopCount);
            this.tabPage2Fill.Controls.Add(this.label9);
            this.tabPage2Fill.Controls.Add(this.numStartID);
            this.tabPage2Fill.Controls.Add(this.label8);
            this.tabPage2Fill.Controls.Add(this.label7);
            this.tabPage2Fill.Location = new System.Drawing.Point(4, 22);
            this.tabPage2Fill.Name = "tabPage2Fill";
            this.tabPage2Fill.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2Fill.Size = new System.Drawing.Size(242, 363);
            this.tabPage2Fill.TabIndex = 2;
            this.tabPage2Fill.Text = "Fill";
            this.tabPage2Fill.UseVisualStyleBackColor = true;
            // 
            // checkBoxFillSkipDummy
            // 
            this.checkBoxFillSkipDummy.AutoSize = true;
            this.checkBoxFillSkipDummy.Checked = true;
            this.checkBoxFillSkipDummy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFillSkipDummy.Location = new System.Drawing.Point(24, 85);
            this.checkBoxFillSkipDummy.Name = "checkBoxFillSkipDummy";
            this.checkBoxFillSkipDummy.Size = new System.Drawing.Size(83, 17);
            this.checkBoxFillSkipDummy.TabIndex = 9;
            this.checkBoxFillSkipDummy.Text = "Skip dummy";
            this.checkBoxFillSkipDummy.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Fill";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxFillIncrement
            // 
            this.checkBoxFillIncrement.AutoSize = true;
            this.checkBoxFillIncrement.Checked = true;
            this.checkBoxFillIncrement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFillIncrement.Location = new System.Drawing.Point(116, 85);
            this.checkBoxFillIncrement.Name = "checkBoxFillIncrement";
            this.checkBoxFillIncrement.Size = new System.Drawing.Size(73, 17);
            this.checkBoxFillIncrement.TabIndex = 7;
            this.checkBoxFillIncrement.Text = "Increment";
            this.checkBoxFillIncrement.UseVisualStyleBackColor = true;
            // 
            // numItemAmount
            // 
            this.numItemAmount.Location = new System.Drawing.Point(116, 59);
            this.numItemAmount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numItemAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numItemAmount.Name = "numItemAmount";
            this.numItemAmount.Size = new System.Drawing.Size(120, 20);
            this.numItemAmount.TabIndex = 6;
            this.numItemAmount.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Item Amount";
            // 
            // numLoopCount
            // 
            this.numLoopCount.Location = new System.Drawing.Point(116, 33);
            this.numLoopCount.Maximum = new decimal(new int[] {
            1400,
            0,
            0,
            0});
            this.numLoopCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLoopCount.Name = "numLoopCount";
            this.numLoopCount.Size = new System.Drawing.Size(120, 20);
            this.numLoopCount.TabIndex = 4;
            this.numLoopCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Loop Count";
            // 
            // numStartID
            // 
            this.numStartID.Location = new System.Drawing.Point(116, 7);
            this.numStartID.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numStartID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStartID.Name = "numStartID";
            this.numStartID.Size = new System.Drawing.Size(120, 20);
            this.numStartID.TabIndex = 2;
            this.numStartID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Starting ID";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(6, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Does a simple loop beginning at the currently selected item and increments the ID" +
    " for each";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.monHunItemBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(363, 392);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // monHunItemBindingSource
            // 
            this.monHunItemBindingSource.DataSource = typeof(mhxedit.MonHunItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 472);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "mhxedit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2Search.ResumeLayout(false);
            this.tabPage2Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2Misc.ResumeLayout(false);
            this.tabPage2Fill.ResumeLayout(false);
            this.tabPage2Fill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numItemAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoopCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monHunItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRank;
        private System.Windows.Forms.TextBox textBoxZenny;
        private System.Windows.Forms.TextBox textBoxPlayTime;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource monHunItemBindingSource;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSearchOverwrite;
        private System.Windows.Forms.ListBox listBoxSearchResults;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2Search;
        private System.Windows.Forms.TabPage tabPage2Misc;
        private System.Windows.Forms.Button buttonSetAllMax;
        private System.Windows.Forms.Button buttonSetSelMax;
        private System.Windows.Forms.TabPage tabPage2Fill;
        private System.Windows.Forms.NumericUpDown numLoopCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numStartID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxFillIncrement;
        private System.Windows.Forms.NumericUpDown numItemAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxFillSkipDummy;
    }
}

