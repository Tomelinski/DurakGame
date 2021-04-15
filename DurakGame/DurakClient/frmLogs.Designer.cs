
namespace DurakClient
{
    partial class frmGameLogs
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
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOpenLogs = new System.Windows.Forms.Button();
            this.btnOpenStats = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtDelete = new System.Windows.Forms.TextBox();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.lblGamesTitle = new System.Windows.Forms.Label();
            this.lblWinsTitle = new System.Windows.Forms.Label();
            this.lblLossesTitle = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblGames = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(12, 129);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(108, 34);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "&Find User";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 232);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 34);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete User";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpenLogs
            // 
            this.btnOpenLogs.Location = new System.Drawing.Point(12, 316);
            this.btnOpenLogs.Name = "btnOpenLogs";
            this.btnOpenLogs.Size = new System.Drawing.Size(140, 34);
            this.btnOpenLogs.TabIndex = 4;
            this.btnOpenLogs.Text = "Open &Logs";
            this.btnOpenLogs.UseVisualStyleBackColor = true;
            this.btnOpenLogs.Click += new System.EventHandler(this.btnOpenLogs_Click);
            // 
            // btnOpenStats
            // 
            this.btnOpenStats.Location = new System.Drawing.Point(12, 363);
            this.btnOpenStats.Name = "btnOpenStats";
            this.btnOpenStats.Size = new System.Drawing.Size(140, 34);
            this.btnOpenStats.TabIndex = 5;
            this.btnOpenStats.Text = "Open &Stats";
            this.btnOpenStats.UseVisualStyleBackColor = true;
            this.btnOpenStats.Click += new System.EventHandler(this.btnOpenStats_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(632, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 34);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(13, 84);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(139, 31);
            this.txtFind.TabIndex = 0;
            this.txtFind.Enter += new System.EventHandler(this.txtFind_Enter);
            // 
            // txtDelete
            // 
            this.txtDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelete.Location = new System.Drawing.Point(13, 195);
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.Size = new System.Drawing.Size(139, 31);
            this.txtDelete.TabIndex = 2;
            this.txtDelete.Enter += new System.EventHandler(this.txtDelete_Enter);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameTitle.Location = new System.Drawing.Point(215, 83);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(112, 50);
            this.lblNameTitle.TabIndex = 8;
            this.lblNameTitle.Text = "Name";
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGamesTitle
            // 
            this.lblGamesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGamesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamesTitle.Location = new System.Drawing.Point(333, 83);
            this.lblGamesTitle.Name = "lblGamesTitle";
            this.lblGamesTitle.Size = new System.Drawing.Size(112, 50);
            this.lblGamesTitle.TabIndex = 9;
            this.lblGamesTitle.Text = "Games";
            this.lblGamesTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWinsTitle
            // 
            this.lblWinsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWinsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinsTitle.Location = new System.Drawing.Point(451, 83);
            this.lblWinsTitle.Name = "lblWinsTitle";
            this.lblWinsTitle.Size = new System.Drawing.Size(112, 50);
            this.lblWinsTitle.TabIndex = 10;
            this.lblWinsTitle.Text = "Wins";
            this.lblWinsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLossesTitle
            // 
            this.lblLossesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLossesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLossesTitle.Location = new System.Drawing.Point(569, 83);
            this.lblLossesTitle.Name = "lblLossesTitle";
            this.lblLossesTitle.Size = new System.Drawing.Size(112, 50);
            this.lblLossesTitle.TabIndex = 11;
            this.lblLossesTitle.Text = "Losses";
            this.lblLossesTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLosses
            // 
            this.lblLosses.BackColor = System.Drawing.Color.Transparent;
            this.lblLosses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLosses.Location = new System.Drawing.Point(569, 149);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(112, 50);
            this.lblLosses.TabIndex = 15;
            this.lblLosses.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWins
            // 
            this.lblWins.BackColor = System.Drawing.Color.Transparent;
            this.lblWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWins.Location = new System.Drawing.Point(451, 149);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(112, 50);
            this.lblWins.TabIndex = 14;
            this.lblWins.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGames
            // 
            this.lblGames.BackColor = System.Drawing.Color.Transparent;
            this.lblGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGames.Location = new System.Drawing.Point(333, 149);
            this.lblGames.Name = "lblGames";
            this.lblGames.Size = new System.Drawing.Size(112, 50);
            this.lblGames.TabIndex = 13;
            this.lblGames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(215, 149);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(112, 50);
            this.lblName.TabIndex = 12;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmGameLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DurakClient.Properties.Resources.DurakOptionsBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblLosses);
            this.Controls.Add(this.lblWins);
            this.Controls.Add(this.lblGames);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLossesTitle);
            this.Controls.Add(this.lblWinsTitle);
            this.Controls.Add(this.lblGamesTitle);
            this.Controls.Add(this.lblNameTitle);
            this.Controls.Add(this.txtDelete);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOpenStats);
            this.Controls.Add(this.btnOpenLogs);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFind);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmGameLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs and Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOpenLogs;
        private System.Windows.Forms.Button btnOpenStats;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtDelete;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Label lblGamesTitle;
        private System.Windows.Forms.Label lblWinsTitle;
        private System.Windows.Forms.Label lblLossesTitle;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblGames;
        private System.Windows.Forms.Label lblName;
    }
}