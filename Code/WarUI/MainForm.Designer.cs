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
            labelPlayerOne = new Label();
            comboPlayerOne = new ComboBox();
            panelGame = new Panel();
            checkBoxAutoPlay = new CheckBox();
            buttonEndGame = new Button();
            buttonStartGame = new Button();
            buttonCreateGame = new Button();
            panelPlayerTwo = new Panel();
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
            menuItemHighScore.Click += menuItemHighScore_Click;
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
            panelPlayerOne.Controls.Add(labelPlayerOne);
            panelPlayerOne.Controls.Add(comboPlayerOne);
            panelPlayerOne.Dock = DockStyle.Left;
            panelPlayerOne.Location = new Point(0, 24);
            panelPlayerOne.Name = "panelPlayerOne";
            panelPlayerOne.Size = new Size(200, 506);
            panelPlayerOne.TabIndex = 1;
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
            panelGame.Controls.Add(checkBoxAutoPlay);
            panelGame.Controls.Add(buttonEndGame);
            panelGame.Controls.Add(buttonStartGame);
            panelGame.Controls.Add(buttonCreateGame);
            panelGame.Dock = DockStyle.Fill;
            panelGame.Location = new Point(200, 24);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(799, 506);
            panelGame.TabIndex = 1;
            // 
            // checkBoxAutoPlay
            // 
            checkBoxAutoPlay.AutoSize = true;
            checkBoxAutoPlay.Checked = true;
            checkBoxAutoPlay.CheckState = CheckState.Checked;
            checkBoxAutoPlay.Location = new Point(275, 31);
            checkBoxAutoPlay.Name = "checkBoxAutoPlay";
            checkBoxAutoPlay.Size = new Size(77, 19);
            checkBoxAutoPlay.TabIndex = 1;
            checkBoxAutoPlay.Text = "Auto play";
            checkBoxAutoPlay.UseVisualStyleBackColor = true;
            // 
            // buttonEndGame
            // 
            buttonEndGame.Location = new Point(194, 26);
            buttonEndGame.Name = "buttonEndGame";
            buttonEndGame.Size = new Size(75, 23);
            buttonEndGame.TabIndex = 0;
            buttonEndGame.Text = "End game";
            buttonEndGame.UseVisualStyleBackColor = true;
            buttonEndGame.Click += buttonEndGame_Click;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(113, 26);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(75, 23);
            buttonStartGame.TabIndex = 0;
            buttonStartGame.Text = "Start game";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += buttonStartGame_Click;
            // 
            // buttonCreateGame
            // 
            buttonCreateGame.Location = new Point(32, 26);
            buttonCreateGame.Name = "buttonCreateGame";
            buttonCreateGame.Size = new Size(75, 23);
            buttonCreateGame.TabIndex = 0;
            buttonCreateGame.Text = "Create game";
            buttonCreateGame.UseVisualStyleBackColor = true;
            buttonCreateGame.Click += buttonStartGame_Click;
            // 
            // panelPlayerTwo
            // 
            panelPlayerTwo.Controls.Add(labelPlayerTwo);
            panelPlayerTwo.Controls.Add(comboPlayerTwo);
            panelPlayerTwo.Dock = DockStyle.Right;
            panelPlayerTwo.Location = new Point(799, 24);
            panelPlayerTwo.Name = "panelPlayerTwo";
            panelPlayerTwo.Size = new Size(200, 506);
            panelPlayerTwo.TabIndex = 1;
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
        private CheckBox checkBoxAutoPlay;
    }
}