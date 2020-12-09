using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows;
using Npgsql;
using System.Windows.Controls;
using Calendar.plan_your_life;
using Calendar.plan_your_life.Services.impl;
using Calendar.plan_your_life.Entities;

namespace Calendar
{


    /// <summary>
    /// Interaction logic for calendar_page.xaml
    /// </summary>
    public partial class EventPage : Window
    {

        public EventPage(string email)
        {
            InitializeComponent();
            Context con = new Context();
            var userService = new UserServiceImpl(con);
            User_name.Content = userService.FindByEmail(email).UserName;
            
           

        }
     

       
    }
}
