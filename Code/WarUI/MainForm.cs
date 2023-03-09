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
            var playersBoxOne = Player.ReadPlayersData();
            var playersBoxTwo = playersBoxOne.ToList();

            comboPlayerOne.DataSource = playersBoxOne;
            comboPlayerOne.DisplayMember = "PlayerName";
            comboPlayerTwo.DataSource = playersBoxTwo;
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

        private void MenuItemHighScore_Click(object sender, EventArgs e)
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

        private void ButtonCreateGame_Click(object sender, EventArgs e)
        {
            if (comboPlayerOne.SelectedItem is Player p1
                    && comboPlayerTwo.SelectedItem is Player p2)
            {
                if (p1.Equals(p2))
                {
                    MessageBox.Show("Select two different players!");
                }
                else
                {
                    game = new Game(p1, p2);
                    SetControlsVisibility();
                }
            }
            else
            {
                MessageBox.Show("No player selected");
            }

        }

        private void SetControlsVisibility()
        {
            comboPlayerOne.Enabled = game == null;
            comboPlayerTwo.Enabled = game == null;
            buttonCreateGame.Enabled = game == null;
            buttonStartGame.Enabled = game != null && !game.GameStarted;
            buttonEndGame.Enabled = game != null;
            buttonAutoPlay.Enabled = game != null && game.GameStarted;
        }

        private void ButtonEndGame_Click(object sender, EventArgs e)
        {
            game.EndGame();
            game = null;
            SetControlsVisibility();
        }

        private void buttonAutoPlay_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                while (game.Winner == null)
                {
                    game.PlayRound();
                }
                MessageBox.Show($"Winner is {game.Winner.PlayerName}");
                SetControlsVisibility();
            }
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                game.StartGame();
                SetControlsVisibility();
            }
        }
    }
}