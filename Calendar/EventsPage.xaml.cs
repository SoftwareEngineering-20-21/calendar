using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows;
using Npgsql;
using System.Windows.Controls;
using Calendar.plan_your_life;
using Calendar.plan_your_life.Services.impl;
using Calendar.plan_your_life.Entities;
using System.Data.Entity.Core;
using Calendar.plan_your_life.Services;
using System.Windows.Documents;
using System.Collections.Generic;

namespace Calendar
{


    /// <summary>
    /// Interaction logic for calendar_page.xaml
    /// </summary>
    public partial class EventPage : Window
    {

        public EventPage(User user)
        {
            try
            {
                Context con = new Context();
                EventService eventService = new EventServiceImpl(con);
                InitializeComponent();
                User_name.Content = user.UserName;
                IEnumerable<Event> events = eventService.FindAllByUserId(user.Id);
                grid.ItemsSource = events;



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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
