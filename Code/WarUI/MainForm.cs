using War.DataAccess;
using War.Model;
using static System.Windows.Forms.ListView;

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
            StackToListviewItemCollection(lvCardsPlayerOne.Items, game?.PlayerOnePlayedCards);
            StackToListviewItemCollection(lvCardsPlayerTwo.Items, game?.PlayerTwoPlayedCards);
            buttonPlayTurn.Text = game != null ? $"Play turn: {game.Turn} starts" : string.Empty;

            // refresh
            lvCardsPlayerOne.Refresh();
            lvCardsPlayerTwo.Refresh();
            labelPlayerOneCardsOnHand.Refresh();
            labelPlayerTwoCardsOnHand.Refresh();

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
            buttonPlayTurn.Enabled = game != null && game.GameStarted;
        }

        private void ButtonEndGame_Click(object sender, EventArgs e)
        {
            game.EndGame();
            game = null;
            SetControls();
        }

        private void buttonPlayTurn_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                game.PlayRound();
                SetControls();
                if (game != null && game.Winner != null)
                {
                    MessageBox.Show($"Winner is {game.Winner.PlayerName}");
                }
            }
        }

        private void ButtonAutoPlay_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                while (game.Winner == null)
                {
                    game.PlayRound();
                    SetControls();
                    Thread.Sleep(100);
                }
                MessageBox.Show($"Winner is {game.Winner.PlayerName}");
                SetControls();
            }
        }

        /// <summary>
        /// Helper method to show cards in listview
        /// </summary>
        /// <param name="lvc"></param>
        /// <param name="stack"></param>
        private void StackToListviewItemCollection(ListViewItemCollection lvc, Stack<Card>? stack)
        {
            lvc.Clear();

            if (stack == null)
                return;

            foreach (var item in stack.Select(c => c.ToString()))
            {
                lvc.Add(item);
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