using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PZ6.Models;
using PZ6.Services;

namespace PZ6.Pages
{
    public partial class Autho : Page
    {
        private int click = 0;

        public Autho()
        {
            InitializeComponent();
        }

        private void GenerateCaptcha()
        {
            tblCaptcha.Visibility = Visibility.Visible;
            tbCaptcha.Visibility = Visibility.Visible;
            tbiCaptcha.Visibility = Visibility.Visible;

            string captchaText = CaptchaGenerator.GenerateCaptchaText(6);
            tbiCaptcha.Text = captchaText;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            click += 1;

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password.Trim();
            string hashedPassword = Hash.HashPassword(password);

            LeasingCompanyEntities db = Helper.GetContext();
            var client = db.Clients.FirstOrDefault(x => x.Login == login && x.PasswordHash == hashedPassword);

            if (client != null)
            {
                MessageBox.Show($"Вы вошли как: {client.FirstName} {client.LastName}");
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль! Введите капчу.");
                GenerateCaptcha();
                txtPassword.Clear();
            }
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вход как гость");
        }
    }
}