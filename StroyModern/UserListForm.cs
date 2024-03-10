using StroyModern.model;
using StroyModern.provider;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class UserListForm : Form
    {
        private UserProvider userProvider = new UserProvider();
        public UserListForm()
        {
            InitializeComponent();
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            UpdateUsersList();
        }

        private void UpdateUsersList()
        {
            usersView.Rows.Clear();
            List<User> users = userProvider.GetAllUsers();

            foreach (User user in users)
            {
                usersView.Rows.Add(user.Id, user.Login, user.Password, user.Role);
            }
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            UpdateUserForm updateUserForm = new UpdateUserForm();
            updateUserForm.ShowDialog();
        }

        private void usersView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int userId = (int)usersView.Rows[e.RowIndex].Cells[0].Value;
                ActionForm action = new ActionForm();
                DialogResult dialogResult = action.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    UpdateUserForm updateUserForm = new UpdateUserForm();
                    updateUserForm.UserId = userId;
                    DialogResult dialog = updateUserForm.ShowDialog();
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    userProvider.DeleteUser(userId);
                }
                else
                {
                    return;
                }

                UpdateUsersList();
            }
            catch
            {
                MessageBox.Show("Выберите не пустую строку");
            }
        }
    }
}
