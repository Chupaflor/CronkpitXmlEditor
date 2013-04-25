namespace CronkXMLEditor
{
    partial class DungeonDesignerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.specific_rooms_chkbox = new System.Windows.Forms.CheckBox();
            this.clear_btn = new System.Windows.Forms.Button();
            this.append_btn = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.crooms_listbox = new System.Windows.Forms.ListBox();
            this.roomtype_listbox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roomQuant_numeric = new System.Windows.Forms.NumericUpDown();
            this.floor_numeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dungeon_listbox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomQuant_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.specific_rooms_chkbox);
            this.groupBox1.Controls.Add(this.clear_btn);
            this.groupBox1.Controls.Add(this.append_btn);
            this.groupBox1.Controls.Add(this.remove_btn);
            this.groupBox1.Controls.Add(this.add_btn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.crooms_listbox);
            this.groupBox1.Controls.Add(this.roomtype_listbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.roomQuant_numeric);
            this.groupBox1.Controls.Add(this.floor_numeric);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dungeon_listbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dungeon Theme Designer:";
            // 
            // specific_rooms_chkbox
            // 
            this.specific_rooms_chkbox.AutoSize = true;
            this.specific_rooms_chkbox.Location = new System.Drawing.Point(132, 195);
            this.specific_rooms_chkbox.Name = "specific_rooms_chkbox";
            this.specific_rooms_chkbox.Size = new System.Drawing.Size(100, 17);
            this.specific_rooms_chkbox.TabIndex = 26;
            this.specific_rooms_chkbox.Text = "Specific Rooms";
            this.specific_rooms_chkbox.UseVisualStyleBackColor = true;
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(329, 205);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_btn.TabIndex = 25;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // append_btn
            // 
            this.append_btn.Location = new System.Drawing.Point(329, 234);
            this.append_btn.Name = "append_btn";
            this.append_btn.Size = new System.Drawing.Size(75, 23);
            this.append_btn.TabIndex = 24;
            this.append_btn.Text = "Append";
            this.append_btn.UseVisualStyleBackColor = true;
            this.append_btn.Click += new System.EventHandler(this.append_btn_Click);
            // 
            // remove_btn
            // 
            this.remove_btn.Location = new System.Drawing.Point(329, 176);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(75, 23);
            this.remove_btn.TabIndex = 23;
            this.remove_btn.Text = "Remove";
            this.remove_btn.UseVisualStyleBackColor = true;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(132, 218);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(75, 23);
            this.add_btn.TabIndex = 22;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Current Items:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Room Quantity:";
            // 
            // crooms_listbox
            // 
            this.crooms_listbox.FormattingEnabled = true;
            this.crooms_listbox.Location = new System.Drawing.Point(258, 71);
            this.crooms_listbox.Name = "crooms_listbox";
            this.crooms_listbox.Size = new System.Drawing.Size(146, 95);
            this.crooms_listbox.TabIndex = 19;
            // 
            // roomtype_listbox
            // 
            this.roomtype_listbox.FormattingEnabled = true;
            this.roomtype_listbox.Items.AddRange(new object[] {
            "Gorehound Kennels",
            "Library",
            "Darkroom",
            "Corpse Storage",
            "Sewer",
            "Rubble Room",
            "Knight Armory",
            "Sewer Shaft",
            "Jail",
            "Chasm",
            "Mine Shaft",
            "River",
            "Lake"});
            this.roomtype_listbox.Location = new System.Drawing.Point(6, 146);
            this.roomtype_listbox.Name = "roomtype_listbox";
            this.roomtype_listbox.Size = new System.Drawing.Size(120, 95);
            this.roomtype_listbox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Room Type:";
            // 
            // roomQuant_numeric
            // 
            this.roomQuant_numeric.Location = new System.Drawing.Point(132, 146);
            this.roomQuant_numeric.Name = "roomQuant_numeric";
            this.roomQuant_numeric.Size = new System.Drawing.Size(120, 20);
            this.roomQuant_numeric.TabIndex = 16;
            // 
            // floor_numeric
            // 
            this.floor_numeric.Location = new System.Drawing.Point(258, 32);
            this.floor_numeric.Name = "floor_numeric";
            this.floor_numeric.Size = new System.Drawing.Size(120, 20);
            this.floor_numeric.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Floor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Dungeon:";
            // 
            // dungeon_listbox
            // 
            this.dungeon_listbox.FormattingEnabled = true;
            this.dungeon_listbox.Items.AddRange(new object[] {
            "Necropolis",
            "Gelid Peaks",
            "Flamerunner Mine",
            "Sunken Citadel"});
            this.dungeon_listbox.Location = new System.Drawing.Point(6, 32);
            this.dungeon_listbox.Name = "dungeon_listbox";
            this.dungeon_listbox.Size = new System.Drawing.Size(120, 95);
            this.dungeon_listbox.TabIndex = 12;
            // 
            // DungeonDesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 287);
            this.Controls.Add(this.groupBox1);
            this.Name = "DungeonDesignerForm";
            this.Text = "DungeonDesignerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomQuant_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor_numeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox crooms_listbox;
        private System.Windows.Forms.ListBox roomtype_listbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown roomQuant_numeric;
        private System.Windows.Forms.NumericUpDown floor_numeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox dungeon_listbox;
        private System.Windows.Forms.Button append_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.CheckBox specific_rooms_chkbox;

    }
}