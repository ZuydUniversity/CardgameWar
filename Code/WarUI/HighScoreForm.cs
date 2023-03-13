using War.Model;

namespace WarUI
{
    public partial class HighScoreForm : Form
    {
        public HighScoreForm()
        {
            InitializeComponent();
            var players = Player.ReadPlayersHigscoreData();
            dataGridViewHighScores.DataSource = players;
        }
    }
}
