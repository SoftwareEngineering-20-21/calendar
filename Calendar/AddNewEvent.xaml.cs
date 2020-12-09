using Calendar.plan_your_life;
using Calendar.plan_your_life.Entities;
using Calendar.plan_your_life.Services.impl;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для AddNewEvent.xaml
    /// </summary>
    public partial class AddNewEvent : Window
    {
        User user;
        public AddNewEvent(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string description = Descroption.Text;
            string startAt = StartAt.Text;
            string endAt = EndAt.Text;
            if (name.Length == 0 || description.Length == 0 || startAt.Length == 0 || endAt.Length == 0)
            {
                Error.Content = "Enter all fields!";
            }
            else if (!Regex.IsMatch(startAt, @"\d{4}-\d{2}-\d{2}") || !Regex.IsMatch(endAt, @"\d{4}-\d{2}-\d{2}"))
            {
                Error.Content = "Enter data fields with format (year)-(month)-(day)";
            }
            else
            {
                try
                {
                    Event ev = new Event { Name = name, Description = description, StartAt = DateTime.ParseExact(startAt, "yyyy-mm-dd", CultureInfo.InvariantCulture), EntAt = DateTime.ParseExact(endAt, "yyyy-mm-dd", CultureInfo.InvariantCulture) };
                    Context con = new Context();
                    EventServiceImpl usev = new EventServiceImpl(con);
                    usev.Save(ev, this.user.Id);
                    EventPage eventPage = new EventPage(this.user);
                    eventPage.Show();
                    this.Close();
                }
                catch (PostgresException pexp)
                {
                    MessageBox.Show("Error has been occured\nMessage = " + pexp.Message);
                }
                catch (EntityException eexp)
                {
                    MessageBox.Show("Error has been occured\nMessage = " + eexp.Message);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error has been occured\nMessage = " + exp.Message);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EventPage eventPage = new EventPage(this.user);
            eventPage.Show();
            this.Close();
        }
    }
}
