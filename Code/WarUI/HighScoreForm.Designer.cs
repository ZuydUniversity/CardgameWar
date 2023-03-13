namespace WarUI
{
    partial class HighScoreForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHighScore = new Panel();
            dataGridViewHighScores = new DataGridView();
            panelHighScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHighScores).BeginInit();
            SuspendLayout();
            // 
            // panelHighScore
            // 
            panelHighScore.Controls.Add(dataGridViewHighScores);
            panelHighScore.Dock = DockStyle.Fill;
            panelHighScore.Location = new Point(0, 0);
            panelHighScore.Name = "panelHighScore";
            panelHighScore.Size = new Size(800, 450);
            panelHighScore.TabIndex = 0;
            // 
            // dataGridViewHighScores
            // 
            dataGridViewHighScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHighScores.Dock = DockStyle.Fill;
            dataGridViewHighScores.Location = new Point(0, 0);
            dataGridViewHighScores.Name = "dataGridViewHighScores";
            dataGridViewHighScores.RowTemplate.Height = 25;
            dataGridViewHighScores.Size = new Size(800, 450);
            dataGridViewHighScores.TabIndex = 0;
            // 
            // HighScoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelHighScore);
            Name = "HighScoreForm";
            Text = "Highscore";
            panelHighScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHighScores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHighScore;
        private DataGridView dataGridViewHighScores;
    }
}