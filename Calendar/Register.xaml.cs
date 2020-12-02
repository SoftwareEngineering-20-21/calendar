using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using Calendar.plan_your_life;
using Calendar.plan_your_life.Entities;
using Calendar.plan_your_life.Services;
using Calendar.plan_your_life.Services.impl;

namespace Calendar
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
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
            else
            {
                string userName = this.userName.Text;
                string email = this.email.Text;
                string password = this.password.Text;
                if (password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    this.password.Focus();
                }
                else if (this.confirmPassword.Text.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    this.confirmPassword.Focus();
                }
                else if (password != confirmPassword.Text)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    confirmPassword.Focus();
                }
                else
                {
                    User user = new User { Email = email, Password = password, UserName = userName };

                    var ctx = new Context();

                    UserService service = new UserServiceImpl(ctx);

                    service.Save(user);


                    errormessage.Text = "You have Registered successfully.";
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