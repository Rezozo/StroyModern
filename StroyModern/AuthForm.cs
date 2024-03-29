﻿using StroyModern.provider;
using System;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class AuthForm : Form
    {
        private int loginAttempts = 0;
        public int CountOfAttepts { get; set; } = 0;

        private UserProvider userProvider;

        public AuthForm()
        {
            InitializeComponent();
            userProvider = new UserProvider();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string login = loginTxt.Text;
            string password = passwordTxt.Text;
            if (string.IsNullOrEmpty(login)  && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Укажите пароль и логин");
                return;
            }
            string role = userProvider.isValidUser(login, password);
            if (role.Equals(""))
            {
                if (CountOfAttepts == 1)
                {
                    Close();
                }

                loginAttempts++;
                if (loginAttempts < 3)
                {
                    MessageBox.Show("Данные введены неверно!");
                    return;
                }
                else
                {
                    CountOfAttepts++;

                    System.Threading.Thread.Sleep(30000);
                    Hide();
                    CaptchaForm captchaForm = new CaptchaForm();
                    captchaForm.CountOfAttepts = CountOfAttepts;
                    captchaForm.FormClosed += (s, args) => Close();
                    captchaForm.Show();
                }
            }

            Hide();
            ProductForm productForm = new ProductForm();
            productForm.LoginLabel = login;
            productForm.UserRole = role;
            productForm.FormClosed += (s, args) => Close();
            productForm.Show();
        }
    }
}
