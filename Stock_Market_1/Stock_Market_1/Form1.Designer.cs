namespace Stock_Market_1
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
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.loadComboBox2 = new System.Windows.Forms.ComboBox();
            this.loadComboBox1 = new System.Windows.Forms.ComboBox();
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.localLoad = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.AutoSize = true;
            this.formsPlot1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(4, 4);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.SetRowSpan(this.formsPlot1, 6);
            this.formsPlot1.Size = new System.Drawing.Size(472, 442);
            this.formsPlot1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(723, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.localLoad, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.loadComboBox2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.loadComboBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.searchComboBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.formsPlot1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.searchBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Search, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.Save, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // loadComboBox2
            // 
            this.loadComboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.loadComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.loadComboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadComboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadComboBox2.DropDownHeight = 100;
            this.loadComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loadComboBox2.IntegralHeight = false;
            this.loadComboBox2.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.loadComboBox2.Location = new System.Drawing.Point(563, 273);
            this.loadComboBox2.Name = "loadComboBox2";
            this.loadComboBox2.Size = new System.Drawing.Size(74, 24);
            this.loadComboBox2.TabIndex = 10;
            // 
            // loadComboBox1
            // 
            this.loadComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.loadComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.loadComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadComboBox1.DropDownHeight = 100;
            this.loadComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loadComboBox1.IntegralHeight = false;
            this.loadComboBox1.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.loadComboBox1.Location = new System.Drawing.Point(483, 273);
            this.loadComboBox1.Name = "loadComboBox1";
            this.loadComboBox1.Size = new System.Drawing.Size(74, 24);
            this.loadComboBox1.TabIndex = 9;
            this.loadComboBox1.SelectedIndexChanged += new System.EventHandler(this.loadComboBox1_SelectedIndexChanged);
            // 
            // searchComboBox
            // 
            this.searchComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.searchComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.searchComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchComboBox.DropDownHeight = 100;
            this.searchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchComboBox.IntegralHeight = false;
            this.searchComboBox.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.searchComboBox.Location = new System.Drawing.Point(563, 318);
            this.searchComboBox.Name = "searchComboBox";
            this.searchComboBox.Size = new System.Drawing.Size(74, 24);
            this.searchComboBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(640, 45);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Click.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(483, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "IBM";
            // 
            // searchBox
            // 
            this.searchBox.AutoCompleteCustomSource.AddRange(new string[] {
            "NSE:RELIANCE",
            "NSE:TATACHEM",
            "NSE:TATACOFFEE",
            "NSE:AXISBANK",
            "NSE:TATACOMM",
            "NSE:AXISBANK",
            "NSE:BANKBARODA",
            "NSE:ICICIBANK",
            "NSE:BANKINDIA",
            "NSE:KTKBANK",
            "NSE:PNB",
            "NSE:HAL",
            "NSE:HINDCOMPOS",
            "NSE:HINDMOTORS",
            "NSE:HINDCOPPER",
            "NSE:HINDZINC"});
            this.searchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Location = new System.Drawing.Point(483, 318);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(74, 22);
            this.searchBox.TabIndex = 5;
            this.searchBox.Text = "BSE:RELIANCE";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownHeight = 100;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Weekly"});
            this.comboBox1.Location = new System.Drawing.Point(563, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(74, 24);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 4;
            // 
            // Search
            // 
            this.Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Search.Location = new System.Drawing.Point(643, 318);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(74, 39);
            this.Search.TabIndex = 7;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Save
            // 
            this.Save.Dock = System.Windows.Forms.DockStyle.Left;
            this.Save.Location = new System.Drawing.Point(643, 363);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(74, 39);
            this.Save.TabIndex = 8;
            this.Save.TabStop = false;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // localLoad
            // 
            this.localLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localLoad.Location = new System.Drawing.Point(643, 273);
            this.localLoad.Name = "localLoad";
            this.localLoad.Size = new System.Drawing.Size(74, 39);
            this.localLoad.TabIndex = 11;
            this.localLoad.Text = "localLoad";
            this.localLoad.UseVisualStyleBackColor = true;
            this.localLoad.Click += new System.EventHandler(this.localLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ComboBox loadComboBox2;
        private System.Windows.Forms.ComboBox loadComboBox1;
        private System.Windows.Forms.Button localLoad;
    }
}

