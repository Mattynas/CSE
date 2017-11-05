namespace shopGuru.GUI
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
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printItemListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.textBox1.Location = new System.Drawing.Point(493, 33);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(428, 516);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(469, 517);
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
            this.imageToolStripMenuItem,
            this.ocrToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1416, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateImageToolStripMenuItem,
            this.analyseTextToolStripMenuItem,
            this.printItemListToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.imageToolStripMenuItem.Text = "Edit";
            // 
            // rotateImageToolStripMenuItem
            // 
            this.rotateImageToolStripMenuItem.Name = "rotateImageToolStripMenuItem";
            this.rotateImageToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.rotateImageToolStripMenuItem.Text = "Rotate Image";
            this.rotateImageToolStripMenuItem.Click += new System.EventHandler(this.rotateImageToolStripMenuItem_Click);
            // 
            // analyseTextToolStripMenuItem
            // 
            this.analyseTextToolStripMenuItem.Name = "analyseTextToolStripMenuItem";
            this.analyseTextToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.analyseTextToolStripMenuItem.Text = "Analyse Text";
            this.analyseTextToolStripMenuItem.Click += new System.EventHandler(this.AnalyseTextToolStripMenuItem_Click);
            // 
            // printItemListToolStripMenuItem
            // 
            this.printItemListToolStripMenuItem.Name = "printItemListToolStripMenuItem";
            this.printItemListToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.printItemListToolStripMenuItem.Text = "Print Item List";
            this.printItemListToolStripMenuItem.Click += new System.EventHandler(this.printItemListToolStripMenuItem_Click);
            // 
            // ocrToolStripMenuItem
            // 
            this.ocrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tesseractToolStripMenuItem,
            this.ironOCRToolStripMenuItem});
            this.ocrToolStripMenuItem.Name = "ocrToolStripMenuItem";
            this.ocrToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.ocrToolStripMenuItem.Text = "Ocr";
            // 
            // tesseractToolStripMenuItem
            // 
            this.tesseractToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullImageToolStripMenuItem,
            this.croppedToolStripMenuItem});
            this.tesseractToolStripMenuItem.Name = "tesseractToolStripMenuItem";
            this.tesseractToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.tesseractToolStripMenuItem.Text = "Tesseract";
            // 
            // fullImageToolStripMenuItem
            // 
            this.fullImageToolStripMenuItem.Name = "fullImageToolStripMenuItem";
            this.fullImageToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.fullImageToolStripMenuItem.Text = "Full Image";
            this.fullImageToolStripMenuItem.Click += new System.EventHandler(this.FullImageToolStripMenuItem_Click);
            // 
            // croppedToolStripMenuItem
            // 
            this.croppedToolStripMenuItem.Name = "croppedToolStripMenuItem";
            this.croppedToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.croppedToolStripMenuItem.Text = "Cropped Image";
            this.croppedToolStripMenuItem.Click += new System.EventHandler(this.CroppedToolStripMenuItem_Click);
            // 
            // ironOCRToolStripMenuItem
            // 
            this.ironOCRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullImageToolStripMenuItem1,
            this.croppedImageToolStripMenuItem});
            this.ironOCRToolStripMenuItem.Name = "ironOCRToolStripMenuItem";
            this.ironOCRToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.ironOCRToolStripMenuItem.Text = "IronOCR";
            // 
            // fullImageToolStripMenuItem1
            // 
            this.fullImageToolStripMenuItem1.Name = "fullImageToolStripMenuItem1";
            this.fullImageToolStripMenuItem1.Size = new System.Drawing.Size(188, 26);
            this.fullImageToolStripMenuItem1.Text = "Full Image";
            this.fullImageToolStripMenuItem1.Click += new System.EventHandler(this.FullImageToolStripMenuItem1_Click);
            // 
            // croppedImageToolStripMenuItem
            // 
            this.croppedImageToolStripMenuItem.Name = "croppedImageToolStripMenuItem";
            this.croppedImageToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.croppedImageToolStripMenuItem.Text = "Cropped Image";
            this.croppedImageToolStripMenuItem.Click += new System.EventHandler(this.CroppedImageToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(931, 33);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(469, 517);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1416, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 20);
            this.toolStripStatusLabel1.Text = "Open Image";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // ImageAnalysisMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1416, 581);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImageAnalysisMenu";
            this.ShowIcon = false;
            this.Text = "Image Analysis Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageAnalysisMenu_FormClosed);
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
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printItemListToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}