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
            this.virtualShoppingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openfileButton
            // 
            this.openfileButton.Location = new System.Drawing.Point(167, 14);
            this.openfileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openfileButton.Name = "openfileButton";
            this.openfileButton.Size = new System.Drawing.Size(149, 85);
            this.openfileButton.TabIndex = 0;
            this.openfileButton.Text = "Browse file";
            this.openfileButton.UseVisualStyleBackColor = true;
            this.openfileButton.Click += new System.EventHandler(this.openfileButton_Click);
            // 
            // findPricesButton
            // 
            this.findPricesButton.Location = new System.Drawing.Point(167, 122);
            this.findPricesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.findPricesButton.Name = "findPricesButton";
            this.findPricesButton.Size = new System.Drawing.Size(149, 28);
            this.findPricesButton.TabIndex = 1;
            this.findPricesButton.Text = "Find prices";
            this.findPricesButton.UseVisualStyleBackColor = true;
            // 
            // userStatsButton
            // 
            this.userStatsButton.Location = new System.Drawing.Point(167, 158);
            this.userStatsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userStatsButton.Name = "userStatsButton";
            this.userStatsButton.Size = new System.Drawing.Size(149, 28);
            this.userStatsButton.TabIndex = 2;
            this.userStatsButton.Text = "User stats";
            this.userStatsButton.UseVisualStyleBackColor = true;
            // 
            // userSettingsButton
            // 
            this.userSettingsButton.Location = new System.Drawing.Point(167, 193);
            this.userSettingsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userSettingsButton.Name = "userSettingsButton";
            this.userSettingsButton.Size = new System.Drawing.Size(149, 28);
            this.userSettingsButton.TabIndex = 3;
            this.userSettingsButton.Text = "User settings";
            this.userSettingsButton.UseVisualStyleBackColor = true;
            // 
            // virtualShoppingButton
            // 
            this.virtualShoppingButton.Location = new System.Drawing.Point(167, 229);
            this.virtualShoppingButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.virtualShoppingButton.Name = "virtualShoppingButton";
            this.virtualShoppingButton.Size = new System.Drawing.Size(149, 28);
            this.virtualShoppingButton.TabIndex = 4;
            this.virtualShoppingButton.Text = "Virtual shopping";
            this.virtualShoppingButton.UseVisualStyleBackColor = true;
            this.virtualShoppingButton.Click += new System.EventHandler(this.virtualShoppingButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 302);
            this.Controls.Add(this.virtualShoppingButton);
            this.Controls.Add(this.userSettingsButton);
            this.Controls.Add(this.userStatsButton);
            this.Controls.Add(this.findPricesButton);
            this.Controls.Add(this.openfileButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openfileButton;
        private System.Windows.Forms.Button findPricesButton;
        private System.Windows.Forms.Button userStatsButton;
        private System.Windows.Forms.Button userSettingsButton;
        private System.Windows.Forms.Button virtualShoppingButton;
    }
}