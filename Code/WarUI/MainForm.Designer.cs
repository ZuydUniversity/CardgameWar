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
            buttonCreateDeck.Location = new Point(30, 35);
            buttonCreateDeck.Name = "buttonCreateDeck";
            buttonCreateDeck.Size = new Size(209, 72);
            buttonCreateDeck.TabIndex = 0;
            buttonCreateDeck.Text = "Create deck";
            buttonCreateDeck.UseVisualStyleBackColor = true;
            buttonCreateDeck.Click += buttonCreateDeck_Click;
            // 
            // dataGridViewPlayer
            // 
            dataGridViewPlayer.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewPlayer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlayer.Location = new Point(286, 35);
            dataGridViewPlayer.Margin = new Padding(3, 4, 3, 4);
            dataGridViewPlayer.Name = "dataGridViewPlayer";
            dataGridViewPlayer.RowHeadersWidth = 51;
            dataGridViewPlayer.RowTemplate.Height = 25;
            dataGridViewPlayer.Size = new Size(488, 287);
            dataGridViewPlayer.TabIndex = 1;
            // 
            // buttonLoadPlayers
            // 
            buttonLoadPlayers.Location = new Point(33, 135);
            buttonLoadPlayers.Margin = new Padding(3, 4, 3, 4);
            buttonLoadPlayers.Name = "buttonLoadPlayers";
            buttonLoadPlayers.Size = new Size(206, 71);
            buttonLoadPlayers.TabIndex = 2;
            buttonLoadPlayers.Text = "Load players";
            buttonLoadPlayers.UseVisualStyleBackColor = true;
            buttonLoadPlayers.Click += buttonLoadPlayers_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(buttonLoadPlayers);
            Controls.Add(dataGridViewPlayer);
            Controls.Add(buttonCreateDeck);
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