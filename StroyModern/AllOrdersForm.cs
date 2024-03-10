using StroyModern.model;
using StroyModern.provider;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class AllOrdersForm : Form
    {
        private OrderProvider orderProvider = new OrderProvider();
        public AllOrdersForm()
        {
            InitializeComponent();
        }

        private void AllOrdersForm_Load(object sender, EventArgs e)
        {
            UpdateOrders();
        }

        private void UpdateOrders()
        {
            orderView.Rows.Clear();
            List<Orders> orders = orderProvider.GetAllOrders();
            foreach (Orders o in orders)
            {
                orderView.Rows.Add(o.Id, o.FullName, o.Address, 100000 + " руб.");
            }
        }

        private void orderView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int orderId = (int)orderView.Rows[e.RowIndex].Cells[0].Value;
                ActionForm action = new ActionForm();
                DialogResult dialogResult = action.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    CreateOrderForm create = new CreateOrderForm(this);
                    create.OrderId = orderId;
                    DialogResult result = create.ShowDialog();
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    orderProvider.DeleteOrder(orderId);
                }
                else
                {
                    return;
                }

                UpdateOrders();
            } catch
            {
                MessageBox.Show("Выберите не пустую строку");
            }
        }
    }
}
