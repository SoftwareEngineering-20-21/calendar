using System.Text.RegularExpressions;
using System.Windows;
using Calendar.plan_your_life.Services.impl;
using Calendar.plan_your_life;
using System;
using System.IO;
using Npgsql;
using System.Data.Entity.Core;

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
            else if (password.Password.Length == 0)
            {
                errormessage.Text = "Enter a password.";
                password.Focus();
            }
            else
            {
                try
                {
                    Context con = new Context();
                    var userService = new UserServiceImpl(con);
                    var user = userService.FindByEmail(this.email.Text);
                    if (user.Password == this.password.Password)
                    {
                        EventPage eventPage = new EventPage(user);
                        eventPage.Show();
                        this.Close();
                    }
                    else
                    {
                        errormessage.Text = "Password dismatch!";
                        password.Focus();
                    }
                }
                catch(PostgresException pexp)
                {
                    MessageBox.Show("Error has been occured\nMessage = " + pexp.Message);
                }
                catch(EntityException eexp)
                {
                    MessageBox.Show("Error has been occured\nMessage = " + eexp.Message);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error has been occured\nMessage = " + exp.Message);
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