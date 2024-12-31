namespace MakeYourLineUp
{
    partial class SettingsMenu
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
            label1 = new Label();
            label2 = new Label();
            deleteYourAccountButton = new Button();
            changeUsername = new TextBox();
            enterCurrentPassword = new TextBox();
            changePassword = new TextBox();
            changePasswordAgain = new TextBox();
            savePassword = new Button();
            saveUsername = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 33);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı Değiştir";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 116);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 1;
            label2.Text = "Şifre Değiştir";
            // 
            // deleteYourAccountButton
            // 
            deleteYourAccountButton.ForeColor = Color.Red;
            deleteYourAccountButton.Location = new Point(345, 395);
            deleteYourAccountButton.Name = "deleteYourAccountButton";
            deleteYourAccountButton.Size = new Size(94, 29);
            deleteYourAccountButton.TabIndex = 2;
            deleteYourAccountButton.Text = "Hesabı Sil";
            deleteYourAccountButton.UseVisualStyleBackColor = true;
            deleteYourAccountButton.Click += delAccButton_Click;
            // 
            // changeUsername
            // 
            changeUsername.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            changeUsername.Location = new Point(50, 70);
            changeUsername.Name = "changeUsername";
            changeUsername.PlaceholderText = "Kullanmak istediğiniz adı girin";
            changeUsername.Size = new Size(599, 27);
            changeUsername.TabIndex = 3;
            // 
            // enterCurrentPassword
            // 
            enterCurrentPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            enterCurrentPassword.Location = new Point(50, 156);
            enterCurrentPassword.Name = "enterCurrentPassword";
            enterCurrentPassword.PasswordChar = '.';
            enterCurrentPassword.PlaceholderText = "Mevcut şifrenizi girin";
            enterCurrentPassword.Size = new Size(700, 27);
            enterCurrentPassword.TabIndex = 4;
            // 
            // changePassword
            // 
            changePassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            changePassword.Location = new Point(50, 205);
            changePassword.Name = "changePassword";
            changePassword.PasswordChar = '.';
            changePassword.PlaceholderText = "Kullanmak istediğiniz şifreyi girin";
            changePassword.Size = new Size(700, 27);
            changePassword.TabIndex = 5;
            // 
            // changePasswordAgain
            // 
            changePasswordAgain.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            changePasswordAgain.Location = new Point(50, 258);
            changePasswordAgain.Name = "changePasswordAgain";
            changePasswordAgain.PasswordChar = '.';
            changePasswordAgain.PlaceholderText = "Şifreyi tekrar girin";
            changePasswordAgain.Size = new Size(700, 27);
            changePasswordAgain.TabIndex = 6;
            // 
            // savePassword
            // 
            savePassword.Location = new Point(345, 330);
            savePassword.Name = "savePassword";
            savePassword.Size = new Size(94, 29);
            savePassword.TabIndex = 7;
            savePassword.Text = "Kaydet";
            savePassword.UseVisualStyleBackColor = true;
            savePassword.Click += savePassword_Click;
            // 
            // saveUsername
            // 
            saveUsername.Location = new Point(656, 70);
            saveUsername.Name = "saveUsername";
            saveUsername.Size = new Size(94, 29);
            saveUsername.TabIndex = 8;
            saveUsername.Text = "Kaydet";
            saveUsername.UseVisualStyleBackColor = true;
            saveUsername.Click += saveUsername_Click;
            // 
            // SettingsMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveUsername);
            Controls.Add(savePassword);
            Controls.Add(changePasswordAgain);
            Controls.Add(changePassword);
            Controls.Add(enterCurrentPassword);
            Controls.Add(changeUsername);
            Controls.Add(deleteYourAccountButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SettingsMenu";
            Text = "SettingsMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button deleteYourAccountButton;
        private TextBox changeUsername;
        private TextBox enterCurrentPassword;
        private TextBox changePassword;
        private TextBox changePasswordAgain;
        private Button savePassword;
        private Button saveUsername;
    }
}