using StroyModern.model;
using StroyModern.provider;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class UpdateUserForm : Form
    {
        private UserProvider userProvider = new UserProvider();
        public int UserId { get; set; } = 0;
        public UpdateUserForm()
        {
            InitializeComponent();
        }

        private void UpdateUserForm_Load(object sender, EventArgs e)
        {
            if (UserId != 0)
            {
                User user = userProvider.GetById(UserId);
                loginTxt.Text = user.Login;
                passwordTxt.Text = user.Password;
                roleBox.Text = user.Role;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginTxt.Text) || string.IsNullOrEmpty(passwordTxt.Text) || string.IsNullOrEmpty(roleBox.Text))
            {
                MessageBox.Show("Заполните все данные");
            }

            if (UserId == 0)
            {
                userProvider.CreateUser(loginTxt.Text, passwordTxt.Text, roleBox.Text);
            } else
            {
                userProvider.UpdateUser(UserId, loginTxt.Text, passwordTxt.Text, roleBox.Text);
            }

            Hide();
        }
    }
}
