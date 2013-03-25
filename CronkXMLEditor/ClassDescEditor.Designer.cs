namespace CronkXMLEditor
{
    partial class ClassDescEditor
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
            this.ClassDescAppend = new System.Windows.Forms.Button();
            this.ClassDescNextLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClassAddLine = new System.Windows.Forms.Button();
            this.ClassRemoveLine = new System.Windows.Forms.Button();
            this.ClassDescClass = new System.Windows.Forms.ListBox();
            this.ClassDescLines = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClassDescAppend);
            this.groupBox1.Controls.Add(this.ClassDescNextLine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ClassAddLine);
            this.groupBox1.Controls.Add(this.ClassRemoveLine);
            this.groupBox1.Controls.Add(this.ClassDescClass);
            this.groupBox1.Controls.Add(this.ClassDescLines);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 370);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Class Description:";
            // 
            // ClassDescAppend
            // 
            this.ClassDescAppend.Location = new System.Drawing.Point(132, 338);
            this.ClassDescAppend.Name = "ClassDescAppend";
            this.ClassDescAppend.Size = new System.Drawing.Size(75, 23);
            this.ClassDescAppend.TabIndex = 14;
            this.ClassDescAppend.Text = "Append";
            this.ClassDescAppend.UseVisualStyleBackColor = true;
            this.ClassDescAppend.Click += new System.EventHandler(this.ClassDescAppend_Click);
            // 
            // ClassDescNextLine
            // 
            this.ClassDescNextLine.Location = new System.Drawing.Point(6, 266);
            this.ClassDescNextLine.MaxLength = 30;
            this.ClassDescNextLine.Name = "ClassDescNextLine";
            this.ClassDescNextLine.Size = new System.Drawing.Size(228, 20);
            this.ClassDescNextLine.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Line:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Class:";
            // 
            // ClassAddLine
            // 
            this.ClassAddLine.Location = new System.Drawing.Point(104, 224);
            this.ClassAddLine.Name = "ClassAddLine";
            this.ClassAddLine.Size = new System.Drawing.Size(75, 23);
            this.ClassAddLine.TabIndex = 10;
            this.ClassAddLine.Text = "Add Line";
            this.ClassAddLine.UseVisualStyleBackColor = true;
            this.ClassAddLine.Click += new System.EventHandler(this.ClassAddLine_Click);
            // 
            // ClassRemoveLine
            // 
            this.ClassRemoveLine.Location = new System.Drawing.Point(6, 224);
            this.ClassRemoveLine.Name = "ClassRemoveLine";
            this.ClassRemoveLine.Size = new System.Drawing.Size(92, 23);
            this.ClassRemoveLine.TabIndex = 9;
            this.ClassRemoveLine.Text = "Remove Line";
            this.ClassRemoveLine.UseVisualStyleBackColor = true;
            this.ClassRemoveLine.Click += new System.EventHandler(this.ClassRemoveLine_Click);
            // 
            // ClassDescClass
            // 
            this.ClassDescClass.FormattingEnabled = true;
            this.ClassDescClass.Items.AddRange(new object[] {
            "Warrior",
            "Rogue",
            "Mage",
            "ExPriest"});
            this.ClassDescClass.Location = new System.Drawing.Point(6, 305);
            this.ClassDescClass.Name = "ClassDescClass";
            this.ClassDescClass.Size = new System.Drawing.Size(120, 56);
            this.ClassDescClass.TabIndex = 8;
            // 
            // ClassDescLines
            // 
            this.ClassDescLines.FormattingEnabled = true;
            this.ClassDescLines.Location = new System.Drawing.Point(6, 19);
            this.ClassDescLines.Name = "ClassDescLines";
            this.ClassDescLines.Size = new System.Drawing.Size(228, 199);
            this.ClassDescLines.TabIndex = 7;
            // 
            // ClassDescEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 396);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ClassDescEditor";
            this.Text = "ClassDescEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ClassDescAppend;
        private System.Windows.Forms.TextBox ClassDescNextLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClassAddLine;
        private System.Windows.Forms.Button ClassRemoveLine;
        private System.Windows.Forms.ListBox ClassDescClass;
        private System.Windows.Forms.ListBox ClassDescLines;

    }
}