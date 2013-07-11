namespace CronkXMLEditor
{
    partial class FeatureSpecificerForm
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
            this.river_type_listbox = new System.Windows.Forms.ListBox();
            this.start_x_numeric = new System.Windows.Forms.NumericUpDown();
            this.start_y_numeric = new System.Windows.Forms.NumericUpDown();
            this.end_x_numeric = new System.Windows.Forms.NumericUpDown();
            this.rocksbanks_thk_numeric = new System.Windows.Forms.NumericUpDown();
            this.shoreshallow_thk_numeric = new System.Windows.Forms.NumericUpDown();
            this.shallowdeep_thk_numeric = new System.Windows.Forms.NumericUpDown();
            this.end_y_numeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.add_lake_btn = new System.Windows.Forms.Button();
            this.add_river_btn = new System.Windows.Forms.Button();
            this.dungeon_listbox = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.floor_depth_numeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.start_x_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_y_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_x_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rocksbanks_thk_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoreshallow_thk_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shallowdeep_thk_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_y_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor_depth_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // river_type_listbox
            // 
            this.river_type_listbox.FormattingEnabled = true;
            this.river_type_listbox.Items.AddRange(new object[] {
            "NonRiver",
            "Sewage",
            "Normal"});
            this.river_type_listbox.Location = new System.Drawing.Point(12, 25);
            this.river_type_listbox.Name = "river_type_listbox";
            this.river_type_listbox.Size = new System.Drawing.Size(73, 95);
            this.river_type_listbox.TabIndex = 1;
            // 
            // start_x_numeric
            // 
            this.start_x_numeric.Location = new System.Drawing.Point(127, 260);
            this.start_x_numeric.Name = "start_x_numeric";
            this.start_x_numeric.Size = new System.Drawing.Size(51, 20);
            this.start_x_numeric.TabIndex = 2;
            // 
            // start_y_numeric
            // 
            this.start_y_numeric.Location = new System.Drawing.Point(127, 286);
            this.start_y_numeric.Name = "start_y_numeric";
            this.start_y_numeric.Size = new System.Drawing.Size(51, 20);
            this.start_y_numeric.TabIndex = 3;
            // 
            // end_x_numeric
            // 
            this.end_x_numeric.Location = new System.Drawing.Point(127, 312);
            this.end_x_numeric.Name = "end_x_numeric";
            this.end_x_numeric.Size = new System.Drawing.Size(51, 20);
            this.end_x_numeric.TabIndex = 4;
            // 
            // rocksbanks_thk_numeric
            // 
            this.rocksbanks_thk_numeric.Location = new System.Drawing.Point(161, 131);
            this.rocksbanks_thk_numeric.Name = "rocksbanks_thk_numeric";
            this.rocksbanks_thk_numeric.Size = new System.Drawing.Size(60, 20);
            this.rocksbanks_thk_numeric.TabIndex = 5;
            // 
            // shoreshallow_thk_numeric
            // 
            this.shoreshallow_thk_numeric.Location = new System.Drawing.Point(161, 157);
            this.shoreshallow_thk_numeric.Name = "shoreshallow_thk_numeric";
            this.shoreshallow_thk_numeric.Size = new System.Drawing.Size(60, 20);
            this.shoreshallow_thk_numeric.TabIndex = 6;
            // 
            // shallowdeep_thk_numeric
            // 
            this.shallowdeep_thk_numeric.Location = new System.Drawing.Point(161, 183);
            this.shallowdeep_thk_numeric.Name = "shallowdeep_thk_numeric";
            this.shallowdeep_thk_numeric.Size = new System.Drawing.Size(60, 20);
            this.shallowdeep_thk_numeric.TabIndex = 7;
            // 
            // end_y_numeric
            // 
            this.end_y_numeric.Location = new System.Drawing.Point(127, 338);
            this.end_y_numeric.Name = "end_y_numeric";
            this.end_y_numeric.Size = new System.Drawing.Size(51, 20);
            this.end_y_numeric.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "River Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Start Coordinate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Shallows / Deep Thickness:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Rock / Banks Thickness:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Shore / Shallows Thickness:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "End Coordinate:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Y:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "X:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(104, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "X:";
            // 
            // add_lake_btn
            // 
            this.add_lake_btn.Location = new System.Drawing.Point(93, 364);
            this.add_lake_btn.Name = "add_lake_btn";
            this.add_lake_btn.Size = new System.Drawing.Size(75, 23);
            this.add_lake_btn.TabIndex = 20;
            this.add_lake_btn.Text = "Add Lake";
            this.add_lake_btn.UseVisualStyleBackColor = true;
            this.add_lake_btn.Click += new System.EventHandler(this.add_lake_btn_Click);
            // 
            // add_river_btn
            // 
            this.add_river_btn.Location = new System.Drawing.Point(12, 364);
            this.add_river_btn.Name = "add_river_btn";
            this.add_river_btn.Size = new System.Drawing.Size(75, 23);
            this.add_river_btn.TabIndex = 21;
            this.add_river_btn.Text = "Add River";
            this.add_river_btn.UseVisualStyleBackColor = true;
            this.add_river_btn.Click += new System.EventHandler(this.add_river_btn_Click);
            // 
            // dungeon_listbox
            // 
            this.dungeon_listbox.FormattingEnabled = true;
            this.dungeon_listbox.Items.AddRange(new object[] {
            "Necropolis"});
            this.dungeon_listbox.Location = new System.Drawing.Point(91, 25);
            this.dungeon_listbox.Name = "dungeon_listbox";
            this.dungeon_listbox.Size = new System.Drawing.Size(120, 95);
            this.dungeon_listbox.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(88, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Dungeon:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(62, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Floor:";
            // 
            // floor_depth_numeric
            // 
            this.floor_depth_numeric.Location = new System.Drawing.Point(101, 209);
            this.floor_depth_numeric.Name = "floor_depth_numeric";
            this.floor_depth_numeric.Size = new System.Drawing.Size(120, 20);
            this.floor_depth_numeric.TabIndex = 26;
            // 
            // FeatureSpecificerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 398);
            this.Controls.Add(this.floor_depth_numeric);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dungeon_listbox);
            this.Controls.Add(this.add_river_btn);
            this.Controls.Add(this.add_lake_btn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.end_y_numeric);
            this.Controls.Add(this.shallowdeep_thk_numeric);
            this.Controls.Add(this.shoreshallow_thk_numeric);
            this.Controls.Add(this.rocksbanks_thk_numeric);
            this.Controls.Add(this.end_x_numeric);
            this.Controls.Add(this.start_y_numeric);
            this.Controls.Add(this.start_x_numeric);
            this.Controls.Add(this.river_type_listbox);
            this.Name = "FeatureSpecificerForm";
            this.Text = "FeatureSpecificerForm";
            ((System.ComponentModel.ISupportInitialize)(this.start_x_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_y_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_x_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rocksbanks_thk_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoreshallow_thk_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shallowdeep_thk_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_y_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor_depth_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox river_type_listbox;
        private System.Windows.Forms.NumericUpDown start_x_numeric;
        private System.Windows.Forms.NumericUpDown start_y_numeric;
        private System.Windows.Forms.NumericUpDown end_x_numeric;
        private System.Windows.Forms.NumericUpDown rocksbanks_thk_numeric;
        private System.Windows.Forms.NumericUpDown shoreshallow_thk_numeric;
        private System.Windows.Forms.NumericUpDown shallowdeep_thk_numeric;
        private System.Windows.Forms.NumericUpDown end_y_numeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button add_lake_btn;
        private System.Windows.Forms.Button add_river_btn;
        private System.Windows.Forms.ListBox dungeon_listbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown floor_depth_numeric;
    }
}