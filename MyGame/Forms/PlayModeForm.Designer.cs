using System.ComponentModel;

namespace MyGame.Forms
{
    partial class PlayModeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.buttonSingle = new System.Windows.Forms.Button();
            this.buttonHost = new System.Windows.Forms.Button();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSingle
            // 
            this.buttonSingle.Location = new System.Drawing.Point(69, 33);
            this.buttonSingle.Name = "buttonSingle";
            this.buttonSingle.Size = new System.Drawing.Size(225, 41);
            this.buttonSingle.TabIndex = 0;
            this.buttonSingle.Text = "Single Player";
            this.buttonSingle.UseVisualStyleBackColor = true;
            this.buttonSingle.Click += new System.EventHandler(this.buttonSingle_Click);
            // 
            // buttonHost
            // 
            this.buttonHost.Location = new System.Drawing.Point(69, 80);
            this.buttonHost.Name = "buttonHost";
            this.buttonHost.Size = new System.Drawing.Size(225, 41);
            this.buttonHost.TabIndex = 1;
            this.buttonHost.Text = "Host a Game";
            this.buttonHost.UseVisualStyleBackColor = true;
            this.buttonHost.Click += new System.EventHandler(this.buttonHost_Click);
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(69, 127);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(225, 41);
            this.buttonJoin.TabIndex = 2;
            this.buttonJoin.Text = "Join a Game";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // PlayModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 207);
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.buttonHost);
            this.Controls.Add(this.buttonSingle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PlayModeForm";
            this.Text = "PlayModeForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonSingle;
        private System.Windows.Forms.Button buttonHost;
        private System.Windows.Forms.Button buttonJoin;

        #endregion
    }
}