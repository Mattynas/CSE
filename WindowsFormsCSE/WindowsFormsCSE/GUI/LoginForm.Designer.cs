﻿namespace WindowsFormsCSE
{
    partial class LoginForm
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.signinButton = new System.Windows.Forms.Button();
            this.signupButton = new System.Windows.Forms.Button();
            this.registerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.Location = new System.Drawing.Point(98, 42);
            this.userNameTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userNameTextbox.MaxLength = 40;
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.Size = new System.Drawing.Size(172, 20);
            this.userNameTextbox.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(98, 75);
            this.passwordTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordTextbox.MaxLength = 40;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(172, 20);
            this.passwordTextbox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(24, 42);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(24, 77);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password:";
            // 
            // signinButton
            // 
            this.signinButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signinButton.Location = new System.Drawing.Point(119, 98);
            this.signinButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.signinButton.Name = "signinButton";
            this.signinButton.Size = new System.Drawing.Size(104, 26);
            this.signinButton.TabIndex = 4;
            this.signinButton.Text = "Sign in";
            this.signinButton.UseVisualStyleBackColor = true;
            this.signinButton.Click += new System.EventHandler(this.signinButton_Click);
            // 
            // signupButton
            // 
            this.signupButton.Location = new System.Drawing.Point(197, 153);
            this.signupButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(71, 25);
            this.signupButton.TabIndex = 7;
            this.signupButton.Text = "Sign up";
            this.signupButton.UseVisualStyleBackColor = true;
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Location = new System.Drawing.Point(74, 158);
            this.registerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(122, 13);
            this.registerLabel.TabIndex = 8;
            this.registerLabel.Text = "Don\'t have an account?";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 224);
            this.Controls.Add(this.registerLabel);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.signinButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.userNameTextbox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(342, 263);
            this.MinimumSize = new System.Drawing.Size(342, 263);
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Button signinButton;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.TextBox userNameTextbox;
        private System.Windows.Forms.ImageList imageList1;
    }
}

