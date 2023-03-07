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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(buttonCreateDeck);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Card game";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateDeck;
    }
}