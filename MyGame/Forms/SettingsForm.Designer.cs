using System.ComponentModel;

namespace MyGame.Forms
{
    partial class SettingsForm
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
            this.groupboxDifficulty = new System.Windows.Forms.GroupBox();
            this.groupboxCustomSize = new System.Windows.Forms.GroupBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.textboxWidth = new System.Windows.Forms.TextBox();
            this.textboxLength = new System.Windows.Forms.TextBox();
            this.radiobuttonCustom = new System.Windows.Forms.RadioButton();
            this.radiobuttonHard = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.radiobuttonEasy = new System.Windows.Forms.RadioButton();
            this.groupboxShape = new System.Windows.Forms.GroupBox();
            this.radiobuttonTriangle = new System.Windows.Forms.RadioButton();
            this.radiobuttonSquare = new System.Windows.Forms.RadioButton();
            this.radiobuttonCircle = new System.Windows.Forms.RadioButton();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonCancelSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkboxBlue = new System.Windows.Forms.CheckBox();
            this.checkboxGreen = new System.Windows.Forms.CheckBox();
            this.checkboxRed = new System.Windows.Forms.CheckBox();
            this.groupboxDifficulty.SuspendLayout();
            this.groupboxCustomSize.SuspendLayout();
            this.groupboxShape.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxDifficulty
            // 
            this.groupboxDifficulty.Controls.Add(this.groupboxCustomSize);
            this.groupboxDifficulty.Controls.Add(this.radiobuttonCustom);
            this.groupboxDifficulty.Controls.Add(this.radiobuttonHard);
            this.groupboxDifficulty.Controls.Add(this.radioButtonNormal);
            this.groupboxDifficulty.Controls.Add(this.radiobuttonEasy);
            this.groupboxDifficulty.Location = new System.Drawing.Point(12, 12);
            this.groupboxDifficulty.Name = "groupboxDifficulty";
            this.groupboxDifficulty.Size = new System.Drawing.Size(604, 119);
            this.groupboxDifficulty.TabIndex = 0;
            this.groupboxDifficulty.TabStop = false;
            this.groupboxDifficulty.Text = "Difficulty";
            // 
            // groupboxCustomSize
            // 
            this.groupboxCustomSize.Controls.Add(this.labelWidth);
            this.groupboxCustomSize.Controls.Add(this.labelLength);
            this.groupboxCustomSize.Controls.Add(this.textboxWidth);
            this.groupboxCustomSize.Controls.Add(this.textboxLength);
            this.groupboxCustomSize.Enabled = false;
            this.groupboxCustomSize.Location = new System.Drawing.Point(483, 14);
            this.groupboxCustomSize.Name = "groupboxCustomSize";
            this.groupboxCustomSize.Size = new System.Drawing.Size(115, 99);
            this.groupboxCustomSize.TabIndex = 4;
            this.groupboxCustomSize.TabStop = false;
            this.groupboxCustomSize.Text = "Custom Size";
            // 
            // labelWidth
            // 
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelWidth.Location = new System.Drawing.Point(6, 54);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(66, 26);
            this.labelWidth.TabIndex = 3;
            this.labelWidth.Text = "Width";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLength
            // 
            this.labelLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelLength.Location = new System.Drawing.Point(6, 21);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(66, 26);
            this.labelLength.TabIndex = 2;
            this.labelLength.Text = "Length";
            this.labelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxWidth
            // 
            this.textboxWidth.Location = new System.Drawing.Point(78, 54);
            this.textboxWidth.Name = "textboxWidth";
            this.textboxWidth.Size = new System.Drawing.Size(31, 26);
            this.textboxWidth.TabIndex = 1;
            // 
            // textboxLength
            // 
            this.textboxLength.Location = new System.Drawing.Point(78, 21);
            this.textboxLength.Name = "textboxLength";
            this.textboxLength.Size = new System.Drawing.Size(31, 26);
            this.textboxLength.TabIndex = 0;
            // 
            // radiobuttonCustom
            // 
            this.radiobuttonCustom.Location = new System.Drawing.Point(362, 39);
            this.radiobuttonCustom.Name = "radiobuttonCustom";
            this.radiobuttonCustom.Size = new System.Drawing.Size(96, 39);
            this.radiobuttonCustom.TabIndex = 3;
            this.radiobuttonCustom.TabStop = true;
            this.radiobuttonCustom.Text = "Custom";
            this.radiobuttonCustom.UseVisualStyleBackColor = true;
            this.radiobuttonCustom.CheckedChanged += new System.EventHandler(this.radiobuttonCustom_CheckedChanged);
            // 
            // radiobuttonHard
            // 
            this.radiobuttonHard.Location = new System.Drawing.Point(248, 39);
            this.radiobuttonHard.Name = "radiobuttonHard";
            this.radiobuttonHard.Size = new System.Drawing.Size(86, 39);
            this.radiobuttonHard.TabIndex = 2;
            this.radiobuttonHard.TabStop = true;
            this.radiobuttonHard.Text = "Hard";
            this.radiobuttonHard.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.Location = new System.Drawing.Point(129, 39);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(94, 39);
            this.radioButtonNormal.TabIndex = 1;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // radiobuttonEasy
            // 
            this.radiobuttonEasy.Location = new System.Drawing.Point(37, 39);
            this.radiobuttonEasy.Name = "radiobuttonEasy";
            this.radiobuttonEasy.Size = new System.Drawing.Size(86, 39);
            this.radiobuttonEasy.TabIndex = 0;
            this.radiobuttonEasy.TabStop = true;
            this.radiobuttonEasy.Text = "Easy";
            this.radiobuttonEasy.UseVisualStyleBackColor = true;
            // 
            // groupboxShape
            // 
            this.groupboxShape.Controls.Add(this.radiobuttonTriangle);
            this.groupboxShape.Controls.Add(this.radiobuttonSquare);
            this.groupboxShape.Controls.Add(this.radiobuttonCircle);
            this.groupboxShape.Location = new System.Drawing.Point(12, 137);
            this.groupboxShape.Name = "groupboxShape";
            this.groupboxShape.Size = new System.Drawing.Size(604, 102);
            this.groupboxShape.TabIndex = 1;
            this.groupboxShape.TabStop = false;
            this.groupboxShape.Text = "Shape";
            // 
            // radiobuttonTriangle
            // 
            this.radiobuttonTriangle.Location = new System.Drawing.Point(386, 41);
            this.radiobuttonTriangle.Name = "radiobuttonTriangle";
            this.radiobuttonTriangle.Size = new System.Drawing.Size(122, 38);
            this.radiobuttonTriangle.TabIndex = 2;
            this.radiobuttonTriangle.TabStop = true;
            this.radiobuttonTriangle.Text = "Triangle ▲";
            this.radiobuttonTriangle.UseVisualStyleBackColor = true;
            // 
            // radiobuttonSquare
            // 
            this.radiobuttonSquare.Location = new System.Drawing.Point(231, 41);
            this.radiobuttonSquare.Name = "radiobuttonSquare";
            this.radiobuttonSquare.Size = new System.Drawing.Size(122, 38);
            this.radiobuttonSquare.TabIndex = 1;
            this.radiobuttonSquare.TabStop = true;
            this.radiobuttonSquare.Text = "Square ■";
            this.radiobuttonSquare.UseVisualStyleBackColor = true;
            // 
            // radiobuttonCircle
            // 
            this.radiobuttonCircle.Location = new System.Drawing.Point(96, 41);
            this.radiobuttonCircle.Name = "radiobuttonCircle";
            this.radiobuttonCircle.Size = new System.Drawing.Size(98, 38);
            this.radiobuttonCircle.TabIndex = 0;
            this.radiobuttonCircle.TabStop = true;
            this.radiobuttonCircle.Text = "Circle ●";
            this.radiobuttonCircle.UseVisualStyleBackColor = true;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(95, 435);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(155, 41);
            this.buttonSaveSettings.TabIndex = 2;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // buttonCancelSettings
            // 
            this.buttonCancelSettings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelSettings.Location = new System.Drawing.Point(340, 435);
            this.buttonCancelSettings.Name = "buttonCancelSettings";
            this.buttonCancelSettings.Size = new System.Drawing.Size(155, 41);
            this.buttonCancelSettings.TabIndex = 3;
            this.buttonCancelSettings.Text = "Cancel";
            this.buttonCancelSettings.UseVisualStyleBackColor = true;
            this.buttonCancelSettings.Click += new System.EventHandler(this.buttonCancelSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkboxBlue);
            this.groupBox1.Controls.Add(this.checkboxGreen);
            this.groupBox1.Controls.Add(this.checkboxRed);
            this.groupBox1.Location = new System.Drawing.Point(12, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shape";
            // 
            // checkboxBlue
            // 
            this.checkboxBlue.Location = new System.Drawing.Point(386, 34);
            this.checkboxBlue.Name = "checkboxBlue";
            this.checkboxBlue.Size = new System.Drawing.Size(110, 42);
            this.checkboxBlue.TabIndex = 5;
            this.checkboxBlue.Text = "Blue";
            this.checkboxBlue.UseVisualStyleBackColor = true;
            // 
            // checkboxGreen
            // 
            this.checkboxGreen.Location = new System.Drawing.Point(231, 34);
            this.checkboxGreen.Name = "checkboxGreen";
            this.checkboxGreen.Size = new System.Drawing.Size(110, 42);
            this.checkboxGreen.TabIndex = 4;
            this.checkboxGreen.Text = "Green";
            this.checkboxGreen.UseVisualStyleBackColor = true;
            // 
            // checkboxRed
            // 
            this.checkboxRed.Location = new System.Drawing.Point(96, 34);
            this.checkboxRed.Name = "checkboxRed";
            this.checkboxRed.Size = new System.Drawing.Size(110, 42);
            this.checkboxRed.TabIndex = 3;
            this.checkboxRed.Text = "Red";
            this.checkboxRed.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonSaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelSettings;
            this.ClientSize = new System.Drawing.Size(628, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancelSettings);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.groupboxShape);
            this.Controls.Add(this.groupboxDifficulty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.TopMost = true;
            this.groupboxDifficulty.ResumeLayout(false);
            this.groupboxCustomSize.ResumeLayout(false);
            this.groupboxCustomSize.PerformLayout();
            this.groupboxShape.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox checkboxRed;
        private System.Windows.Forms.CheckBox checkboxGreen;
        private System.Windows.Forms.CheckBox checkboxBlue;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.RadioButton radiobuttonTriangle;

        private System.Windows.Forms.RadioButton radiobuttonCircle;

        private System.Windows.Forms.RadioButton radiobuttonSquare;

        private System.Windows.Forms.Label labelWidth;

        private System.Windows.Forms.Label labelLength;

        private System.Windows.Forms.RadioButton radiobuttonEasy;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.RadioButton radiobuttonHard;
        private System.Windows.Forms.RadioButton radiobuttonCustom;
        private System.Windows.Forms.GroupBox groupboxCustomSize;
        private System.Windows.Forms.TextBox textboxLength;
        private System.Windows.Forms.TextBox textboxWidth;

        private System.Windows.Forms.GroupBox groupboxShape;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonCancelSettings;

        private System.Windows.Forms.GroupBox groupboxDifficulty;

        #endregion
    }
}