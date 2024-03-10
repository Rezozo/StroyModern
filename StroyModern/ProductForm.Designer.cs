namespace StroyModern
{
    partial class ProductForm
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
            this.loginLbl = new System.Windows.Forms.Label();
            this.filterBox = new System.Windows.Forms.ComboBox();
            this.sortBox = new System.Windows.Forms.ComboBox();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelPagination = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLbl.Location = new System.Drawing.Point(852, 34);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(64, 22);
            this.loginLbl.TabIndex = 0;
            this.loginLbl.Text = "Логин";
            // 
            // filterBox
            // 
            this.filterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.filterBox.FormattingEnabled = true;
            this.filterBox.Location = new System.Drawing.Point(563, 34);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(274, 26);
            this.filterBox.TabIndex = 9;
            this.filterBox.Text = "Фильтрация";
            this.filterBox.SelectedIndexChanged += new System.EventHandler(this.filterBox_SelectedIndexChanged);
            // 
            // sortBox
            // 
            this.sortBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.sortBox.FormattingEnabled = true;
            this.sortBox.ItemHeight = 18;
            this.sortBox.Items.AddRange(new object[] {
            "По умолчанию",
            "По наименованию (по возрастанию)",
            "По наименованию (по убыванию)",
            "По номеру производственного цеха (по возрастанию)",
            "По номеру производственного цеха (по убыванию)",
            "По стоимости (по возрастанию)",
            "По стоимости (по убыванию)"});
            this.sortBox.Location = new System.Drawing.Point(306, 34);
            this.sortBox.Name = "sortBox";
            this.sortBox.Size = new System.Drawing.Size(251, 26);
            this.sortBox.TabIndex = 8;
            this.sortBox.Text = "Сортировка";
            this.sortBox.SelectedIndexChanged += new System.EventHandler(this.sortBox_SelectedIndexChanged);
            // 
            // searchTxt
            // 
            this.searchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchTxt.Location = new System.Drawing.Point(12, 34);
            this.searchTxt.MaxLength = 200;
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(288, 30);
            this.searchTxt.TabIndex = 7;
            this.searchTxt.Enter += new System.EventHandler(this.searchTxt_Enter);
            this.searchTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTxt_KeyPress);
            this.searchTxt.Leave += new System.EventHandler(this.searchTxt_Leave);
            // 
            // flowLayoutPanelPagination
            // 
            this.flowLayoutPanelPagination.Location = new System.Drawing.Point(672, 716);
            this.flowLayoutPanelPagination.Name = "flowLayoutPanelPagination";
            this.flowLayoutPanelPagination.Size = new System.Drawing.Size(343, 41);
            this.flowLayoutPanelPagination.TabIndex = 6;
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(16, 130);
            this.flowLayoutPanelProducts.MaximumSize = new System.Drawing.Size(1003, 580);
            this.flowLayoutPanelProducts.MinimumSize = new System.Drawing.Size(1003, 580);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(1003, 580);
            this.flowLayoutPanelProducts.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Для совершения действий, нажмите правой кнопкой мыши по выбранному продукту";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(598, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Чтобы распечатать штрихкод - необходимо нажать левой кнопкой мыши на артикул";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StroyModern.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(16, 716);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1027, 772);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.sortBox);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.flowLayoutPanelPagination);
            this.Controls.Add(this.flowLayoutPanelProducts);
            this.Controls.Add(this.loginLbl);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Location = new System.Drawing.Point(1045, 819);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1045, 819);
            this.MinimumSize = new System.Drawing.Size(1045, 819);
            this.Name = "ProductForm";
            this.Text = "Все продукты";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.ComboBox filterBox;
        private System.Windows.Forms.ComboBox sortBox;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPagination;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}