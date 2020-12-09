using System.Text.RegularExpressions;
using System.Windows;
using Calendar.plan_your_life.Services.impl;
using Calendar.plan_your_life;

namespace Calendar
{
    public partial class Authorize : Window
    {
        public Authorize()
        {
            InitializeComponent();
        }

        private void Authorize_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                email.Focus();
            }
            else if (!Regex.IsMatch(email.Text,
                @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                email.Select(0, email.Text.Length);
                email.Focus();
            }
            else if (password.Text.Length == 0)
            {
                errormessage.Text = "Enter a password.";
                password.Focus();
            }
            else
            {
                Context con = new Context();
                var userService = new UserServiceImpl(con);
                var user = userService.FindByEmail(this.email.Text);
                if (user.Password == this.password.Text)
                {
                    EventPage eventPage = new EventPage(this.email.Text);
                    eventPage.Show();
                    this.Close();
                }
                else
                {
                    errormessage.Text = "Password dismatch!";
                    password.Focus();
                }

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}