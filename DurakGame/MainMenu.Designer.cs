
namespace DurakGame
{
    partial class frmDurakMainMenu
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
            this.components = new System.ComponentModel.Container();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnInstructions = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPlay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnPlay.Location = new System.Drawing.Point(284, 132);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(180, 60);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.toolTip1.SetToolTip(this.btnPlay, "Click to Start the Game");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnInstructions
            // 
            this.btnInstructions.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnInstructions.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnInstructions.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnInstructions.Location = new System.Drawing.Point(284, 226);
            this.btnInstructions.Name = "btnInstructions";
            this.btnInstructions.Size = new System.Drawing.Size(180, 60);
            this.btnInstructions.TabIndex = 1;
            this.btnInstructions.Text = "&How to Play";
            this.toolTip1.SetToolTip(this.btnInstructions, "How to Play the Game");
            this.btnInstructions.UseVisualStyleBackColor = true;
            this.btnInstructions.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnQuit.Location = new System.Drawing.Point(630, 380);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(130, 60);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "&Quit";
            this.toolTip1.SetToolTip(this.btnQuit, "Click To Exit Game");
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnLogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogs.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnLogs.Location = new System.Drawing.Point(284, 324);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(180, 60);
            this.btnLogs.TabIndex = 4;
            this.btnLogs.Text = "&Logs and Statistics";
            this.toolTip1.SetToolTip(this.btnLogs, "Click for Logs and Statistics");
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // frmDurakMainMenu
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DurakGame.Properties.Resources.Durak;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnInstructions);
            this.Controls.Add(this.btnPlay);
            this.MaximizeBox = false;
            this.Name = "frmDurakMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnInstructions;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnLogs;
    }
}