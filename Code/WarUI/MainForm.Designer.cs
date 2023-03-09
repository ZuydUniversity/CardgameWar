namespace WarUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStripMain = new MenuStrip();
            menuItemManagePlayers = new ToolStripMenuItem();
            menuItemHighScore = new ToolStripMenuItem();
            MenuItemAbout = new ToolStripMenuItem();
            panelPlayerOne = new Panel();
            labelPlayerOneCardsOnHand = new Label();
            labelPlayerOne = new Label();
            comboPlayerOne = new ComboBox();
            panelGame = new Panel();
            labelPlayerTwoOnTable = new Label();
            labelPlayerOneOnTable = new Label();
            buttonAutoPlay = new Button();
            buttonEndGame = new Button();
            buttonStartGame = new Button();
            buttonCreateGame = new Button();
            panelPlayerTwo = new Panel();
            labelPlayerTwoCardsOnHand = new Label();
            labelPlayerTwo = new Label();
            comboPlayerTwo = new ComboBox();
            menuStripMain.SuspendLayout();
            panelPlayerOne.SuspendLayout();
            panelGame.SuspendLayout();
            panelPlayerTwo.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.Items.AddRange(new ToolStripItem[] { menuItemManagePlayers, menuItemHighScore, MenuItemAbout });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(999, 24);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "menuStrip1";
            // 
            // menuItemManagePlayers
            // 
            menuItemManagePlayers.Name = "menuItemManagePlayers";
            menuItemManagePlayers.Size = new Size(56, 20);
            menuItemManagePlayers.Text = "Players";
            menuItemManagePlayers.Click += MenuItemManagePlayers_Click;
            // 
            // menuItemHighScore
            // 
            menuItemHighScore.Name = "menuItemHighScore";
            menuItemHighScore.Size = new Size(73, 20);
            menuItemHighScore.Text = "Highscore";
            menuItemHighScore.Click += MenuItemHighScore_Click;
            // 
            // MenuItemAbout
            // 
            MenuItemAbout.Name = "MenuItemAbout";
            MenuItemAbout.Size = new Size(52, 20);
            MenuItemAbout.Text = "About";
            MenuItemAbout.Click += MenuItemAbout_Click;
            // 
            // panelPlayerOne
            // 
            panelPlayerOne.Controls.Add(labelPlayerOneCardsOnHand);
            panelPlayerOne.Controls.Add(labelPlayerOne);
            panelPlayerOne.Controls.Add(comboPlayerOne);
            panelPlayerOne.Dock = DockStyle.Left;
            panelPlayerOne.Location = new Point(0, 24);
            panelPlayerOne.Name = "panelPlayerOne";
            panelPlayerOne.Size = new Size(200, 506);
            panelPlayerOne.TabIndex = 1;
            // 
            // labelPlayerOneCardsOnHand
            // 
            labelPlayerOneCardsOnHand.AutoSize = true;
            labelPlayerOneCardsOnHand.Location = new Point(12, 131);
            labelPlayerOneCardsOnHand.Name = "labelPlayerOneCardsOnHand";
            labelPlayerOneCardsOnHand.Size = new Size(38, 15);
            labelPlayerOneCardsOnHand.TabIndex = 2;
            labelPlayerOneCardsOnHand.Text = "label1";
            // 
            // labelPlayerOne
            // 
            labelPlayerOne.AutoSize = true;
            labelPlayerOne.Location = new Point(12, 9);
            labelPlayerOne.Name = "labelPlayerOne";
            labelPlayerOne.Size = new Size(96, 15);
            labelPlayerOne.TabIndex = 1;
            labelPlayerOne.Text = "Select player one";
            // 
            // comboPlayerOne
            // 
            comboPlayerOne.FormattingEnabled = true;
            comboPlayerOne.Location = new Point(12, 27);
            comboPlayerOne.Name = "comboPlayerOne";
            comboPlayerOne.Size = new Size(171, 23);
            comboPlayerOne.TabIndex = 0;
            // 
            // panelGame
            // 
            panelGame.Controls.Add(labelPlayerTwoOnTable);
            panelGame.Controls.Add(labelPlayerOneOnTable);
            panelGame.Controls.Add(buttonAutoPlay);
            panelGame.Controls.Add(buttonEndGame);
            panelGame.Controls.Add(buttonStartGame);
            panelGame.Controls.Add(buttonCreateGame);
            panelGame.Dock = DockStyle.Fill;
            panelGame.Location = new Point(200, 24);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(799, 506);
            panelGame.TabIndex = 1;
            // 
            // labelPlayerTwoOnTable
            // 
            labelPlayerTwoOnTable.AutoSize = true;
            labelPlayerTwoOnTable.Location = new Point(314, 106);
            labelPlayerTwoOnTable.Name = "labelPlayerTwoOnTable";
            labelPlayerTwoOnTable.Size = new Size(110, 15);
            labelPlayerTwoOnTable.TabIndex = 3;
            labelPlayerTwoOnTable.Text = "Player One on table";
            // 
            // labelPlayerOneOnTable
            // 
            labelPlayerOneOnTable.AutoSize = true;
            labelPlayerOneOnTable.Location = new Point(32, 106);
            labelPlayerOneOnTable.Name = "labelPlayerOneOnTable";
            labelPlayerOneOnTable.Size = new Size(110, 15);
            labelPlayerOneOnTable.TabIndex = 3;
            labelPlayerOneOnTable.Text = "Player One on table";
            // 
            // buttonAutoPlay
            // 
            buttonAutoPlay.Location = new Point(194, 27);
            buttonAutoPlay.Name = "buttonAutoPlay";
            buttonAutoPlay.Size = new Size(75, 23);
            buttonAutoPlay.TabIndex = 1;
            buttonAutoPlay.Text = "Autoplay";
            buttonAutoPlay.UseVisualStyleBackColor = true;
            buttonAutoPlay.Click += ButtonAutoPlay_Click;
            // 
            // buttonEndGame
            // 
            buttonEndGame.Location = new Point(275, 27);
            buttonEndGame.Name = "buttonEndGame";
            buttonEndGame.Size = new Size(75, 23);
            buttonEndGame.TabIndex = 0;
            buttonEndGame.Text = "End game";
            buttonEndGame.UseVisualStyleBackColor = true;
            buttonEndGame.Click += ButtonEndGame_Click;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(113, 26);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(75, 23);
            buttonStartGame.TabIndex = 0;
            buttonStartGame.Text = "Start game";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += ButtonStartGame_Click;
            // 
            // buttonCreateGame
            // 
            buttonCreateGame.Location = new Point(32, 26);
            buttonCreateGame.Name = "buttonCreateGame";
            buttonCreateGame.Size = new Size(75, 23);
            buttonCreateGame.TabIndex = 0;
            buttonCreateGame.Text = "Create game";
            buttonCreateGame.UseVisualStyleBackColor = true;
            buttonCreateGame.Click += ButtonCreateGame_Click;
            // 
            // panelPlayerTwo
            // 
            panelPlayerTwo.Controls.Add(labelPlayerTwoCardsOnHand);
            panelPlayerTwo.Controls.Add(labelPlayerTwo);
            panelPlayerTwo.Controls.Add(comboPlayerTwo);
            panelPlayerTwo.Dock = DockStyle.Right;
            panelPlayerTwo.Location = new Point(799, 24);
            panelPlayerTwo.Name = "panelPlayerTwo";
            panelPlayerTwo.Size = new Size(200, 506);
            panelPlayerTwo.TabIndex = 1;
            // 
            // labelPlayerTwoCardsOnHand
            // 
            labelPlayerTwoCardsOnHand.AutoSize = true;
            labelPlayerTwoCardsOnHand.Location = new Point(12, 131);
            labelPlayerTwoCardsOnHand.Name = "labelPlayerTwoCardsOnHand";
            labelPlayerTwoCardsOnHand.Size = new Size(38, 15);
            labelPlayerTwoCardsOnHand.TabIndex = 2;
            labelPlayerTwoCardsOnHand.Text = "label1";
            // 
            // labelPlayerTwo
            // 
            labelPlayerTwo.AutoSize = true;
            labelPlayerTwo.Location = new Point(12, 9);
            labelPlayerTwo.Name = "labelPlayerTwo";
            labelPlayerTwo.Size = new Size(96, 15);
            labelPlayerTwo.TabIndex = 1;
            labelPlayerTwo.Text = "Select player two";
            // 
            // comboPlayerTwo
            // 
            comboPlayerTwo.FormattingEnabled = true;
            comboPlayerTwo.Location = new Point(12, 27);
            comboPlayerTwo.Name = "comboPlayerTwo";
            comboPlayerTwo.Size = new Size(171, 23);
            comboPlayerTwo.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 530);
            Controls.Add(panelPlayerTwo);
            Controls.Add(panelGame);
            Controls.Add(panelPlayerOne);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Card game";
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            panelPlayerOne.ResumeLayout(false);
            panelPlayerOne.PerformLayout();
            panelGame.ResumeLayout(false);
            panelGame.PerformLayout();
            panelPlayerTwo.ResumeLayout(false);
            panelPlayerTwo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem menuItemManagePlayers;
        private ToolStripMenuItem menuItemHighScore;
        private ToolStripMenuItem MenuItemAbout;
        private Panel panelPlayerOne;
        private Label labelPlayerOne;
        private ComboBox comboPlayerOne;
        private Panel panelGame;
        private Button buttonCreateGame;
        private Panel panelPlayerTwo;
        private Label labelPlayerTwo;
        private ComboBox comboPlayerTwo;
        private Button buttonEndGame;
        private Button button1;
        private Button buttonStartGame;
        private Button buttonAutoPlay;
        private Label labelPlayerOneCardsOnHand;
        private Label labelPlayerTwoOnTable;
        private Label labelPlayerOneOnTable;
        private Label labelPlayerTwoCardsOnHand;
    }
}