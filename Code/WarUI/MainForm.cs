using War.DataAccess;
using War.Model;

namespace WarUI
{
    public partial class MainForm : Form
    {
        private Game game;
        private Player p1;
        private Player p2;

        public MainForm()
        {
            InitializeComponent();
            LoadPlayers();
            SetControls();
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
            SetControls();
        }

        private void MenuItemHighScore_Click(object sender, EventArgs e)
        {
            Form form = new HighScoreForm();
            form.ShowDialog();
            SetControls();
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            Form form = new AboutBoxForm();
            form.ShowDialog();
            SetControls();
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
                    this.p1 = p1;
                    this.p2 = p2;
                    game = new Game(this.p1, this.p2);
                    SetControls();
                }
            }
            else
            {
                MessageBox.Show("No player selected");
            }

        }

        private void SetControls()
        {
            // values
            labelPlayerOneOnTable.Text = $"Cards from {p1?.PlayerName} on table:";
            labelPlayerOneCardsOnHand.Text = $"Cards on hand {p1?.CardCount}";
            labelPlayerTwoOnTable.Text = $"Cards from {p2?.PlayerName} on table:";
            labelPlayerTwoCardsOnHand.Text = $"Cards on hand {p2?.CardCount}";

            // visibility
            labelPlayerOneOnTable.Visible = p1 != null;
            labelPlayerOneCardsOnHand.Visible = p1 != null;
            labelPlayerTwoOnTable.Visible = p2 != null;
            labelPlayerTwoCardsOnHand.Visible = p2 != null;

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
            SetControls();
        }

        private void ButtonAutoPlay_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                while (game.Winner == null)
                {
                    game.PlayRound();
                    SetControls();

                }
                MessageBox.Show($"Winner is {game.Winner.PlayerName}");
                SetControls();
            }
        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                game.StartGame();
                SetControls();
            }
        }

    }
}