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
            this.SuspendLayout();
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLbl.Location = new System.Drawing.Point(1023, 35);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(64, 22);
            this.loginLbl.TabIndex = 0;
            this.loginLbl.Text = "Логин";
            // 
            // filterBox
            // 
            this.filterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.filterBox.FormattingEnabled = true;
            this.filterBox.Location = new System.Drawing.Point(741, 16);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(274, 26);
            this.filterBox.TabIndex = 9;
            this.filterBox.Text = "Фильтрация";
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
            this.sortBox.Location = new System.Drawing.Point(484, 16);
            this.sortBox.Name = "sortBox";
            this.sortBox.Size = new System.Drawing.Size(251, 26);
            this.sortBox.TabIndex = 8;
            this.sortBox.Text = "Сортировка";
            // 
            // searchTxt
            // 
            this.searchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchTxt.Location = new System.Drawing.Point(12, 16);
            this.searchTxt.MaxLength = 200;
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(466, 30);
            this.searchTxt.TabIndex = 7;
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
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(12, 70);
            this.flowLayoutPanelProducts.MaximumSize = new System.Drawing.Size(1003, 640);
            this.flowLayoutPanelProducts.MinimumSize = new System.Drawing.Size(1003, 640);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(1003, 640);
            this.flowLayoutPanelProducts.TabIndex = 5;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 772);
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
    }
}