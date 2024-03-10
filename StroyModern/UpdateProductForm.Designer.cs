namespace StroyModern
{
    partial class UpdateProductForm
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
            this.productImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.priceTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.articleTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.productShopTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // productImage
            // 
            this.productImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productImage.Image = global::StroyModern.Properties.Resources.picture;
            this.productImage.Location = new System.Drawing.Point(34, 140);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(188, 188);
            this.productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productImage.TabIndex = 0;
            this.productImage.TabStop = false;
            this.productImage.Click += new System.EventHandler(this.productImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(261, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Продукт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Изображение:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Название";
            // 
            // titleTxt
            // 
            this.titleTxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleTxt.Location = new System.Drawing.Point(268, 89);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(325, 30);
            this.titleTxt.TabIndex = 4;
            // 
            // priceTxt
            // 
            this.priceTxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceTxt.Location = new System.Drawing.Point(268, 152);
            this.priceTxt.Name = "priceTxt";
            this.priceTxt.Size = new System.Drawing.Size(325, 30);
            this.priceTxt.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Цена";
            // 
            // articleTxt
            // 
            this.articleTxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.articleTxt.Location = new System.Drawing.Point(268, 211);
            this.articleTxt.Name = "articleTxt";
            this.articleTxt.Size = new System.Drawing.Size(325, 30);
            this.articleTxt.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Артикул (13 цифр)";
            // 
            // quantityTxt
            // 
            this.quantityTxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityTxt.Location = new System.Drawing.Point(268, 273);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(325, 30);
            this.quantityTxt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Количество на складе";
            // 
            // productShopTxt
            // 
            this.productShopTxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productShopTxt.Location = new System.Drawing.Point(268, 335);
            this.productShopTxt.Name = "productShopTxt";
            this.productShopTxt.Size = new System.Drawing.Size(325, 30);
            this.productShopTxt.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Номер производственного цеха";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Тип товара";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(201, 466);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(268, 41);
            this.createBtn.TabIndex = 15;
            this.createBtn.Text = "Редактировать продукт";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // typeBox
            // 
            this.typeBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(267, 399);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(326, 30);
            this.typeBox.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StroyModern.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // UpdateProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(672, 530);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productShopTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.quantityTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.articleTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.priceTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.titleTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productImage);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(690, 577);
            this.MinimumSize = new System.Drawing.Size(690, 577);
            this.Name = "UpdateProductForm";
            this.Text = "Редактирование продуктов";
            this.Load += new System.EventHandler(this.UpdateProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox productImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.TextBox priceTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox articleTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox quantityTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox productShopTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}