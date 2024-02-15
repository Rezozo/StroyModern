namespace StroyModern
{
    partial class CaptchaForm
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
            this.captchaBox = new System.Windows.Forms.PictureBox();
            this.CaptchaTxtB = new System.Windows.Forms.TextBox();
            this.captchaBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.captchaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // captchaBox
            // 
            this.captchaBox.Location = new System.Drawing.Point(96, 49);
            this.captchaBox.Name = "captchaBox";
            this.captchaBox.Size = new System.Drawing.Size(208, 50);
            this.captchaBox.TabIndex = 16;
            this.captchaBox.TabStop = false;
            // 
            // CaptchaTxtB
            // 
            this.CaptchaTxtB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptchaTxtB.Location = new System.Drawing.Point(96, 118);
            this.CaptchaTxtB.MaxLength = 10;
            this.CaptchaTxtB.Multiline = true;
            this.CaptchaTxtB.Name = "CaptchaTxtB";
            this.CaptchaTxtB.Size = new System.Drawing.Size(208, 39);
            this.CaptchaTxtB.TabIndex = 15;
            // 
            // captchaBtn
            // 
            this.captchaBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captchaBtn.Location = new System.Drawing.Point(137, 176);
            this.captchaBtn.Name = "captchaBtn";
            this.captchaBtn.Size = new System.Drawing.Size(130, 46);
            this.captchaBtn.TabIndex = 17;
            this.captchaBtn.Text = "Проверить";
            this.captchaBtn.UseVisualStyleBackColor = true;
            this.captchaBtn.Click += new System.EventHandler(this.captchaBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StroyModern.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // CaptchaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 284);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.captchaBtn);
            this.Controls.Add(this.captchaBox);
            this.Controls.Add(this.CaptchaTxtB);
            this.MinimumSize = new System.Drawing.Size(419, 331);
            this.Name = "CaptchaForm";
            this.Text = "CaptchaForm";
            this.Load += new System.EventHandler(this.CaptchaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.captchaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox captchaBox;
        private System.Windows.Forms.TextBox CaptchaTxtB;
        private System.Windows.Forms.Button captchaBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}