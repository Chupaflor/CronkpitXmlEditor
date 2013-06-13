namespace CronkXMLEditor
{
    partial class SpawnTableEditorForm
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
            this.family_spawnchance_listbox = new System.Windows.Forms.ListBox();
            this.spawnchance_listbox = new System.Windows.Forms.ListBox();
            this.mspawn_byfamily_listbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.monster_family_listbox = new System.Windows.Forms.ListBox();
            this.single_monster_listbox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.spawn_chance_numeric = new System.Windows.Forms.NumericUpDown();
            this.dungeon_listbox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbl_2_file_btn = new System.Windows.Forms.Button();
            this.item_2_tbl_btn = new System.Windows.Forms.Button();
            this.remove_item_btn = new System.Windows.Forms.Button();
            this.clear_tbl_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.floor_number_numeric = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spawn_chance_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor_number_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // family_spawnchance_listbox
            // 
            this.family_spawnchance_listbox.FormattingEnabled = true;
            this.family_spawnchance_listbox.Location = new System.Drawing.Point(15, 269);
            this.family_spawnchance_listbox.Name = "family_spawnchance_listbox";
            this.family_spawnchance_listbox.Size = new System.Drawing.Size(120, 108);
            this.family_spawnchance_listbox.TabIndex = 0;
            this.family_spawnchance_listbox.Click += new System.EventHandler(this.family_spawnchance_listbox_Click);
            // 
            // spawnchance_listbox
            // 
            this.spawnchance_listbox.FormattingEnabled = true;
            this.spawnchance_listbox.Location = new System.Drawing.Point(15, 424);
            this.spawnchance_listbox.Name = "spawnchance_listbox";
            this.spawnchance_listbox.Size = new System.Drawing.Size(120, 264);
            this.spawnchance_listbox.TabIndex = 1;
            // 
            // mspawn_byfamily_listbox
            // 
            this.mspawn_byfamily_listbox.FormattingEnabled = true;
            this.mspawn_byfamily_listbox.Location = new System.Drawing.Point(177, 269);
            this.mspawn_byfamily_listbox.Name = "mspawn_byfamily_listbox";
            this.mspawn_byfamily_listbox.Size = new System.Drawing.Size(120, 108);
            this.mspawn_byfamily_listbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monster Family Spawn Chance:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Monster Spawn Chance by Family:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Spawn Chance by Monster:";
            // 
            // monster_family_listbox
            // 
            this.monster_family_listbox.FormattingEnabled = true;
            this.monster_family_listbox.Items.AddRange(new object[] {
            "Skeleton",
            "Large_Undead",
            "Mimic",
            "Goredog",
            "Grendel",
            "Ghost",
            "Necromancer",
            "SpiritKnight",
            "Spirit",
            "Zombie"});
            this.monster_family_listbox.Location = new System.Drawing.Point(15, 25);
            this.monster_family_listbox.Name = "monster_family_listbox";
            this.monster_family_listbox.Size = new System.Drawing.Size(120, 225);
            this.monster_family_listbox.TabIndex = 6;
            this.monster_family_listbox.Click += new System.EventHandler(this.monster_family_listbox_Click);
            // 
            // single_monster_listbox
            // 
            this.single_monster_listbox.FormattingEnabled = true;
            this.single_monster_listbox.Items.AddRange(new object[] {
            "Armored_Skeleton",
            "Boneyard",
            "CorpseMimic",
            "Ghost",
            "GoldMimic",
            "GoreHound",
            "GoreWolf",
            "HollowKnight",
            "Necromancer",
            "RedKnight",
            "Skeleton",
            "VoidWraith",
            "Zombie",
            "ZombieFanatic"});
            this.single_monster_listbox.Location = new System.Drawing.Point(177, 25);
            this.single_monster_listbox.Name = "single_monster_listbox";
            this.single_monster_listbox.Size = new System.Drawing.Size(120, 225);
            this.single_monster_listbox.TabIndex = 7;
            this.single_monster_listbox.Click += new System.EventHandler(this.single_monster_listbox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Monster families:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Monsters:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 640);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "% Chance:";
            // 
            // spawn_chance_numeric
            // 
            this.spawn_chance_numeric.Location = new System.Drawing.Point(250, 656);
            this.spawn_chance_numeric.Name = "spawn_chance_numeric";
            this.spawn_chance_numeric.Size = new System.Drawing.Size(120, 20);
            this.spawn_chance_numeric.TabIndex = 11;
            // 
            // dungeon_listbox
            // 
            this.dungeon_listbox.FormattingEnabled = true;
            this.dungeon_listbox.Items.AddRange(new object[] {
            "Necropolis"});
            this.dungeon_listbox.Location = new System.Drawing.Point(179, 424);
            this.dungeon_listbox.Name = "dungeon_listbox";
            this.dungeon_listbox.Size = new System.Drawing.Size(120, 95);
            this.dungeon_listbox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 408);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Dungeon:";
            // 
            // tbl_2_file_btn
            // 
            this.tbl_2_file_btn.Location = new System.Drawing.Point(141, 682);
            this.tbl_2_file_btn.Name = "tbl_2_file_btn";
            this.tbl_2_file_btn.Size = new System.Drawing.Size(103, 23);
            this.tbl_2_file_btn.TabIndex = 14;
            this.tbl_2_file_btn.Text = "Add Table to File";
            this.tbl_2_file_btn.UseVisualStyleBackColor = true;
            this.tbl_2_file_btn.Click += new System.EventHandler(this.tbl_2_file_btn_Click);
            // 
            // item_2_tbl_btn
            // 
            this.item_2_tbl_btn.Location = new System.Drawing.Point(141, 653);
            this.item_2_tbl_btn.Name = "item_2_tbl_btn";
            this.item_2_tbl_btn.Size = new System.Drawing.Size(103, 23);
            this.item_2_tbl_btn.TabIndex = 15;
            this.item_2_tbl_btn.Text = "Add To Table";
            this.item_2_tbl_btn.UseVisualStyleBackColor = true;
            this.item_2_tbl_btn.Click += new System.EventHandler(this.item_2_tbl_btn_Click);
            // 
            // remove_item_btn
            // 
            this.remove_item_btn.Location = new System.Drawing.Point(141, 624);
            this.remove_item_btn.Name = "remove_item_btn";
            this.remove_item_btn.Size = new System.Drawing.Size(103, 23);
            this.remove_item_btn.TabIndex = 16;
            this.remove_item_btn.Text = "Remove Item";
            this.remove_item_btn.UseVisualStyleBackColor = true;
            // 
            // clear_tbl_btn
            // 
            this.clear_tbl_btn.Location = new System.Drawing.Point(141, 595);
            this.clear_tbl_btn.Name = "clear_tbl_btn";
            this.clear_tbl_btn.Size = new System.Drawing.Size(103, 23);
            this.clear_tbl_btn.TabIndex = 17;
            this.clear_tbl_btn.Text = "Clear Table";
            this.clear_tbl_btn.UseVisualStyleBackColor = true;
            this.clear_tbl_btn.Click += new System.EventHandler(this.clear_tbl_btn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 522);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Floor:";
            // 
            // floor_number_numeric
            // 
            this.floor_number_numeric.Location = new System.Drawing.Point(179, 538);
            this.floor_number_numeric.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.floor_number_numeric.Name = "floor_number_numeric";
            this.floor_number_numeric.Size = new System.Drawing.Size(120, 20);
            this.floor_number_numeric.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Total: 0%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 691);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Total: 0%";
            // 
            // SpawnTableEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 717);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.floor_number_numeric);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.clear_tbl_btn);
            this.Controls.Add(this.remove_item_btn);
            this.Controls.Add(this.item_2_tbl_btn);
            this.Controls.Add(this.tbl_2_file_btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dungeon_listbox);
            this.Controls.Add(this.spawn_chance_numeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.single_monster_listbox);
            this.Controls.Add(this.monster_family_listbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mspawn_byfamily_listbox);
            this.Controls.Add(this.spawnchance_listbox);
            this.Controls.Add(this.family_spawnchance_listbox);
            this.Name = "SpawnTableEditorForm";
            this.Text = "SpawnTableEditorForm";
            ((System.ComponentModel.ISupportInitialize)(this.spawn_chance_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floor_number_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox family_spawnchance_listbox;
        private System.Windows.Forms.ListBox spawnchance_listbox;
        private System.Windows.Forms.ListBox mspawn_byfamily_listbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox monster_family_listbox;
        private System.Windows.Forms.ListBox single_monster_listbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown spawn_chance_numeric;
        private System.Windows.Forms.ListBox dungeon_listbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button tbl_2_file_btn;
        private System.Windows.Forms.Button item_2_tbl_btn;
        private System.Windows.Forms.Button remove_item_btn;
        private System.Windows.Forms.Button clear_tbl_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown floor_number_numeric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}