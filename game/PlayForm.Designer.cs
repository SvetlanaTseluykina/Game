namespace game
{
    partial class PlayForm
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
            this.btnEasy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMiddle = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.Location = new System.Drawing.Point(280, 148);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(132, 54);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "EASY";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.BtnEasy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHOOSE THE LEVEL";
            // 
            // btnMiddle
            // 
            this.btnMiddle.Location = new System.Drawing.Point(281, 230);
            this.btnMiddle.Name = "btnMiddle";
            this.btnMiddle.Size = new System.Drawing.Size(132, 55);
            this.btnMiddle.TabIndex = 2;
            this.btnMiddle.Text = "MIDDLE";
            this.btnMiddle.UseVisualStyleBackColor = true;
            this.btnMiddle.Click += new System.EventHandler(this.BtnMiddle_Click);
            // 
            // btnHard
            // 
            this.btnHard.Location = new System.Drawing.Point(281, 320);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(132, 56);
            this.btnHard.TabIndex = 3;
            this.btnHard.Text = "HARD";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.BtnHard_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(577, 12);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(131, 49);
            this.BtnBack.TabIndex = 4;
            this.BtnBack.Text = "BACK TO START";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::game.Properties.Resources.cosmos;
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.ControlBox = false;
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMiddle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEasy);
            this.DoubleBuffered = true;
            this.Name = "PlayForm";
            this.Text = "LEVEL";
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMiddle;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button BtnBack;
    }
}