namespace CardBox
{
    partial class CardBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbCardPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCardPictureBox
            // 
            this.pbCardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCardPictureBox.Location = new System.Drawing.Point(0, 0);
            this.pbCardPictureBox.Name = "pbCardPictureBox";
            this.pbCardPictureBox.Size = new System.Drawing.Size(76, 110);
            this.pbCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCardPictureBox.TabIndex = 0;
            this.pbCardPictureBox.TabStop = false;
            this.pbCardPictureBox.Click += new System.EventHandler(this.PbCardPictureBox_Click);
            this.pbCardPictureBox.MouseEnter += new System.EventHandler(this.PbCardPictureBox_MouseEnter);
            this.pbCardPictureBox.MouseLeave += new System.EventHandler(this.PbCardPictureBox_MouseLeave);
            // 
            // CardBox
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbCardPictureBox);
            this.Name = "CardBox";
            this.Size = new System.Drawing.Size(76, 110);
            this.Load += new System.EventHandler(this.CardBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCardPictureBox;
    }
}
