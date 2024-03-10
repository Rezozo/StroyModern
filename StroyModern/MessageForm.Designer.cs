namespace StroyModern
{
    partial class MessageForm
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
            this.falseBtn = new System.Windows.Forms.Button();
            this.trueBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.barPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.barPic)).BeginInit();
            this.SuspendLayout();
            // 
            // falseBtn
            // 
            this.falseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.falseBtn.Location = new System.Drawing.Point(346, 222);
            this.falseBtn.Name = "falseBtn";
            this.falseBtn.Size = new System.Drawing.Size(147, 40);
            this.falseBtn.TabIndex = 7;
            this.falseBtn.Text = "Нет";
            this.falseBtn.UseVisualStyleBackColor = true;
            this.falseBtn.Click += new System.EventHandler(this.falseBtn_Click);
            // 
            // trueBtn
            // 
            this.trueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.trueBtn.Location = new System.Drawing.Point(12, 222);
            this.trueBtn.Name = "trueBtn";
            this.trueBtn.Size = new System.Drawing.Size(147, 40);
            this.trueBtn.TabIndex = 6;
            this.trueBtn.Text = "Да";
            this.trueBtn.UseVisualStyleBackColor = true;
            this.trueBtn.Click += new System.EventHandler(this.trueBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(92, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выгрузить данный штрихкод в PDF?";
            // 
            // barPic
            // 
            this.barPic.Location = new System.Drawing.Point(87, 43);
            this.barPic.Name = "barPic";
            this.barPic.Size = new System.Drawing.Size(330, 169);
            this.barPic.TabIndex = 4;
            this.barPic.TabStop = false;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(505, 272);
            this.Controls.Add(this.falseBtn);
            this.Controls.Add(this.trueBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barPic);
            this.MaximumSize = new System.Drawing.Size(523, 319);
            this.MinimumSize = new System.Drawing.Size(523, 319);
            this.Name = "MessageForm";
            this.Text = "Проверка";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button falseBtn;
        private System.Windows.Forms.Button trueBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox barPic;
    }
}