using System.Data;

namespace MakeYourLineUp
{
    public partial class LogInMenu : Form
    {
        public LogInMenu()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.LogInMenu_FormClosing);
            RegisterPanel.Hide();
        }

        string connstr = "Server=localhost;Port=5432;Username=postgres;Password=imampower31;Database=MakeYourLineUp ; ";

        private void LogInMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(logInUsername.Text) || string.IsNullOrWhiteSpace(logInPassword.Text))
            {
                MessageBox.Show("Giri� i�lemi ba�ar�s�z! L�tfen kullan�c� ad� ve �ifre alanlar�n� doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new Npgsql.NpgsqlCommand("SELECT validate_login(@username, @password);", conn))
                    {
                        cmd.Parameters.AddWithValue("username", logInUsername.Text);
                        cmd.Parameters.AddWithValue("password", logInPassword.Text);

                        string result = cmd.ExecuteScalar().ToString();

                        if (result == "Giri� ba�ar�l�!")
                        {
                            MessageBox.Show(result, "Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainMenu mMenu = new MainMenu();
                            mMenu.LoggedInUsername = logInUsername.Text;
                            mMenu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(result, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata olu�tu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void registerButton_Click(Object sender, EventArgs e)
        {
            RegisterPanel.Show();
            RegisterPanel.BringToFront();
        }

        private void regRegisterButton_Click(Object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(registerUsername.Text) || string.IsNullOrWhiteSpace(registerPassword.Text) || string.IsNullOrWhiteSpace(registerPasswordAgain.Text))
            {
                MessageBox.Show("L�tfen kullan�c� ad� ve �ifre alanlar�n� doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (registerPassword.Text != registerPasswordAgain.Text)
            {
                MessageBox.Show("Girilen �ifreler ayn� olmal�d�r!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new Npgsql.NpgsqlCommand("SELECT register_user(@username, @password);", conn))
                    {
                        cmd.Parameters.AddWithValue("username", registerUsername.Text);
                        cmd.Parameters.AddWithValue("password", registerPassword.Text);

                        string result = cmd.ExecuteScalar().ToString();

                        if (result == "Kay�t ba�ar�l�!")
                        {
                            MessageBox.Show(result, "Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RegisterPanel.Hide();
                        }
                        else
                        {
                            MessageBox.Show(result, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata olu�tu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
