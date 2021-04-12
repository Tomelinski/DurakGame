
namespace DurakClient
{
    partial class frmDurak
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
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pbTrump = new System.Windows.Forms.PictureBox();
            this.pnlPlayerHand = new System.Windows.Forms.Panel();
            this.pnlOponentHand = new System.Windows.Forms.Panel();
            this.pnlPlayArea = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrump)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDeck
            // 
            this.pbDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDeck.BackColor = System.Drawing.Color.Transparent;
            this.pbDeck.Location = new System.Drawing.Point(11, 15);
            this.pbDeck.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(76, 110);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 0;
            this.pbDeck.TabStop = false;
            this.pbDeck.Click += new System.EventHandler(this.pbDeck_Click);
            // 
            // pbTrump
            // 
            this.pbTrump.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTrump.BackColor = System.Drawing.Color.Transparent;
            this.pbTrump.Location = new System.Drawing.Point(11, 49);
            this.pbTrump.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.pbTrump.Name = "pbTrump";
            this.pbTrump.Size = new System.Drawing.Size(104, 76);
            this.pbTrump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTrump.TabIndex = 1;
            this.pbTrump.TabStop = false;
            // 
            // pnlPlayerHand
            // 
            this.pnlPlayerHand.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayerHand.Location = new System.Drawing.Point(140, 324);
            this.pnlPlayerHand.Name = "pnlPlayerHand";
            this.pnlPlayerHand.Size = new System.Drawing.Size(498, 125);
            this.pnlPlayerHand.TabIndex = 2;
            // 
            // pnlOponentHand
            // 
            this.pnlOponentHand.Location = new System.Drawing.Point(140, 11);
            this.pnlOponentHand.Name = "pnlOponentHand";
            this.pnlOponentHand.Size = new System.Drawing.Size(498, 125);
            this.pnlOponentHand.TabIndex = 3;
            // 
            // pnlPlayArea
            // 
            this.pnlPlayArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayArea.Location = new System.Drawing.Point(106, 159);
            this.pnlPlayArea.Name = "pnlPlayArea";
            this.pnlPlayArea.Size = new System.Drawing.Size(570, 140);
            this.pnlPlayArea.TabIndex = 4;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(679, 335);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(93, 34);
            this.btnSkip.TabIndex = 5;
            this.btnSkip.Text = "Skip Turn";
            this.btnSkip.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(679, 415);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(93, 34);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // frmDurak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DurakClient.Properties.Resources.DurakOptionsBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.pnlPlayArea);
            this.Controls.Add(this.pnlOponentHand);
            this.Controls.Add(this.pnlPlayerHand);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.pbTrump);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmDurak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrump)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.PictureBox pbTrump;
        private System.Windows.Forms.Panel pnlPlayerHand;
        private System.Windows.Forms.Panel pnlOponentHand;
        private System.Windows.Forms.Panel pnlPlayArea;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnQuit;
    }
}