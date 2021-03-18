
namespace DurakGame
{
    partial class frmHowToPlay
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
            this.btnMenu = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMenu.BackColor = System.Drawing.SystemColors.Info;
            this.btnMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnMenu.Location = new System.Drawing.Point(630, 380);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(130, 60);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "&Back";
            this.toolTip1.SetToolTip(this.btnMenu, "Click to go Main Menu");
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // frmHowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DurakGame.Properties.Resources.Durak;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnMenu);
            this.Name = "frmHowToPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HowToPlay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}