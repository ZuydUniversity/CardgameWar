using War;

namespace WarUI
{
    public partial class MainForm : Form
    {
        public Deck TheDeck { get; set; }

        public int Nummertje { get; set; }


        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonCreateDeck_Click(object sender, EventArgs e)
        {
            TheDeck = new Deck(null);
            TheDeck.ShuffleCards();
            Form form = new AnderForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

    }
}