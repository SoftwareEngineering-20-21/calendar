using Calendar.plan_your_life;
using Calendar.plan_your_life.Entities;
using Calendar.plan_your_life.Services;
using Calendar.plan_your_life.Services.impl;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
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
    /// Interaction logic for Edit_Delete.xaml
    /// </summary>
    public partial class Edit_Delete : Window
    {
        Event events;
        User user;
        public Edit_Delete(Event events, User user)
        {
            InitializeComponent();
            this.events = events;
            this.user = user;
            Name.Text = this.events.Name;
            Descroption.Text = this.events.Description;
            StartAt.Text = this.events.StartAt.ToString();
            EndAt.Text = this.events.EntAt.ToString();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            this.events.Name = Name.Text;
            this.events.Description = Descroption.Text;
            this.events.StartAt = DateTime.ParseExact(StartAt.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            this.events.EntAt = DateTime.ParseExact(EndAt.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);

            Context context = new Context();
            EventService eventService = new EventServiceImpl(context);
            eventService.Update(events);

            EventPage eventPage = new EventPage(this.user);
            eventPage.Show();
            this.Close();


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Context context = new Context();
            EventService eventService = new EventServiceImpl(context);
            eventService.DeleteById(user.Id, events.Id);

            EventPage eventPage = new EventPage(this.user);
            eventPage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EventPage eventPage = new EventPage(this.user);
            eventPage.Show();
            this.Close();
        }
    }
}
