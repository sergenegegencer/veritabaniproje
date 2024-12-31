using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MakeYourLineUp
{
    public partial class MainMenu : Form
    {
        public string LoggedInUsername { get; set; }
        public int LoggedInAccID { get; set; }
        public MainMenu()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.MainMenu_Load);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(this.MainMenu_FormClosing);
            PlayerPanel.Hide();
            TeamPanel.Hide();
            showUsername.Text = "Kullanıcı: " + LoggedInUsername;
        }

        string connstr = "Server=localhost;Port=5432;Username=postgres;Password=imampower31;Database=MakeYourLineUp ; ";
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

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


        private void searchPlayer_click(object sender, EventArgs e)
        {
            LoggedInAccID = GetAccountId();
            TeamPanel.Hide();
            PlayerPanel.Show();
            PlayerPanel.BringToFront();
            LoadAdminPanel(LoggedInAccID);
        }

        private void searchTeam_click(object sender, EventArgs e)
        {
            LoggedInAccID = GetAccountId();
            PlayerPanel.Hide();
            TeamPanel.Show();
            TeamPanel.BringToFront();
            LoadAdminPanel(LoggedInAccID);
        }

        private void backButton_click(object sender, EventArgs e)
        {
            if (!PlayerPanel.Visible && !TeamPanel.Visible)
            {
                DialogResult result = MessageBox.Show("Hesabınızdan çıkmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    this.Hide();
                    LogInMenu lMenu = new LogInMenu();
                    lMenu.Show();
                }

            }

            else
            {
                PlayerPanel.Hide();
                TeamPanel.Hide();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsMenu sMenu = new SettingsMenu(this);
            sMenu.LoggedInUsername = this.LoggedInUsername;
            sMenu.Show();
        }

        public void updateUsername(string userName)
        {
            showUsername.Text = "Kullanıcı: " + userName;
        }

        private void searchTeam_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTeam.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                teamList.Items.Clear();
                return;
            }

            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT name FROM Teams WHERE name ILIKE @searchText";

                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            teamList.Items.Clear();

                            while (reader.Read())
                            {
                                teamList.Items.Add(reader["name"].ToString());
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

        private void teamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamList.SelectedItem == null)
                return;

            string selectedTeamName = teamList.SelectedItem.ToString();


            using (NpgsqlConnection connection = new NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();


                    string teamInfoQuery = @"
                SELECT t.team_id, t.country, t.stadium, t.coach, l.name AS league_name
                FROM Teams t
                LEFT JOIN Team_League tl ON t.team_id = tl.team_id
                LEFT JOIN Leagues l ON tl.league_id = l.league_id
                WHERE t.name = @teamName;";

                    int teamId = -1;
                    string teamCountry = "", teamStadium = "", teamCoach = "", teamLeague = "";

                    using (NpgsqlCommand command = new NpgsqlCommand(teamInfoQuery, connection))
                    {
                        command.Parameters.AddWithValue("@teamName", selectedTeamName);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                teamId = reader.GetInt32(reader.GetOrdinal("team_id"));
                                teamCountry = reader["country"].ToString();
                                teamStadium = reader["stadium"].ToString();
                                teamCoach = reader["coach"].ToString();
                                teamLeague = reader["league_name"]?.ToString() ?? "Belirtilmemiş";
                            }
                        }
                    }

                    if (teamId == -1)
                        return;


                    string playersQuery = "SELECT name, surname FROM Players WHERE current_team_id = @teamId";
                    teamPlayerList.Items.Clear();

                    using (NpgsqlCommand command = new NpgsqlCommand(playersQuery, connection))
                    {
                        command.Parameters.AddWithValue("@teamId", teamId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string playerName = $"{reader["name"]} {reader["surname"]}";
                                teamPlayerList.Items.Add(playerName);
                            }
                        }
                    }

                    string teamValueQuery = "SELECT COALESCE(SUM(market_value), 0) AS total_value FROM Players WHERE current_team_id = @teamId";
                    decimal teamValue = 0;

                    using (NpgsqlCommand command = new NpgsqlCommand(teamValueQuery, connection))
                    {
                        command.Parameters.AddWithValue("@teamId", teamId);

                        object result = command.ExecuteScalar();
                        teamValue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    CultureInfo euroCulture = new CultureInfo("de-DE");
                    teamValueInfo.Text = "Takım Değeri: " + string.Format(euroCulture, "{0:C}", teamValue);
                    teamCountryInfo.Text = "Ülke: " + teamCountry;
                    teamLeagueInfo.Text = "Lig: " + teamLeague;
                    teamStadiumInfo.Text = "Stadyum: " + teamStadium;
                    teamCoachInfo.Text = "Teknik Direktör: " + teamCoach;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchPlayer_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchPlayer.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                playerList.Items.Clear();
                return;
            }

            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT name, surname FROM Players WHERE name ILIKE @searchText";

                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            playerList.Items.Clear();

                            while (reader.Read())
                            {
                                string fullName = $"{reader["name"]} {reader["surname"]}";
                                playerList.Items.Add(fullName);
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

        private void playerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playerList.SelectedItem == null)
                return;

            string selectedPlayer = playerList.SelectedItem.ToString();
            string[] nameParts = selectedPlayer.Split(' ');
            if (nameParts.Length < 2)
                return;

            string playerName = nameParts[0];
            string playerSurname = nameParts[1];

            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    // Oyuncu bilgilerini al
                    string playerInfoQuery = @"
                SELECT 
                    name, 
                    surname, 
                    market_value, 
                    country, 
                    birth_date, 
                    position, 
                    (SELECT name FROM Teams WHERE team_id = p.current_team_id) AS team_name
                FROM Players p
                WHERE name = @playerName AND surname = @playerSurname";

                    using (var playerInfoCommand = new Npgsql.NpgsqlCommand(playerInfoQuery, connection))
                    {
                        playerInfoCommand.Parameters.AddWithValue("@playerName", playerName);
                        playerInfoCommand.Parameters.AddWithValue("@playerSurname", playerSurname);

                        using (var reader = playerInfoCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                playerNameInfo.Text = "Adı: " + $"{reader["name"]} {reader["surname"]}";
                                playerValueInfo.Text = "Değeri: " + $"{Convert.ToDecimal(reader["market_value"]):C}"; // Para birimi
                                playerCountryInfo.Text = "Ülke: " + reader["country"].ToString();
                                playerBirthDateInfo.Text = "Doğum Tarihi: " + Convert.ToDateTime(reader["birth_date"]).ToShortDateString();
                                playerPositionInfo.Text = "Pozisyon:" + reader["position"].ToString();
                                playerTeamInfo.Text = "Takım: " + reader["team_name"].ToString();
                            }
                        }
                    }

                    // Oyuncu istatistiklerini al
                    string playerStatsQuery = @"
                SELECT 
                    COALESCE(SUM(goals), 0) AS total_goals,
                    COALESCE(SUM(assists), 0) AS total_assists,
                    COALESCE(SUM(yellow_cards), 0) AS total_yellow_cards,
                    COALESCE(SUM(red_cards), 0) AS total_red_cards
                FROM Performance
                WHERE player_id = (
                    SELECT player_id FROM Players WHERE name = @playerName AND surname = @playerSurname
                )";

                    using (var playerStatsCommand = new Npgsql.NpgsqlCommand(playerStatsQuery, connection))
                    {
                        playerStatsCommand.Parameters.AddWithValue("@playerName", playerName);
                        playerStatsCommand.Parameters.AddWithValue("@playerSurname", playerSurname);

                        using (var reader = playerStatsCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                goalStatistic.Text = "Gol: " + reader["total_goals"].ToString();
                                assistStatistic.Text = "Asist: " + reader["total_assists"].ToString();
                                ycStatistic.Text = "Sarı Kart: " + reader["total_yellow_cards"].ToString();
                                rcStatistic.Text = "Kırmızı Kart: " + reader["total_red_cards"].ToString();
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

        private void LoadAdminPanel(int accountId)
        {
            if (PlayerPanel.Visible)
            {
                if (accountId == 1 || accountId == 2)
                {
                    AdminPlayerPanel.Visible = true;
                }
                else
                { AdminPlayerPanel.Visible = false; }
            }
            else if (TeamPanel.Visible)
            {
                if (accountId == 1 || accountId == 2)
                {

                }
                else
                {

                }
            }
        }

        private void editPlayer_Click(object sender, EventArgs e)
        {
            if (playerList.SelectedItem == null)
            {
                MessageBox.Show("Lütfen düzenlemek için bir oyuncu seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedPlayer = playerList.SelectedItem.ToString();
            string[] nameParts = selectedPlayer.Split(' ');

            if (nameParts.Length < 2)
            {
                MessageBox.Show("Seçilen oyuncunun adı geçersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string playerName = nameParts[0];
            string playerSurname = nameParts[1];

            using (var connection = new Npgsql.NpgsqlConnection(connstr))
            {
                try
                {
                    connection.Open();

                    // Oyuncu bilgilerini getir
                    string query = @"
                SELECT 
                    name, 
                    surname, 
                    country, 
                    birth_date, 
                    position, 
                    current_team_id,
                    market_value,
                    (SELECT name FROM Teams WHERE team_id = p.current_team_id) AS team_name
                FROM Players p
                WHERE name = @playerName AND surname = @playerSurname";

                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@playerName", playerName);
                        command.Parameters.AddWithValue("@playerSurname", playerSurname);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Parametreler hazırlanıyor
                                string name = reader["name"].ToString();
                                string surname = reader["surname"].ToString();
                                string country = reader["country"].ToString();
                                DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                                string position = reader["position"].ToString();
                                int teamId = Convert.ToInt32(reader["current_team_id"]);
                                string teamName = reader["team_name"].ToString();
                                decimal marketValue = Convert.ToDecimal(reader["market_value"]);

                                // Düzenleme ekranına oyuncu bilgilerini parametre olarak geç
                                EditingPlayerSc editpl = new EditingPlayerSc(name, surname, country, birthDate, position, teamId, teamName, marketValue);
                                editpl.Show();
                            }
                            else
                            {
                                MessageBox.Show("Oyuncu bilgileri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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





    }
}
