
namespace DurakClient
{
    partial class frmStartMenu
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
            this.gbxPlayersNum = new System.Windows.Forms.GroupBox();
            this.rdb4Players = new System.Windows.Forms.RadioButton();
            this.rdb3Players = new System.Windows.Forms.RadioButton();
            this.rdb2Players = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.gbxDeckSize = new System.Windows.Forms.GroupBox();
            this.rdbDeck52 = new System.Windows.Forms.RadioButton();
            this.rdbDeck36 = new System.Windows.Forms.RadioButton();
            this.rdbDeck20 = new System.Windows.Forms.RadioButton();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.gbxPlayersNum.SuspendLayout();
            this.gbxDeckSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPlayersNum
            // 
            this.gbxPlayersNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPlayersNum.BackColor = System.Drawing.Color.Transparent;
            this.gbxPlayersNum.Controls.Add(this.rdb4Players);
            this.gbxPlayersNum.Controls.Add(this.rdb3Players);
            this.gbxPlayersNum.Controls.Add(this.rdb2Players);
            this.gbxPlayersNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbxPlayersNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.gbxPlayersNum.Location = new System.Drawing.Point(128, 187);
            this.gbxPlayersNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxPlayersNum.Name = "gbxPlayersNum";
            this.gbxPlayersNum.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxPlayersNum.Size = new System.Drawing.Size(885, 123);
            this.gbxPlayersNum.TabIndex = 0;
            this.gbxPlayersNum.TabStop = false;
            this.gbxPlayersNum.Text = "Players:";
            this.toolTip1.SetToolTip(this.gbxPlayersNum, "Click a button to choose the amount of players you want");
            // 
            // rdb4Players
            // 
            this.rdb4Players.AutoSize = true;
            this.rdb4Players.Enabled = false;
            this.rdb4Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb4Players.Location = new System.Drawing.Point(632, 58);
            this.rdb4Players.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb4Players.Name = "rdb4Players";
            this.rdb4Players.Size = new System.Drawing.Size(163, 36);
            this.rdb4Players.TabIndex = 2;
            this.rdb4Players.Text = "4 Players";
            this.rdb4Players.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.rdb4Players, "Click to choose 4 Players");
            this.rdb4Players.UseVisualStyleBackColor = true;
            // 
            // rdb3Players
            // 
            this.rdb3Players.AutoSize = true;
            this.rdb3Players.Enabled = false;
            this.rdb3Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb3Players.Location = new System.Drawing.Point(328, 58);
            this.rdb3Players.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb3Players.Name = "rdb3Players";
            this.rdb3Players.Size = new System.Drawing.Size(163, 36);
            this.rdb3Players.TabIndex = 1;
            this.rdb3Players.Text = "3 Players";
            this.rdb3Players.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.rdb3Players, "Click to choose 3 Players");
            this.rdb3Players.UseVisualStyleBackColor = true;
            // 
            // rdb2Players
            // 
            this.rdb2Players.AutoSize = true;
            this.rdb2Players.Checked = true;
            this.rdb2Players.Location = new System.Drawing.Point(33, 58);
            this.rdb2Players.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb2Players.Name = "rdb2Players";
            this.rdb2Players.Size = new System.Drawing.Size(157, 35);
            this.rdb2Players.TabIndex = 0;
            this.rdb2Players.TabStop = true;
            this.rdb2Players.Text = "2 Players";
            this.rdb2Players.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.rdb2Players, "Click to choose 2 Players");
            this.rdb2Players.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnStart.Location = new System.Drawing.Point(840, 468);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 74);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "&Start";
            this.toolTip1.SetToolTip(this.btnStart, "Click to start the game");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPlayerName.Location = new System.Drawing.Point(456, 140);
            this.txtPlayerName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(201, 38);
            this.txtPlayerName.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtPlayerName, "Click to Enter Player Name");
            // 
            // gbxDeckSize
            // 
            this.gbxDeckSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDeckSize.BackColor = System.Drawing.Color.Transparent;
            this.gbxDeckSize.Controls.Add(this.rdbDeck52);
            this.gbxDeckSize.Controls.Add(this.rdbDeck36);
            this.gbxDeckSize.Controls.Add(this.rdbDeck20);
            this.gbxDeckSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbxDeckSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxDeckSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.gbxDeckSize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbxDeckSize.Location = new System.Drawing.Point(128, 380);
            this.gbxDeckSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxDeckSize.Name = "gbxDeckSize";
            this.gbxDeckSize.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxDeckSize.Size = new System.Drawing.Size(693, 123);
            this.gbxDeckSize.TabIndex = 1;
            this.gbxDeckSize.TabStop = false;
            this.gbxDeckSize.Text = "Deck Size:";
            this.toolTip1.SetToolTip(this.gbxDeckSize, "Click a button to choose the amount of Cards you want");
            // 
            // rdbDeck52
            // 
            this.rdbDeck52.AutoSize = true;
            this.rdbDeck52.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.rdbDeck52.Location = new System.Drawing.Point(568, 58);
            this.rdbDeck52.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbDeck52.Name = "rdbDeck52";
            this.rdbDeck52.Size = new System.Drawing.Size(67, 35);
            this.rdbDeck52.TabIndex = 2;
            this.rdbDeck52.Text = "52";
            this.rdbDeck52.UseVisualStyleBackColor = true;
            // 
            // rdbDeck36
            // 
            this.rdbDeck36.AutoSize = true;
            this.rdbDeck36.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.rdbDeck36.Location = new System.Drawing.Point(313, 58);
            this.rdbDeck36.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbDeck36.Name = "rdbDeck36";
            this.rdbDeck36.Size = new System.Drawing.Size(67, 35);
            this.rdbDeck36.TabIndex = 1;
            this.rdbDeck36.Text = "36";
            this.rdbDeck36.UseVisualStyleBackColor = true;
            // 
            // rdbDeck20
            // 
            this.rdbDeck20.AutoSize = true;
            this.rdbDeck20.Checked = true;
            this.rdbDeck20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.rdbDeck20.Location = new System.Drawing.Point(33, 58);
            this.rdbDeck20.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbDeck20.Name = "rdbDeck20";
            this.rdbDeck20.Size = new System.Drawing.Size(67, 35);
            this.rdbDeck20.TabIndex = 0;
            this.rdbDeck20.TabStop = true;
            this.rdbDeck20.Text = "20";
            this.rdbDeck20.UseVisualStyleBackColor = true;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblPlayerName.Location = new System.Drawing.Point(305, 142);
            this.lblPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(99, 31);
            this.lblPlayerName.TabIndex = 6;
            this.lblPlayerName.Text = "Name:";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmStartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = global::DurakClient.Properties.Resources.Durak;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbxDeckSize);
            this.Controls.Add(this.gbxPlayersNum);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1061, 605);
            this.Name = "frmStartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartMenu";
            this.gbxPlayersNum.ResumeLayout(false);
            this.gbxPlayersNum.PerformLayout();
            this.gbxDeckSize.ResumeLayout(false);
            this.gbxDeckSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPlayersNum;
        private System.Windows.Forms.RadioButton rdb4Players;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton rdb3Players;
        private System.Windows.Forms.RadioButton rdb2Players;
        private System.Windows.Forms.GroupBox gbxDeckSize;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.RadioButton rdbDeck52;
        private System.Windows.Forms.RadioButton rdbDeck36;
        private System.Windows.Forms.RadioButton rdbDeck20;
    }
}