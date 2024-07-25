namespace MHGQuestEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            questTitle = new TextBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            description = new TextBox();
            label3 = new Label();
            failCond = new TextBox();
            label2 = new Label();
            winCond = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            qstCond = new TextBox();
            label19 = new Label();
            label18 = new Label();
            id = new NumericUpDown();
            dataUnk = new TextBox();
            label17 = new Label();
            timeMins = new Label();
            label16 = new Label();
            timeLmt = new NumericUpDown();
            label15 = new Label();
            cart = new NumericUpDown();
            label14 = new Label();
            reward = new NumericUpDown();
            label13 = new Label();
            fee = new NumericUpDown();
            label12 = new Label();
            starLvl = new NumericUpDown();
            label11 = new Label();
            questFlags = new TextBox();
            questType = new ComboBox();
            label10 = new Label();
            difficulty = new ComboBox();
            label9 = new Label();
            locale = new ComboBox();
            label8 = new Label();
            hrp = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            bossSize = new NumericUpDown();
            label5 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox4 = new GroupBox();
            groupBox3 = new GroupBox();
            supplyGrid = new DataGridView();
            itemNameSup = new DataGridViewComboBoxColumn();
            itemQtySup = new DataGridViewTextBoxColumn();
            label22 = new Label();
            label21 = new Label();
            label20 = new Label();
            supplyQty = new NumericUpDown();
            supplyMon = new ComboBox();
            supplyType = new ComboBox();
            tabPage2 = new TabPage();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)id).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeLmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reward).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)starLvl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hrp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bossSize).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)supplyGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)supplyQty).BeginInit();
            SuspendLayout();
            // 
            // questTitle
            // 
            questTitle.Location = new Point(112, 24);
            questTitle.Name = "questTitle";
            questTitle.Size = new Size(233, 23);
            questTitle.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(description);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(failCond);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(winCond);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(questTitle);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(357, 267);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 164);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 7;
            label4.Text = "Description";
            // 
            // description
            // 
            description.Location = new Point(112, 161);
            description.Multiline = true;
            description.Name = "description";
            description.Size = new Size(233, 96);
            description.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 107);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 5;
            label3.Text = "Fail Condition";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // failCond
            // 
            failCond.Location = new Point(112, 107);
            failCond.Multiline = true;
            failCond.Name = "failCond";
            failCond.Size = new Size(233, 48);
            failCond.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 3;
            label2.Text = "Victory Condition";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // winCond
            // 
            winCond.Location = new Point(112, 53);
            winCond.Multiline = true;
            winCond.Name = "winCond";
            winCond.Size = new Size(233, 48);
            winCond.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 27);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 1;
            label1.Text = "Title";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(qstCond);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(id);
            groupBox2.Controls.Add(dataUnk);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(timeMins);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(timeLmt);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(cart);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(reward);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(fee);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(starLvl);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(questFlags);
            groupBox2.Controls.Add(questType);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(difficulty);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(locale);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(hrp);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(bossSize);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(369, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(601, 266);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "General";
            // 
            // qstCond
            // 
            qstCond.Location = new Point(274, 224);
            qstCond.Name = "qstCond";
            qstCond.Size = new Size(121, 23);
            qstCond.TabIndex = 31;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(203, 227);
            label19.Name = "label19";
            label19.Size = new Size(65, 15);
            label19.TabIndex = 30;
            label19.Text = "Conditions";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(251, 199);
            label18.Name = "label18";
            label18.Size = new Size(18, 15);
            label18.TabIndex = 29;
            label18.Text = "ID";
            // 
            // id
            // 
            id.Location = new Point(274, 195);
            id.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            id.Name = "id";
            id.Size = new Size(121, 23);
            id.TabIndex = 28;
            // 
            // dataUnk
            // 
            dataUnk.Location = new Point(274, 166);
            dataUnk.Name = "dataUnk";
            dataUnk.Size = new Size(121, 23);
            dataUnk.TabIndex = 27;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(211, 170);
            label17.Name = "label17";
            label17.Size = new Size(58, 15);
            label17.TabIndex = 26;
            label17.Text = "Unknown";
            // 
            // timeMins
            // 
            timeMins.AutoSize = true;
            timeMins.Location = new Point(76, 191);
            timeMins.Name = "timeMins";
            timeMins.Size = new Size(40, 15);
            timeMins.TabIndex = 25;
            timeMins.Text = "0 min.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(8, 167);
            label16.Name = "label16";
            label16.Size = new Size(63, 15);
            label16.TabIndex = 24;
            label16.Text = "Time Limit";
            // 
            // timeLmt
            // 
            timeLmt.Location = new Point(76, 163);
            timeLmt.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            timeLmt.Name = "timeLmt";
            timeLmt.Size = new Size(121, 23);
            timeLmt.TabIndex = 23;
            timeLmt.ValueChanged += timeLmt_ValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(213, 141);
            label15.Name = "label15";
            label15.Size = new Size(56, 15);
            label15.TabIndex = 21;
            label15.Text = "Cart Cost";
            // 
            // cart
            // 
            cart.Location = new Point(274, 137);
            cart.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            cart.Name = "cart";
            cart.Size = new Size(121, 23);
            cart.TabIndex = 22;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(223, 112);
            label14.Name = "label14";
            label14.Size = new Size(46, 15);
            label14.TabIndex = 19;
            label14.Text = "Reward";
            // 
            // reward
            // 
            reward.Location = new Point(274, 108);
            reward.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            reward.Name = "reward";
            reward.Size = new Size(121, 23);
            reward.TabIndex = 20;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(244, 83);
            label13.Name = "label13";
            label13.Size = new Size(25, 15);
            label13.TabIndex = 17;
            label13.Text = "Fee";
            // 
            // fee
            // 
            fee.Location = new Point(274, 79);
            fee.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            fee.Name = "fee";
            fee.Size = new Size(121, 23);
            fee.TabIndex = 18;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(237, 54);
            label12.Name = "label12";
            label12.Size = new Size(32, 15);
            label12.TabIndex = 16;
            label12.Text = "Stars";
            // 
            // starLvl
            // 
            starLvl.Location = new Point(274, 50);
            starLvl.Name = "starLvl";
            starLvl.Size = new Size(121, 23);
            starLvl.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(37, 138);
            label11.Name = "label11";
            label11.Size = new Size(34, 15);
            label11.TabIndex = 14;
            label11.Text = "Flags";
            // 
            // questFlags
            // 
            questFlags.Location = new Point(76, 135);
            questFlags.Name = "questFlags";
            questFlags.Size = new Size(121, 23);
            questFlags.TabIndex = 13;
            // 
            // questType
            // 
            questType.FormattingEnabled = true;
            questType.Location = new Point(76, 107);
            questType.Name = "questType";
            questType.Size = new Size(121, 23);
            questType.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(40, 110);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 11;
            label10.Text = "Type";
            // 
            // difficulty
            // 
            difficulty.FormattingEnabled = true;
            difficulty.Location = new Point(76, 23);
            difficulty.Name = "difficulty";
            difficulty.Size = new Size(121, 23);
            difficulty.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(228, 25);
            label9.Name = "label9";
            label9.Size = new Size(41, 15);
            label9.TabIndex = 8;
            label9.Text = "Locale";
            // 
            // locale
            // 
            locale.FormattingEnabled = true;
            locale.Location = new Point(274, 21);
            locale.Name = "locale";
            locale.Size = new Size(121, 23);
            locale.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(41, 82);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 6;
            label8.Text = "HRP";
            // 
            // hrp
            // 
            hrp.Location = new Point(76, 79);
            hrp.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            hrp.Name = "hrp";
            hrp.Size = new Size(121, 23);
            hrp.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(133, 55);
            label7.Name = "label7";
            label7.Size = new Size(17, 15);
            label7.TabIndex = 4;
            label7.Text = "%";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 55);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 3;
            label6.Text = "Boss Size";
            // 
            // bossSize
            // 
            bossSize.Location = new Point(76, 51);
            bossSize.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            bossSize.Name = "bossSize";
            bossSize.Size = new Size(52, 23);
            bossSize.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 26);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 1;
            label5.Text = "Difficulty";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 705);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true;
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(976, 677);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Location = new Point(369, 279);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(601, 392);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Rewards";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(supplyGrid);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(supplyQty);
            groupBox3.Controls.Add(supplyMon);
            groupBox3.Controls.Add(supplyType);
            groupBox3.Location = new Point(6, 279);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(357, 392);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Supply";
            // 
            // supplyGrid
            // 
            supplyGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            supplyGrid.Columns.AddRange(new DataGridViewColumn[] { itemNameSup, itemQtySup });
            supplyGrid.Location = new Point(6, 123);
            supplyGrid.Name = "supplyGrid";
            supplyGrid.Size = new Size(339, 263);
            supplyGrid.TabIndex = 13;
            // 
            // itemNameSup
            // 
            itemNameSup.HeaderText = "Name";
            itemNameSup.Name = "itemNameSup";
            itemNameSup.Width = 220;
            // 
            // itemQtySup
            // 
            itemQtySup.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            itemQtySup.HeaderText = "Amount";
            itemQtySup.Name = "itemQtySup";
            itemQtySup.Resizable = DataGridViewTriState.False;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(55, 96);
            label22.Name = "label22";
            label22.Size = new Size(51, 15);
            label22.TabIndex = 12;
            label22.Text = "Number";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(55, 68);
            label21.Name = "label21";
            label21.Size = new Size(51, 15);
            label21.TabIndex = 11;
            label21.Text = "Monster";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(30, 39);
            label20.Name = "label20";
            label20.Size = new Size(76, 15);
            label20.TabIndex = 10;
            label20.Text = "Delivery Type";
            // 
            // supplyQty
            // 
            supplyQty.Location = new Point(112, 94);
            supplyQty.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            supplyQty.Name = "supplyQty";
            supplyQty.Size = new Size(90, 23);
            supplyQty.TabIndex = 9;
            // 
            // supplyMon
            // 
            supplyMon.FormattingEnabled = true;
            supplyMon.Location = new Point(112, 65);
            supplyMon.Name = "supplyMon";
            supplyMon.Size = new Size(233, 23);
            supplyMon.TabIndex = 1;
            // 
            // supplyType
            // 
            supplyType.FormattingEnabled = true;
            supplyType.Location = new Point(112, 36);
            supplyType.Name = "supplyType";
            supplyType.Size = new Size(233, 23);
            supplyType.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(976, 677);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "MHG Quest Editor";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)id).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeLmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)cart).EndInit();
            ((System.ComponentModel.ISupportInitialize)reward).EndInit();
            ((System.ComponentModel.ISupportInitialize)fee).EndInit();
            ((System.ComponentModel.ISupportInitialize)starLvl).EndInit();
            ((System.ComponentModel.ISupportInitialize)hrp).EndInit();
            ((System.ComponentModel.ISupportInitialize)bossSize).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)supplyGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)supplyQty).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox questTitle;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox description;
        private Label label3;
        private TextBox failCond;
        private Label label2;
        private TextBox winCond;
        private Label label1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label6;
        private NumericUpDown bossSize;
        private Label label7;
        private Label label8;
        private NumericUpDown hrp;
        private ComboBox locale;
        private Label label9;
        private ComboBox difficulty;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label10;
        private ComboBox questType;
        private Label label11;
        private TextBox questFlags;
        private Label label12;
        private NumericUpDown starLvl;
        private Label label15;
        private NumericUpDown cart;
        private Label label14;
        private NumericUpDown reward;
        private Label label13;
        private NumericUpDown fee;
        private Label label16;
        private NumericUpDown timeLmt;
        private Label timeMins;
        private TextBox dataUnk;
        private Label label17;
        private NumericUpDown id;
        private Label label18;
        private TextBox qstCond;
        private Label label19;
        private GroupBox groupBox3;
        private ComboBox supplyType;
        private NumericUpDown supplyQty;
        private ComboBox supplyMon;
        private Label label22;
        private Label label21;
        private Label label20;
        private DataGridView supplyGrid;
        private DataGridViewComboBoxColumn itemNameSup;
        private DataGridViewTextBoxColumn itemQtySup;
        private GroupBox groupBox4;
    }
}
