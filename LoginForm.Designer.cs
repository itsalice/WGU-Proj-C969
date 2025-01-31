namespace AliceLyC969
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
            this.userLoginLabel = new System.Windows.Forms.Label();
            this.loginUserField = new System.Windows.Forms.TextBox();
            this.loginPasswordField = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeZone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userLoginLabel
            // 
            this.userLoginLabel.AutoSize = true;
            this.userLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLoginLabel.Location = new System.Drawing.Point(320, 118);
            this.userLoginLabel.Name = "userLoginLabel";
            this.userLoginLabel.Size = new System.Drawing.Size(130, 29);
            this.userLoginLabel.TabIndex = 0;
            this.userLoginLabel.Text = "User Login";
            this.userLoginLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.userLoginLabel.TextChanged += new System.EventHandler(this.userLoginLabelChanged);
            // 
            // loginUserField
            // 
            this.loginUserField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginUserField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginUserField.Location = new System.Drawing.Point(320, 178);
            this.loginUserField.Name = "loginUserField";
            this.loginUserField.Size = new System.Drawing.Size(133, 24);
            this.loginUserField.TabIndex = 1;
            // 
            // loginPasswordField
            // 
            this.loginPasswordField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginPasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPasswordField.Location = new System.Drawing.Point(320, 218);
            this.loginPasswordField.Name = "loginPasswordField";
            this.loginPasswordField.PasswordChar = '*';
            this.loginPasswordField.Size = new System.Drawing.Size(133, 24);
            this.loginPasswordField.TabIndex = 2;
            this.loginPasswordField.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.AutoSize = true;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(348, 263);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 30);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButtonClicked);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(348, 408);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 30);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time Zone";
            // 
            // timeZone
            // 
            this.timeZone.AutoSize = true;
            this.timeZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeZone.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.timeZone.Location = new System.Drawing.Point(313, 354);
            this.timeZone.Name = "timeZone";
            this.timeZone.Size = new System.Drawing.Size(46, 18);
            this.timeZone.TabIndex = 6;
            this.timeZone.Text = "label2";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeZone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.loginPasswordField);
            this.Controls.Add(this.loginUserField);
            this.Controls.Add(this.userLoginLabel);
            this.Name = "LoginForm";
            this.Text = "User Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLoginLabel;
        private System.Windows.Forms.TextBox loginUserField;
        private System.Windows.Forms.TextBox loginPasswordField;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeZone;
    }
}

