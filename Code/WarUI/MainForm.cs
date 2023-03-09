using War.DataAccess;
using War.Model;

namespace WarUI
{
    public partial class MainForm : Form
    {
        private Game game;

        public MainForm()
        {
            InitializeComponent();
            LoadPlayers();
            SetControlsVisibility();
        }

        private void LoadPlayers()
        {
            var players = Player.ReadPlayersData();
            comboPlayerOne.DataSource = players;
            comboPlayerOne.DisplayMember = "PlayerName";
            comboPlayerTwo.DataSource = players;
            comboPlayerTwo.DisplayMember = comboPlayerOne.DisplayMember;
        }

        private void MenuItemManagePlayers_Click(object sender, EventArgs e)
        {
            Form form = new ManagePlayersForm();
            form.ShowDialog();
            // reload data
            LoadPlayers();
            SetControlsVisibility();
        }

        private void menuItemHighScore_Click(object sender, EventArgs e)
        {
            Form form = new HighScoreForm();
            form.ShowDialog();
            SetControlsVisibility();
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            Form form = new AboutBoxForm();
            form.ShowDialog();
            SetControlsVisibility();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Player p1 = comboPlayerOne.SelectedItem as Player;
            Player p2 = comboPlayerTwo.SelectedItem as Player;
            game = new Game(p1, p2);
            SetControlsVisibility();
        }

        private void SetControlsVisibility()
        {
            comboPlayerOne.Enabled = game == null;
            comboPlayerTwo.Enabled = game == null;
            buttonCreateGame.Enabled = game == null;
            buttonStartGame.Enabled = game != null;
            buttonEndGame.Enabled = game != null;
            checkBoxAutoPlay.Enabled = false;
        }

        private void buttonEndGame_Click(object sender, EventArgs e)
        {
            game.EndGame();
            game = null;
            SetControlsVisibility();
        }
    }
}