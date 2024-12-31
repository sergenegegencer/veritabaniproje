using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MakeYourLineUp

{

    public partial class EditingPlayerSc : Form
    {
        private MainMenu _mainForm;
        public EditingPlayerSc(string name, string surname, string country, DateTime birthDate, string position, int teamId, string teamName, decimal marketValue)
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.EditingPlayerSc_Load);

            // Parametreler ile alanları doldur
            nameBox.Text = name;
            surnameBox.Text = surname;
            countryBox.Text = country;
            bdBox.Value = birthDate; // DateTimePicker
            positionBox.Text = position;

            // ComboBox ayarlanıyor
            teamBox.SelectedValue = teamId;
            teamBox.Text = teamName;

            // Piyasa değeri ekleniyor
            marketBox.Text = marketValue.ToString("F2");
        }

        private void EditingPlayerSc_Load(object sender, EventArgs e)
        {
            // Tüm takımların isimlerini teamBox'a yükle
            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT team_id, name FROM Teams";
                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            DataTable teams = new DataTable();
                            teams.Load(reader);

                            teamBox.DataSource = teams;
                            teamBox.DisplayMember = "name";
                            teamBox.ValueMember = "team_id";

                            cTeamBox.DataSource = teams;
                            cTeamBox.DisplayMember = "name";
                            cTeamBox.ValueMember = "team_id";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Takımlar yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Oyuncu güncelleme
        private void updatePlayerButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string surname = surnameBox.Text;
            string country = countryBox.Text;
            string position = positionBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(position) ||
                teamBox.SelectedIndex == -1 || !decimal.TryParse(marketBox.Text, out decimal marketValue))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli değerler girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedTeamId = (int)teamBox.SelectedValue;
            DateTime birthDate = bdBox.Value;

            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    // Oyuncunun mevcut takımını bul
                    int currentTeamId;
                    string currentTeamQuery = "SELECT current_team_id FROM Players WHERE name = @name AND surname = @surname";
                    using (var command = new Npgsql.NpgsqlCommand(currentTeamQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);

                        currentTeamId = (int)command.ExecuteScalar();
                    }

                    // Oyuncunun verilerini güncelle
                    string updatePlayerQuery = @"
                UPDATE Players
                SET name = @name, surname = @surname, country = @country, birth_date = @birthDate,
                    position = @position, current_team_id = @teamId, market_value = @marketValue
                WHERE name = @name AND surname = @surname";
                    using (var command = new Npgsql.NpgsqlCommand(updatePlayerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@country", country);
                        command.Parameters.AddWithValue("@birthDate", birthDate);
                        command.Parameters.AddWithValue("@position", position);
                        command.Parameters.AddWithValue("@teamId", selectedTeamId);
                        command.Parameters.AddWithValue("@marketValue", marketValue);

                        command.ExecuteNonQuery();
                    }

                    // Eğer takım değiştiyse transfer işlemini gerçekleştir
                    if (currentTeamId != selectedTeamId)
                    {
                        string transferQuery = @"
                    INSERT INTO Transfers (player_id, from_team_id, to_team_id, transfer_date)
                    VALUES (
                        (SELECT player_id FROM Players WHERE name = @name AND surname = @surname),
                        @fromTeamId,
                        @toTeamId,
                        @transferDate
                    )";
                        using (var command = new Npgsql.NpgsqlCommand(transferQuery, connection))
                        {
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@surname", surname);
                            command.Parameters.AddWithValue("@fromTeamId", currentTeamId);
                            command.Parameters.AddWithValue("@toTeamId", selectedTeamId);
                            command.Parameters.AddWithValue("@transferDate", DateTime.Now);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Oyuncu başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Oyuncu güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Oyuncu silme
        private void delPlayerButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string surname = surnameBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Lütfen silmek için bir oyuncu seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    // Oyuncuyu veritabanından sil
                    string deletePlayerQuery = "DELETE FROM Players WHERE name = @name AND surname = @surname";
                    using (var command = new Npgsql.NpgsqlCommand(deletePlayerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Oyuncu başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle
                    nameBox.Clear();
                    surnameBox.Clear();
                    countryBox.Clear();
                    positionBox.Clear();
                    marketBox.Clear();
                    teamBox.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Oyuncu silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            string name = cNameBox.Text.Trim();
            string surname = cSurnameBox.Text.Trim();
            string country = cCountryBox.Text.Trim();
            string position = cPositionBox.Text.Trim();

            // Giriş doğrulama
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(position) ||
                cTeamBox.SelectedIndex == -1 || !decimal.TryParse(cMarketBox.Text, out decimal marketValue))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz ve geçerli şekilde doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedTeamId = (int)cTeamBox.SelectedValue;
            DateTime birthDate = cbdBox.Value;

            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    // Yeni oyuncuyu veritabanına ekleme sorgusu
                    string addPlayerQuery = @"
                INSERT INTO Players (name, surname, country, position, birth_date, current_team_id, market_value)
                VALUES (@name, @surname, @country, @position, @birthDate, @teamId, @marketValue)";
                    using (var command = new Npgsql.NpgsqlCommand(addPlayerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@country", country);
                        command.Parameters.AddWithValue("@position", position);
                        command.Parameters.AddWithValue("@birthDate", birthDate);
                        command.Parameters.AddWithValue("@teamId", selectedTeamId);
                        command.Parameters.AddWithValue("@marketValue", marketValue);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Oyuncu başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle
                    cNameBox.Clear();
                    cSurnameBox.Clear();
                    cCountryBox.Clear();
                    cPositionBox.Clear();
                    cMarketBox.Clear();
                    cTeamBox.SelectedIndex = -1;
                    cbdBox.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Oyuncu eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        string connstr = "Server=localhost;Port=5432;Username=postgres;Password=imampower31;Database=MakeYourLineUp ; ";

        

    }
}
