using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MakeYourLineUp
{
    public partial class SettingsMenu : Form
    {
        public string LoggedInUsername { get; set; }
        
        private MainMenu _mainForm;
        public SettingsMenu(MainMenu mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        string connstr = "Server=localhost;Port=5432;Username=postgres;Password=imampower31;Database=MakeYourLineUp ; ";

        private int GetAccountId()
        {
            int accountId = -1;


            using (NpgsqlConnection connection = new NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    // SQL komutu
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT GetAccountId(@username)", connection))
                    {
                        // Parametreler
                        command.Parameters.AddWithValue("@username", LoggedInUsername);

                        // Sonuç okuma
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            accountId = Convert.ToInt32(result);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı kullanıcı adı!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }

            return accountId;
        }
        private void delAccButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Hesabınızı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {

            }

            else
            {

            }

        }

        private void saveUsername_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(changeUsername.Text))
            {
                MessageBox.Show("Lütfen yeni kullanıcı adınızı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Kullanıcı adını değiştirmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    string currentUsername = LoggedInUsername;
                    string newUsername = changeUsername.Text;

                    using (var conn = new Npgsql.NpgsqlConnection(connstr))
                    {
                        conn.Open();

                        using (var cmd = new Npgsql.NpgsqlCommand("SELECT change_username(@current_username, @new_username)", conn))
                        {
                            cmd.Parameters.AddWithValue("current_username", currentUsername);
                            cmd.Parameters.AddWithValue("new_username", newUsername);

                            string resultMessage = cmd.ExecuteScalar()?.ToString();
                            MessageBox.Show(resultMessage, "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Eğer kullanıcı adı başarıyla değiştirildiyse, oturumdaki kullanıcı adını güncelle
                            if (resultMessage.Contains("başarıyla değiştirildi"))
                            {
                                LoggedInUsername = newUsername;
                                _mainForm.updateUsername(newUsername);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void savePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(enterCurrentPassword.Text) ||
                string.IsNullOrWhiteSpace(changePassword.Text) ||
                string.IsNullOrWhiteSpace(changePasswordAgain.Text))
            {
                MessageBox.Show("Lütfen boşlukları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (changePassword.Text != changePasswordAgain.Text)
            {
                MessageBox.Show("Yeni şifreler birbiriyle eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Şifrenizi değiştirmek istediğinizden emin misiniz?",
                                                  "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    // Veritabanı bağlantısı
                    using (var connection = new Npgsql.NpgsqlConnection(connstr))
                    {
                        connection.Open();

                        // Komut oluştur
                        using (var command = new Npgsql.NpgsqlCommand("CALL ChangePassword(@accountId, @currentPassword, @newPassword);", connection))
                        {
                            // Parametreleri ekle
                            command.Parameters.AddWithValue("@accountId", GetAccountId());
                            command.Parameters.AddWithValue("@currentPassword", enterCurrentPassword.Text);
                            command.Parameters.AddWithValue("@newPassword", changePassword.Text);

                            // Prosedürü çağır
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Şifreniz başarıyla değiştirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Npgsql.NpgsqlException ex)
                {
                    // Hata yönetimi
                    MessageBox.Show($"Şifre değiştirme başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
