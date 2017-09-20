namespace WindowsFormsCSE.GUI
{
    partial class RegisterForm
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
            this.RegisterButton = new System.Windows.Forms.Button();
            this.RegisterUsernameTB = new System.Windows.Forms.TextBox();
            this.RegisterUsernameL = new System.Windows.Forms.Label();
            this.RegisterPasswordT = new System.Windows.Forms.Label();
            this.RegisterConfirmPassL = new System.Windows.Forms.Label();
            this.RegisterPasswordTB = new System.Windows.Forms.TextBox();
            this.RegisterConfirmPassTB = new System.Windows.Forms.TextBox();
            this.RegisterEmailTB = new System.Windows.Forms.TextBox();
            this.RegisterEmailL = new System.Windows.Forms.Label();
            this.RegisterWarningL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(118, 293);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(117, 25);
            this.RegisterButton.TabIndex = 5;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterUsernameTB
            // 
            this.RegisterUsernameTB.Location = new System.Drawing.Point(106, 70);
            this.RegisterUsernameTB.Name = "RegisterUsernameTB";
            this.RegisterUsernameTB.Size = new System.Drawing.Size(140, 20);
            this.RegisterUsernameTB.TabIndex = 1;
            // 
            // RegisterUsernameL
            // 
            this.RegisterUsernameL.AccessibleName = "RegisterUsername";
            this.RegisterUsernameL.AutoSize = true;
            this.RegisterUsernameL.Location = new System.Drawing.Point(150, 54);
            this.RegisterUsernameL.Name = "RegisterUsernameL";
            this.RegisterUsernameL.Size = new System.Drawing.Size(55, 13);
            this.RegisterUsernameL.TabIndex = 2;
            this.RegisterUsernameL.Text = "Username";
            // 
            // RegisterPasswordT
            // 
            this.RegisterPasswordT.AutoSize = true;
            this.RegisterPasswordT.Location = new System.Drawing.Point(150, 159);
            this.RegisterPasswordT.Name = "RegisterPasswordT";
            this.RegisterPasswordT.Size = new System.Drawing.Size(53, 13);
            this.RegisterPasswordT.TabIndex = 6;
            this.RegisterPasswordT.Text = "Password";
            // 
            // RegisterConfirmPassL
            // 
            this.RegisterConfirmPassL.AutoSize = true;
            this.RegisterConfirmPassL.Location = new System.Drawing.Point(131, 215);
            this.RegisterConfirmPassL.Name = "RegisterConfirmPassL";
            this.RegisterConfirmPassL.Size = new System.Drawing.Size(91, 13);
            this.RegisterConfirmPassL.TabIndex = 4;
            this.RegisterConfirmPassL.Text = "Confirm Password";
            // 
            // RegisterPasswordTB
            // 
            this.RegisterPasswordTB.Location = new System.Drawing.Point(106, 175);
            this.RegisterPasswordTB.Name = "RegisterPasswordTB";
            this.RegisterPasswordTB.PasswordChar = '*';
            this.RegisterPasswordTB.Size = new System.Drawing.Size(140, 20);
            this.RegisterPasswordTB.TabIndex = 3;
            // 
            // RegisterConfirmPassTB
            // 
            this.RegisterConfirmPassTB.Location = new System.Drawing.Point(106, 231);
            this.RegisterConfirmPassTB.Name = "RegisterConfirmPassTB";
            this.RegisterConfirmPassTB.PasswordChar = '*';
            this.RegisterConfirmPassTB.Size = new System.Drawing.Size(140, 20);
            this.RegisterConfirmPassTB.TabIndex = 4;
            // 
            // RegisterEmailTB
            // 
            this.RegisterEmailTB.Location = new System.Drawing.Point(106, 120);
            this.RegisterEmailTB.Name = "RegisterEmailTB";
            this.RegisterEmailTB.Size = new System.Drawing.Size(140, 20);
            this.RegisterEmailTB.TabIndex = 2;
            // 
            // RegisterEmailL
            // 
            this.RegisterEmailL.AutoSize = true;
            this.RegisterEmailL.Location = new System.Drawing.Point(161, 104);
            this.RegisterEmailL.Name = "RegisterEmailL";
            this.RegisterEmailL.Size = new System.Drawing.Size(32, 13);
            this.RegisterEmailL.TabIndex = 8;
            this.RegisterEmailL.Text = "Email";
            // 
            // RegisterWarningL
            // 
            this.RegisterWarningL.AutoSize = true;
            this.RegisterWarningL.ForeColor = System.Drawing.Color.Red;
            this.RegisterWarningL.Location = new System.Drawing.Point(124, 23);
            this.RegisterWarningL.Name = "RegisterWarningL";
            this.RegisterWarningL.Size = new System.Drawing.Size(111, 13);
            this.RegisterWarningL.TabIndex = 9;
            this.RegisterWarningL.Text = "Password don\'t match";
            this.RegisterWarningL.Visible = false;
            // 
            // RegisterForm
            // 
            this.AccessibleDescription = "Register";
            this.AccessibleName = "Register";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 366);
            this.Controls.Add(this.RegisterWarningL);
            this.Controls.Add(this.RegisterEmailL);
            this.Controls.Add(this.RegisterEmailTB);
            this.Controls.Add(this.RegisterConfirmPassTB);
            this.Controls.Add(this.RegisterPasswordTB);
            this.Controls.Add(this.RegisterConfirmPassL);
            this.Controls.Add(this.RegisterPasswordT);
            this.Controls.Add(this.RegisterUsernameL);
            this.Controls.Add(this.RegisterUsernameTB);
            this.Controls.Add(this.RegisterButton);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox RegisterUsernameTB;
        private System.Windows.Forms.Label RegisterUsernameL;
        private System.Windows.Forms.TextBox RegisterEmailTB;
        private System.Windows.Forms.Label RegisterEmailL;
        private System.Windows.Forms.Label RegisterPasswordT;
        private System.Windows.Forms.Label RegisterConfirmPassL;
        private System.Windows.Forms.TextBox RegisterPasswordTB;
        private System.Windows.Forms.TextBox RegisterConfirmPassTB;
        private System.Windows.Forms.Label RegisterWarningL;
    }
}