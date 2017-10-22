namespace WindowsFormsCSE.GUI
{
    partial class ImageAnalysisMenu
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
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tesseractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.croppedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ironOCRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.croppedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Location = new System.Drawing.Point(370, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(322, 420);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 420);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ocrToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ocrToolStripMenuItem
            // 
            this.ocrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tesseractToolStripMenuItem,
            this.ironOCRToolStripMenuItem});
            this.ocrToolStripMenuItem.Name = "ocrToolStripMenuItem";
            this.ocrToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.ocrToolStripMenuItem.Text = "Ocr";
            // 
            // tesseractToolStripMenuItem
            // 
            this.tesseractToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullImageToolStripMenuItem,
            this.croppedToolStripMenuItem});
            this.tesseractToolStripMenuItem.Name = "tesseractToolStripMenuItem";
            this.tesseractToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.tesseractToolStripMenuItem.Text = "Tesseract";
            // 
            // fullImageToolStripMenuItem
            // 
            this.fullImageToolStripMenuItem.Name = "fullImageToolStripMenuItem";
            this.fullImageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.fullImageToolStripMenuItem.Text = "Full Image";
            this.fullImageToolStripMenuItem.Click += new System.EventHandler(this.FullImageToolStripMenuItem_Click);
            // 
            // croppedToolStripMenuItem
            // 
            this.croppedToolStripMenuItem.Name = "croppedToolStripMenuItem";
            this.croppedToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.croppedToolStripMenuItem.Text = "Cropped Image";
            this.croppedToolStripMenuItem.Click += new System.EventHandler(this.CroppedToolStripMenuItem_Click);
            // 
            // ironOCRToolStripMenuItem
            // 
            this.ironOCRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullImageToolStripMenuItem1,
            this.croppedImageToolStripMenuItem});
            this.ironOCRToolStripMenuItem.Name = "ironOCRToolStripMenuItem";
            this.ironOCRToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.ironOCRToolStripMenuItem.Text = "IronOCR";
            // 
            // fullImageToolStripMenuItem1
            // 
            this.fullImageToolStripMenuItem1.Name = "fullImageToolStripMenuItem1";
            this.fullImageToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.fullImageToolStripMenuItem1.Text = "Full Image";
            this.fullImageToolStripMenuItem1.Click += new System.EventHandler(this.FullImageToolStripMenuItem1_Click);
            // 
            // croppedImageToolStripMenuItem
            // 
            this.croppedImageToolStripMenuItem.Name = "croppedImageToolStripMenuItem";
            this.croppedImageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.croppedImageToolStripMenuItem.Text = "Cropped Image";
            this.croppedImageToolStripMenuItem.Click += new System.EventHandler(this.CroppedImageToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(698, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(352, 420);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1062, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel1.Text = "Open Image";
            // 
            // ImageAnalysisMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1062, 472);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageAnalysisMenu";
            this.ShowIcon = false;
            this.Text = "Image Analysis Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tesseractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ironOCRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem croppedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem croppedImageToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}