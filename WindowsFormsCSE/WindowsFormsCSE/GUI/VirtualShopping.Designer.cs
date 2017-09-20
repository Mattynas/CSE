namespace WindowsFormsCSE.GUI
{
    partial class VirtualShopping
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
            this.chooseShopsFromListButton = new System.Windows.Forms.Button();
            this.chooseShopsNearbyButton = new System.Windows.Forms.Button();
            this.searchForItemsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseShopsFromListButton
            // 
            this.chooseShopsFromListButton.Location = new System.Drawing.Point(13, 13);
            this.chooseShopsFromListButton.Name = "chooseShopsFromListButton";
            this.chooseShopsFromListButton.Size = new System.Drawing.Size(128, 23);
            this.chooseShopsFromListButton.TabIndex = 0;
            this.chooseShopsFromListButton.Text = "Choose shops from list";
            this.chooseShopsFromListButton.UseVisualStyleBackColor = true;
            // 
            // chooseShopsNearbyButton
            // 
            this.chooseShopsNearbyButton.Location = new System.Drawing.Point(13, 43);
            this.chooseShopsNearbyButton.Name = "chooseShopsNearbyButton";
            this.chooseShopsNearbyButton.Size = new System.Drawing.Size(128, 23);
            this.chooseShopsNearbyButton.TabIndex = 1;
            this.chooseShopsNearbyButton.Text = "Choose shops nearby";
            this.chooseShopsNearbyButton.UseVisualStyleBackColor = true;
            // 
            // searchForItemsButton
            // 
            this.searchForItemsButton.Location = new System.Drawing.Point(13, 73);
            this.searchForItemsButton.Name = "searchForItemsButton";
            this.searchForItemsButton.Size = new System.Drawing.Size(128, 23);
            this.searchForItemsButton.TabIndex = 2;
            this.searchForItemsButton.Text = "Search for items";
            this.searchForItemsButton.UseVisualStyleBackColor = true;
            // 
            // VirtualShopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(153, 107);
            this.Controls.Add(this.searchForItemsButton);
            this.Controls.Add(this.chooseShopsNearbyButton);
            this.Controls.Add(this.chooseShopsFromListButton);
            this.Name = "VirtualShopping";
            this.Text = "Virtual shopping";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chooseShopsFromListButton;
        private System.Windows.Forms.Button chooseShopsNearbyButton;
        private System.Windows.Forms.Button searchForItemsButton;
    }
}