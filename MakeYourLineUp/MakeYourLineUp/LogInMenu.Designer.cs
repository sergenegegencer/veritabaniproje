namespace MakeYourLineUp
{
    partial class LogInMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            logInButton = new Button();
            logInUsername = new TextBox();
            logInPassword = new TextBox();
            registerButton = new Button();
            RegisterPanel = new Panel();
            regRegisterButton = new Button();
            registerPasswordAgain = new TextBox();
            registerPassword = new TextBox();
            registerUsername = new TextBox();
            RegisterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto Medium", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label1.Location = new Point(249, 58);
            label1.Name = "label1";
            label1.Size = new Size(307, 57);
            label1.TabIndex = 0;
            label1.Text = "Futbol Analiz";
            // 
            // logInButton
            // 
            logInButton.Location = new Point(359, 289);
            logInButton.Name = "logInButton";
            logInButton.Size = new Size(94, 29);
            logInButton.TabIndex = 1;
            logInButton.Text = "Giriş Yap";
            logInButton.UseVisualStyleBackColor = true;
            logInButton.Click += logInButton_Click;
            // 
            // logInUsername
            // 
            logInUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            logInUsername.Location = new Point(184, 159);
            logInUsername.Name = "logInUsername";
            logInUsername.PlaceholderText = "Kullanıcı adınızı girin";
            logInUsername.Size = new Size(431, 27);
            logInUsername.TabIndex = 2;
            // 
            // logInPassword
            // 
            logInPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            logInPassword.Location = new Point(184, 212);
            logInPassword.Name = "logInPassword";
            logInPassword.PasswordChar = '.';
            logInPassword.PlaceholderText = "Şifrenizi girin";
            logInPassword.Size = new Size(431, 27);
            logInPassword.TabIndex = 3;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(359, 367);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(94, 29);
            registerButton.TabIndex = 4;
            registerButton.Text = "Kaydol";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // RegisterPanel
            // 
            RegisterPanel.Controls.Add(regRegisterButton);
            RegisterPanel.Controls.Add(registerPasswordAgain);
            RegisterPanel.Controls.Add(registerPassword);
            RegisterPanel.Controls.Add(registerUsername);
            RegisterPanel.Location = new Point(110, 131);
            RegisterPanel.Name = "RegisterPanel";
            RegisterPanel.Size = new Size(578, 274);
            RegisterPanel.TabIndex = 5;
            // 
            // regRegisterButton
            // 
            regRegisterButton.Location = new Point(249, 225);
            regRegisterButton.Name = "regRegisterButton";
            regRegisterButton.Size = new Size(94, 29);
            regRegisterButton.TabIndex = 3;
            regRegisterButton.Text = "Kaydol";
            regRegisterButton.UseVisualStyleBackColor = true;
            regRegisterButton.Click += regRegisterButton_Click;
            // 
            // registerPasswordAgain
            // 
            registerPasswordAgain.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            registerPasswordAgain.Location = new Point(74, 160);
            registerPasswordAgain.Name = "registerPasswordAgain";
            registerPasswordAgain.PasswordChar = '.';
            registerPasswordAgain.PlaceholderText = "Şifreyi tekrar girin";
            registerPasswordAgain.Size = new Size(431, 27);
            registerPasswordAgain.TabIndex = 2;
            // 
            // registerPassword
            // 
            registerPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            registerPassword.Location = new Point(74, 105);
            registerPassword.Name = "registerPassword";
            registerPassword.PasswordChar = '.';
            registerPassword.PlaceholderText = "Şifre belirleyin";
            registerPassword.Size = new Size(431, 27);
            registerPassword.TabIndex = 1;
            // 
            // registerUsername
            // 
            registerUsername.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            registerUsername.Location = new Point(74, 48);
            registerUsername.Name = "registerUsername";
            registerUsername.PlaceholderText = "Kullanıcı adı belirleyin";
            registerUsername.Size = new Size(431, 27);
            registerUsername.TabIndex = 0;
            // 
            // LogInMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(800, 450);
            Controls.Add(RegisterPanel);
            Controls.Add(registerButton);
            Controls.Add(logInPassword);
            Controls.Add(logInUsername);
            Controls.Add(logInButton);
            Controls.Add(label1);
            Name = "LogInMenu";
            Text = "Log In";
            RegisterPanel.ResumeLayout(false);
            RegisterPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button logInButton;
        private TextBox logInUsername;
        private TextBox logInPassword;
        private Button registerButton;
        private Panel RegisterPanel;
        private TextBox registerPasswordAgain;
        private TextBox registerPassword;
        private TextBox registerUsername;
        private Button regRegisterButton;
    }
}
