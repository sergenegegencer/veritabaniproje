namespace MakeYourLineUp
{
    partial class MainMenu
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
            searchPlayerButton = new Button();
            searchTeamButton = new Button();
            PlayerPanel = new Panel();
            AdminPlayerPanel = new Panel();
            editPlayer = new Button();
            rcStatistic = new Label();
            ycStatistic = new Label();
            assistStatistic = new Label();
            goalStatistic = new Label();
            label3 = new Label();
            playerValueInfo = new Label();
            playerTeamInfo = new Label();
            playerPositionInfo = new Label();
            playerBirthDateInfo = new Label();
            playerCountryInfo = new Label();
            playerNameInfo = new Label();
            label1 = new Label();
            playerList = new ListBox();
            searchPlayer = new TextBox();
            TeamPanel = new Panel();
            teamCoachInfo = new Label();
            teamValueInfo = new Label();
            teamStadiumInfo = new Label();
            teamLeagueInfo = new Label();
            teamCountryInfo = new Label();
            teamPlayerList = new ListBox();
            teamList = new ListBox();
            searchTeam = new TextBox();
            backButton = new Button();
            settingsButton = new Button();
            showUsername = new Label();
            label2 = new Label();
            PlayerPanel.SuspendLayout();
            AdminPlayerPanel.SuspendLayout();
            TeamPanel.SuspendLayout();
            SuspendLayout();
            // 
            // searchPlayerButton
            // 
            searchPlayerButton.Location = new Point(501, 172);
            searchPlayerButton.Name = "searchPlayerButton";
            searchPlayerButton.Size = new Size(208, 46);
            searchPlayerButton.TabIndex = 3;
            searchPlayerButton.Text = "Oyuncu Ara";
            searchPlayerButton.UseVisualStyleBackColor = true;
            searchPlayerButton.Click += searchPlayer_click;
            // 
            // searchTeamButton
            // 
            searchTeamButton.Location = new Point(501, 271);
            searchTeamButton.Name = "searchTeamButton";
            searchTeamButton.Size = new Size(208, 46);
            searchTeamButton.TabIndex = 4;
            searchTeamButton.Text = "Takım Ara";
            searchTeamButton.UseVisualStyleBackColor = true;
            searchTeamButton.Click += searchTeam_click;
            // 
            // PlayerPanel
            // 
            PlayerPanel.BackColor = Color.LightCyan;
            PlayerPanel.Controls.Add(AdminPlayerPanel);
            PlayerPanel.Controls.Add(rcStatistic);
            PlayerPanel.Controls.Add(ycStatistic);
            PlayerPanel.Controls.Add(assistStatistic);
            PlayerPanel.Controls.Add(goalStatistic);
            PlayerPanel.Controls.Add(label3);
            PlayerPanel.Controls.Add(playerValueInfo);
            PlayerPanel.Controls.Add(playerTeamInfo);
            PlayerPanel.Controls.Add(playerPositionInfo);
            PlayerPanel.Controls.Add(playerBirthDateInfo);
            PlayerPanel.Controls.Add(playerCountryInfo);
            PlayerPanel.Controls.Add(playerNameInfo);
            PlayerPanel.Controls.Add(label1);
            PlayerPanel.Controls.Add(playerList);
            PlayerPanel.Controls.Add(searchPlayer);
            PlayerPanel.Location = new Point(28, 33);
            PlayerPanel.Name = "PlayerPanel";
            PlayerPanel.Size = new Size(1078, 685);
            PlayerPanel.TabIndex = 6;
            // 
            // AdminPlayerPanel
            // 
            AdminPlayerPanel.Controls.Add(editPlayer);
            AdminPlayerPanel.Location = new Point(374, 573);
            AdminPlayerPanel.Name = "AdminPlayerPanel";
            AdminPlayerPanel.Size = new Size(250, 77);
            AdminPlayerPanel.TabIndex = 14;
            // 
            // editPlayer
            // 
            editPlayer.Location = new Point(53, 38);
            editPlayer.Name = "editPlayer";
            editPlayer.Size = new Size(144, 29);
            editPlayer.TabIndex = 1;
            editPlayer.Text = "Oyuncu Düzenle";
            editPlayer.UseVisualStyleBackColor = true;
            editPlayer.Click += editPlayer_Click;
            // 
            // rcStatistic
            // 
            rcStatistic.AutoSize = true;
            rcStatistic.Location = new Point(631, 525);
            rcStatistic.Name = "rcStatistic";
            rcStatistic.Size = new Size(93, 20);
            rcStatistic.TabIndex = 13;
            rcStatistic.Text = "Kırmızı Kart: ";
            // 
            // ycStatistic
            // 
            ycStatistic.AutoSize = true;
            ycStatistic.Location = new Point(631, 473);
            ycStatistic.Name = "ycStatistic";
            ycStatistic.Size = new Size(72, 20);
            ycStatistic.TabIndex = 12;
            ycStatistic.Text = "Sarı Kart: ";
            // 
            // assistStatistic
            // 
            assistStatistic.AutoSize = true;
            assistStatistic.Location = new Point(287, 525);
            assistStatistic.Name = "assistStatistic";
            assistStatistic.Size = new Size(47, 20);
            assistStatistic.TabIndex = 11;
            assistStatistic.Text = "Asist: ";
            // 
            // goalStatistic
            // 
            goalStatistic.AutoSize = true;
            goalStatistic.Location = new Point(289, 473);
            goalStatistic.Name = "goalStatistic";
            goalStatistic.Size = new Size(39, 20);
            goalStatistic.TabIndex = 10;
            goalStatistic.Text = "Gol: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 422);
            label3.Name = "label3";
            label3.Size = new Size(140, 20);
            label3.TabIndex = 9;
            label3.Text = "Oyuncu Performansı";
            // 
            // playerValueInfo
            // 
            playerValueInfo.AutoSize = true;
            playerValueInfo.Location = new Point(647, 165);
            playerValueInfo.Name = "playerValueInfo";
            playerValueInfo.Size = new Size(57, 20);
            playerValueInfo.TabIndex = 8;
            playerValueInfo.Text = "Değeri:";
            // 
            // playerTeamInfo
            // 
            playerTeamInfo.AutoSize = true;
            playerTeamInfo.Location = new Point(647, 358);
            playerTeamInfo.Name = "playerTeamInfo";
            playerTeamInfo.Size = new Size(54, 20);
            playerTeamInfo.TabIndex = 7;
            playerTeamInfo.Text = "Takım: ";
            // 
            // playerPositionInfo
            // 
            playerPositionInfo.AutoSize = true;
            playerPositionInfo.Location = new Point(296, 358);
            playerPositionInfo.Name = "playerPositionInfo";
            playerPositionInfo.Size = new Size(69, 20);
            playerPositionInfo.TabIndex = 6;
            playerPositionInfo.Text = "Pozisyon:";
            // 
            // playerBirthDateInfo
            // 
            playerBirthDateInfo.AutoSize = true;
            playerBirthDateInfo.Location = new Point(647, 251);
            playerBirthDateInfo.Name = "playerBirthDateInfo";
            playerBirthDateInfo.Size = new Size(101, 20);
            playerBirthDateInfo.TabIndex = 5;
            playerBirthDateInfo.Text = "Doğum Tarihi:";
            // 
            // playerCountryInfo
            // 
            playerCountryInfo.AutoSize = true;
            playerCountryInfo.Location = new Point(296, 253);
            playerCountryInfo.Name = "playerCountryInfo";
            playerCountryInfo.Size = new Size(38, 20);
            playerCountryInfo.TabIndex = 4;
            playerCountryInfo.Text = "Ülke";
            // 
            // playerNameInfo
            // 
            playerNameInfo.AutoSize = true;
            playerNameInfo.Location = new Point(296, 149);
            playerNameInfo.Name = "playerNameInfo";
            playerNameInfo.Size = new Size(39, 20);
            playerNameInfo.TabIndex = 3;
            playerNameInfo.Text = "Adı: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(289, 96);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 2;
            label1.Text = "Oyuncu Bilgileri";
            // 
            // playerList
            // 
            playerList.FormattingEnabled = true;
            playerList.Location = new Point(22, 96);
            playerList.Name = "playerList";
            playerList.Size = new Size(196, 544);
            playerList.TabIndex = 1;
            playerList.SelectedIndexChanged += playerList_SelectedIndexChanged;
            // 
            // searchPlayer
            // 
            searchPlayer.Location = new Point(22, 40);
            searchPlayer.Name = "searchPlayer";
            searchPlayer.PlaceholderText = "Oyuncu ismi girin";
            searchPlayer.Size = new Size(1109, 27);
            searchPlayer.TabIndex = 0;
            searchPlayer.TextChanged += searchPlayer_TextChanged;
            // 
            // TeamPanel
            // 
            TeamPanel.BackColor = Color.LightCyan;
            TeamPanel.Controls.Add(teamCoachInfo);
            TeamPanel.Controls.Add(teamValueInfo);
            TeamPanel.Controls.Add(teamStadiumInfo);
            TeamPanel.Controls.Add(teamLeagueInfo);
            TeamPanel.Controls.Add(teamCountryInfo);
            TeamPanel.Controls.Add(teamPlayerList);
            TeamPanel.Controls.Add(teamList);
            TeamPanel.Controls.Add(searchTeam);
            TeamPanel.Location = new Point(0, 3);
            TeamPanel.Name = "TeamPanel";
            TeamPanel.Size = new Size(1081, 694);
            TeamPanel.TabIndex = 1;
            // 
            // teamCoachInfo
            // 
            teamCoachInfo.AutoSize = true;
            teamCoachInfo.Location = new Point(755, 615);
            teamCoachInfo.Name = "teamCoachInfo";
            teamCoachInfo.Size = new Size(0, 20);
            teamCoachInfo.TabIndex = 7;
            // 
            // teamValueInfo
            // 
            teamValueInfo.AutoSize = true;
            teamValueInfo.Location = new Point(755, 137);
            teamValueInfo.Name = "teamValueInfo";
            teamValueInfo.Size = new Size(0, 20);
            teamValueInfo.TabIndex = 6;
            // 
            // teamStadiumInfo
            // 
            teamStadiumInfo.AutoSize = true;
            teamStadiumInfo.Location = new Point(755, 447);
            teamStadiumInfo.Name = "teamStadiumInfo";
            teamStadiumInfo.Size = new Size(0, 20);
            teamStadiumInfo.TabIndex = 5;
            // 
            // teamLeagueInfo
            // 
            teamLeagueInfo.AutoSize = true;
            teamLeagueInfo.Location = new Point(755, 330);
            teamLeagueInfo.Name = "teamLeagueInfo";
            teamLeagueInfo.Size = new Size(0, 20);
            teamLeagueInfo.TabIndex = 4;
            // 
            // teamCountryInfo
            // 
            teamCountryInfo.AutoSize = true;
            teamCountryInfo.Location = new Point(755, 236);
            teamCountryInfo.Name = "teamCountryInfo";
            teamCountryInfo.Size = new Size(0, 20);
            teamCountryInfo.TabIndex = 3;
            // 
            // teamPlayerList
            // 
            teamPlayerList.FormattingEnabled = true;
            teamPlayerList.Location = new Point(321, 151);
            teamPlayerList.Name = "teamPlayerList";
            teamPlayerList.Size = new Size(382, 484);
            teamPlayerList.TabIndex = 2;
            // 
            // teamList
            // 
            teamList.FormattingEnabled = true;
            teamList.Location = new Point(21, 151);
            teamList.Name = "teamList";
            teamList.Size = new Size(194, 484);
            teamList.TabIndex = 1;
            teamList.SelectedIndexChanged += teamList_SelectedIndexChanged;
            // 
            // searchTeam
            // 
            searchTeam.Location = new Point(22, 37);
            searchTeam.Name = "searchTeam";
            searchTeam.PlaceholderText = "Takım ismi girin";
            searchTeam.Size = new Size(1109, 27);
            searchTeam.TabIndex = 0;
            searchTeam.TextChanged += searchTeam_TextChanged;
            // 
            // backButton
            // 
            backButton.Location = new Point(15, 812);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 6;
            backButton.Text = "Geri";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_click;
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(1040, 771);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(94, 29);
            settingsButton.TabIndex = 7;
            settingsButton.Text = "Ayarlar";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // showUsername
            // 
            showUsername.AutoSize = true;
            showUsername.Location = new Point(15, 9);
            showUsername.Name = "showUsername";
            showUsername.Size = new Size(0, 20);
            showUsername.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 10);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 9;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(1182, 853);
            Controls.Add(PlayerPanel);
            Controls.Add(TeamPanel);
            Controls.Add(label2);
            Controls.Add(showUsername);
            Controls.Add(settingsButton);
            Controls.Add(backButton);
            Controls.Add(searchTeamButton);
            Controls.Add(searchPlayerButton);
            Name = "MainMenu";
            Text = "Main Menu";
            PlayerPanel.ResumeLayout(false);
            PlayerPanel.PerformLayout();
            AdminPlayerPanel.ResumeLayout(false);
            TeamPanel.ResumeLayout(false);
            TeamPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button searchPlayerButton;
        private Button searchTeamButton;
        private Panel PlayerPanel;
        private TextBox searchPlayer;
        private Panel TeamPanel;
        private TextBox searchTeam;
        private Button backButton;
        private Button settingsButton;
        private Label showUsername;
        private Label label2;
        private ListBox playerList;
        private ListBox teamList;
        private ListBox teamPlayerList;
        private Label teamCoachInfo;
        private Label teamValueInfo;
        private Label teamStadiumInfo;
        private Label teamLeagueInfo;
        private Label teamCountryInfo;
        private Label playerValueInfo;
        private Label playerTeamInfo;
        private Label playerPositionInfo;
        private Label playerBirthDateInfo;
        private Label playerCountryInfo;
        private Label playerNameInfo;
        private Label label1;
        private Label assistStatistic;
        private Label goalStatistic;
        private Label label3;
        private Label rcStatistic;
        private Label ycStatistic;
        private Panel AdminPlayerPanel;
        private Button editPlayer;
    }
}