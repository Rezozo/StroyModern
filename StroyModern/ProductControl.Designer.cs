namespace StroyModern
{
    partial class ProductControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.productImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.articleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            this.SuspendLayout();
            // 
            // productImage
            // 
            this.productImage.Location = new System.Drawing.Point(1, 1);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(125, 118);
            this.productImage.TabIndex = 0;
            this.productImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Артикул";
            // 
            // articleLbl
            // 
            this.articleLbl.AutoSize = true;
            this.articleLbl.Location = new System.Drawing.Point(132, 53);
            this.articleLbl.Name = "articleLbl";
            this.articleLbl.Size = new System.Drawing.Size(62, 16);
            this.articleLbl.TabIndex = 2;
            this.articleLbl.Text = "Артикул";
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.articleLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productImage);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(500, 120);
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox productImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label articleLbl;
    }
}
