namespace TCG_UML
{
    partial class MainGUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.FileMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewProjectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.FileMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileMenuStrip
            // 
            this.FileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu});
            this.FileMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FileMenuStrip.MdiWindowListItem = this.FileMenu;
            this.FileMenuStrip.Name = "FileMenuStrip";
            this.FileMenuStrip.Size = new System.Drawing.Size(1485, 24);
            this.FileMenuStrip.TabIndex = 1;
            this.FileMenuStrip.Text = "FileMenuStrip";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewMenu,
            this.FileOpenMenu});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // FileNewMenu
            // 
            this.FileNewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewProjectMenu});
            this.FileNewMenu.Name = "FileNewMenu";
            this.FileNewMenu.Size = new System.Drawing.Size(152, 22);
            this.FileNewMenu.Text = "New";
            // 
            // FileNewProjectMenu
            // 
            this.FileNewProjectMenu.Name = "FileNewProjectMenu";
            this.FileNewProjectMenu.Size = new System.Drawing.Size(152, 22);
            this.FileNewProjectMenu.Text = "Project";
            this.FileNewProjectMenu.Click += new System.EventHandler(this.FileNewProjectMenu_Click);
            // 
            // FileOpenMenu
            // 
            this.FileOpenMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOpenProject});
            this.FileOpenMenu.Name = "FileOpenMenu";
            this.FileOpenMenu.Size = new System.Drawing.Size(152, 22);
            this.FileOpenMenu.Text = "Open";
            // 
            // FileOpenProject
            // 
            this.FileOpenProject.Name = "FileOpenProject";
            this.FileOpenProject.Size = new System.Drawing.Size(116, 22);
            this.FileOpenProject.Text = "¨Project";
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(192, 27);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(719, 426);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 3;
            this.PictureBox.TabStop = false;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 569);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FileMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.FileMenuStrip;
            this.Name = "MainGUI";
            this.Text = "TCG_UML";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FileMenuStrip.ResumeLayout(false);
            this.FileMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip FileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem FileNewMenu;
        private System.Windows.Forms.ToolStripMenuItem FileNewProjectMenu;
        private System.Windows.Forms.ToolStripMenuItem FileOpenMenu;
        private System.Windows.Forms.ToolStripMenuItem FileOpenProject;
        private System.Windows.Forms.PictureBox PictureBox;
    }
}

