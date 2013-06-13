namespace CronkXMLEditor
{
    partial class MDIMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classDescriptionEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonThemeDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonRoomDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopPromptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spawnTableEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.windowsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemWindowToolStripMenuItem,
            this.classDescriptionEditorToolStripMenuItem,
            this.dungeonThemeDesignerToolStripMenuItem,
            this.dungeonRoomDesignerToolStripMenuItem,
            this.shopPromptsToolStripMenuItem,
            this.spawnTableEditorToolStripMenuItem,
            this.toolStripSeparator2,
            this.cascadeToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(68, 20);
            this.windowsMenu.Text = "&Windows";
            // 
            // itemWindowToolStripMenuItem
            // 
            this.itemWindowToolStripMenuItem.Name = "itemWindowToolStripMenuItem";
            this.itemWindowToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.itemWindowToolStripMenuItem.Text = "Item Editor";
            this.itemWindowToolStripMenuItem.Click += new System.EventHandler(this.itemWindowToolStripMenuItem_Click);
            // 
            // classDescriptionEditorToolStripMenuItem
            // 
            this.classDescriptionEditorToolStripMenuItem.Name = "classDescriptionEditorToolStripMenuItem";
            this.classDescriptionEditorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.classDescriptionEditorToolStripMenuItem.Text = "Class Description Editor";
            this.classDescriptionEditorToolStripMenuItem.Click += new System.EventHandler(this.classDescriptionEditorToolStripMenuItem_Click);
            // 
            // dungeonThemeDesignerToolStripMenuItem
            // 
            this.dungeonThemeDesignerToolStripMenuItem.Name = "dungeonThemeDesignerToolStripMenuItem";
            this.dungeonThemeDesignerToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.dungeonThemeDesignerToolStripMenuItem.Text = "&Dungeon Theme Designer";
            this.dungeonThemeDesignerToolStripMenuItem.Click += new System.EventHandler(this.dungeonThemeDesignerToolStripMenuItem_Click);
            // 
            // dungeonRoomDesignerToolStripMenuItem
            // 
            this.dungeonRoomDesignerToolStripMenuItem.Name = "dungeonRoomDesignerToolStripMenuItem";
            this.dungeonRoomDesignerToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.dungeonRoomDesignerToolStripMenuItem.Text = "Dungeon &Room Designer";
            this.dungeonRoomDesignerToolStripMenuItem.Click += new System.EventHandler(this.dungeonRoomDesignerToolStripMenuItem_Click);
            // 
            // shopPromptsToolStripMenuItem
            // 
            this.shopPromptsToolStripMenuItem.Name = "shopPromptsToolStripMenuItem";
            this.shopPromptsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.shopPromptsToolStripMenuItem.Text = "Shop Prompt Editor";
            this.shopPromptsToolStripMenuItem.Click += new System.EventHandler(this.shopPromptsToolStripMenuItem_Click);
            // 
            // spawnTableEditorToolStripMenuItem
            // 
            this.spawnTableEditorToolStripMenuItem.Name = "spawnTableEditorToolStripMenuItem";
            this.spawnTableEditorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.spawnTableEditorToolStripMenuItem.Text = "&Spawn Table Editor";
            this.spawnTableEditorToolStripMenuItem.Click += new System.EventHandler(this.spawnTableEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIMain";
            this.Text = "Cronkpit XML Editor Terminal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem itemWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem shopPromptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classDescriptionEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonThemeDesignerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonRoomDesignerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spawnTableEditorToolStripMenuItem;
    }
}



