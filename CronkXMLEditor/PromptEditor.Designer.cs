namespace CronkXMLEditor
{
    partial class PromptEditForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShopPromptShopSection = new System.Windows.Forms.ListBox();
            this.ShopPromptClearAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ShopPromptAppendPrompt = new System.Windows.Forms.Button();
            this.ShopPromptClearRecent = new System.Windows.Forms.Button();
            this.ShopPromptAddLine = new System.Windows.Forms.Button();
            this.ShopPromptNextLine = new System.Windows.Forms.TextBox();
            this.ShopPromptCharSel = new System.Windows.Forms.ListBox();
            this.ShopPromptCurPrompt = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ShopPromptShopSection);
            this.groupBox1.Controls.Add(this.ShopPromptClearAll);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ShopPromptAppendPrompt);
            this.groupBox1.Controls.Add(this.ShopPromptClearRecent);
            this.groupBox1.Controls.Add(this.ShopPromptAddLine);
            this.groupBox1.Controls.Add(this.ShopPromptNextLine);
            this.groupBox1.Controls.Add(this.ShopPromptCharSel);
            this.groupBox1.Controls.Add(this.ShopPromptCurPrompt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shop Prompt Text:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "ShopSection:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Character:";
            // 
            // ShopPromptShopSection
            // 
            this.ShopPromptShopSection.FormattingEnabled = true;
            this.ShopPromptShopSection.Items.AddRange(new object[] {
            "Weapons",
            "Armor",
            "Scrolls",
            "Consumables",
            "Talismans",
            "Sell",
            "Buyback"});
            this.ShopPromptShopSection.Location = new System.Drawing.Point(132, 292);
            this.ShopPromptShopSection.Name = "ShopPromptShopSection";
            this.ShopPromptShopSection.Size = new System.Drawing.Size(120, 95);
            this.ShopPromptShopSection.TabIndex = 14;
            // 
            // ShopPromptClearAll
            // 
            this.ShopPromptClearAll.Location = new System.Drawing.Point(123, 211);
            this.ShopPromptClearAll.Name = "ShopPromptClearAll";
            this.ShopPromptClearAll.Size = new System.Drawing.Size(92, 23);
            this.ShopPromptClearAll.TabIndex = 13;
            this.ShopPromptClearAll.Text = "Clear All Lines";
            this.ShopPromptClearAll.UseVisualStyleBackColor = true;
            this.ShopPromptClearAll.Click += new System.EventHandler(this.ShopPromptClearAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Next Line:";
            // 
            // ShopPromptAppendPrompt
            // 
            this.ShopPromptAppendPrompt.Location = new System.Drawing.Point(258, 364);
            this.ShopPromptAppendPrompt.Name = "ShopPromptAppendPrompt";
            this.ShopPromptAppendPrompt.Size = new System.Drawing.Size(124, 23);
            this.ShopPromptAppendPrompt.TabIndex = 11;
            this.ShopPromptAppendPrompt.Text = "Append to Prompt File";
            this.ShopPromptAppendPrompt.UseVisualStyleBackColor = true;
            this.ShopPromptAppendPrompt.Click += new System.EventHandler(this.ShopPromptAppendPrompt_Click);
            // 
            // ShopPromptClearRecent
            // 
            this.ShopPromptClearRecent.Location = new System.Drawing.Point(6, 211);
            this.ShopPromptClearRecent.Name = "ShopPromptClearRecent";
            this.ShopPromptClearRecent.Size = new System.Drawing.Size(111, 23);
            this.ShopPromptClearRecent.TabIndex = 10;
            this.ShopPromptClearRecent.Text = "Clear Recent Line";
            this.ShopPromptClearRecent.UseVisualStyleBackColor = true;
            this.ShopPromptClearRecent.Click += new System.EventHandler(this.ShopPromptClearRecent_Click);
            // 
            // ShopPromptAddLine
            // 
            this.ShopPromptAddLine.Location = new System.Drawing.Point(348, 250);
            this.ShopPromptAddLine.Name = "ShopPromptAddLine";
            this.ShopPromptAddLine.Size = new System.Drawing.Size(75, 23);
            this.ShopPromptAddLine.TabIndex = 9;
            this.ShopPromptAddLine.Text = "Add Line";
            this.ShopPromptAddLine.UseVisualStyleBackColor = true;
            this.ShopPromptAddLine.Click += new System.EventHandler(this.ShopPromptAddLine_Click);
            // 
            // ShopPromptNextLine
            // 
            this.ShopPromptNextLine.Location = new System.Drawing.Point(6, 253);
            this.ShopPromptNextLine.MaxLength = 65;
            this.ShopPromptNextLine.Name = "ShopPromptNextLine";
            this.ShopPromptNextLine.Size = new System.Drawing.Size(336, 20);
            this.ShopPromptNextLine.TabIndex = 8;
            // 
            // ShopPromptCharSel
            // 
            this.ShopPromptCharSel.FormattingEnabled = true;
            this.ShopPromptCharSel.Items.AddRange(new object[] {
            "Petaer",
            "Ziktofel",
            "Halephon",
            "Falsael"});
            this.ShopPromptCharSel.Location = new System.Drawing.Point(6, 292);
            this.ShopPromptCharSel.Name = "ShopPromptCharSel";
            this.ShopPromptCharSel.Size = new System.Drawing.Size(120, 95);
            this.ShopPromptCharSel.TabIndex = 7;
            // 
            // ShopPromptCurPrompt
            // 
            this.ShopPromptCurPrompt.FormattingEnabled = true;
            this.ShopPromptCurPrompt.Location = new System.Drawing.Point(6, 19);
            this.ShopPromptCurPrompt.Name = "ShopPromptCurPrompt";
            this.ShopPromptCurPrompt.Size = new System.Drawing.Size(336, 186);
            this.ShopPromptCurPrompt.TabIndex = 6;
            // 
            // PromptEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 420);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "PromptEditForm";
            this.Text = "PromptEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShopPromptAppendPrompt;
        private System.Windows.Forms.Button ShopPromptClearRecent;
        private System.Windows.Forms.Button ShopPromptAddLine;
        private System.Windows.Forms.TextBox ShopPromptNextLine;
        private System.Windows.Forms.ListBox ShopPromptCharSel;
        private System.Windows.Forms.ListBox ShopPromptCurPrompt;
        private System.Windows.Forms.Button ShopPromptClearAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ShopPromptShopSection;

    }
}