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
            buttonCreateDeck = new Button();
            dataGridViewPlayer = new DataGridView();
            buttonLoadPlayers = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayer).BeginInit();
            SuspendLayout();
            // 
            // buttonCreateDeck
            // 
            buttonCreateDeck.Location = new Point(26, 26);
            buttonCreateDeck.Margin = new Padding(3, 2, 3, 2);
            buttonCreateDeck.Name = "buttonCreateDeck";
            buttonCreateDeck.Size = new Size(183, 54);
            buttonCreateDeck.TabIndex = 0;
            buttonCreateDeck.Text = "Create deck";
            buttonCreateDeck.UseVisualStyleBackColor = true;
            buttonCreateDeck.Click += buttonCreateDeck_Click;
            // 
            // dataGridViewPlayer
            // 
            dataGridViewPlayer.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewPlayer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlayer.Location = new Point(250, 26);
            dataGridViewPlayer.Name = "dataGridViewPlayer";
            dataGridViewPlayer.RowTemplate.Height = 25;
            dataGridViewPlayer.Size = new Size(427, 215);
            dataGridViewPlayer.TabIndex = 1;
            // 
            // buttonLoadPlayers
            // 
            buttonLoadPlayers.Location = new Point(29, 101);
            buttonLoadPlayers.Name = "buttonLoadPlayers";
            buttonLoadPlayers.Size = new Size(180, 53);
            buttonLoadPlayers.TabIndex = 2;
            buttonLoadPlayers.Text = "Load players";
            buttonLoadPlayers.UseVisualStyleBackColor = true;
            buttonLoadPlayers.Click += buttonLoadPlayers_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(buttonLoadPlayers);
            Controls.Add(dataGridViewPlayer);
            Controls.Add(buttonCreateDeck);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Card game";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateDeck;
        private DataGridView dataGridViewPlayer;
        private Button buttonLoadPlayers;
    }
}