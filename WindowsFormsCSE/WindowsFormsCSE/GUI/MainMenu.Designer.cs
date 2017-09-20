namespace WindowsFormsCSE
{
    partial class MainMenu
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
            this.openfileButton = new System.Windows.Forms.Button();
            this.findPricesButton = new System.Windows.Forms.Button();
            this.userStatsButton = new System.Windows.Forms.Button();
            this.userSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openfileButton
            // 
            this.openfileButton.Location = new System.Drawing.Point(125, 11);
            this.openfileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openfileButton.Name = "openfileButton";
            this.openfileButton.Size = new System.Drawing.Size(112, 69);
            this.openfileButton.TabIndex = 0;
            this.openfileButton.Text = "Browse file";
            this.openfileButton.UseVisualStyleBackColor = true;
            this.openfileButton.Click += new System.EventHandler(this.openfileButton_Click);
            // 
            // findPricesButton
            // 
            this.findPricesButton.Location = new System.Drawing.Point(125, 99);
            this.findPricesButton.Name = "findPricesButton";
            this.findPricesButton.Size = new System.Drawing.Size(112, 23);
            this.findPricesButton.TabIndex = 1;
            this.findPricesButton.Text = "Find prices";
            this.findPricesButton.UseVisualStyleBackColor = true;
            // 
            // userStatsButton
            // 
            this.userStatsButton.Location = new System.Drawing.Point(125, 128);
            this.userStatsButton.Name = "userStatsButton";
            this.userStatsButton.Size = new System.Drawing.Size(112, 23);
            this.userStatsButton.TabIndex = 2;
            this.userStatsButton.Text = "User stats";
            this.userStatsButton.UseVisualStyleBackColor = true;
            // 
            // userSettingsButton
            // 
            this.userSettingsButton.Location = new System.Drawing.Point(125, 157);
            this.userSettingsButton.Name = "userSettingsButton";
            this.userSettingsButton.Size = new System.Drawing.Size(112, 23);
            this.userSettingsButton.TabIndex = 3;
            this.userSettingsButton.Text = "User settings";
            this.userSettingsButton.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 245);
            this.Controls.Add(this.userSettingsButton);
            this.Controls.Add(this.userStatsButton);
            this.Controls.Add(this.findPricesButton);
            this.Controls.Add(this.openfileButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openfileButton;
        private System.Windows.Forms.Button findPricesButton;
        private System.Windows.Forms.Button userStatsButton;
        private System.Windows.Forms.Button userSettingsButton;
    }
}