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
        User user;
        List<Event> events;
        public EventPage(User user)
        {
            this.user = user;
            try
            {
                Context con = new Context();
                EventService eventService = new EventServiceImpl(con);
                InitializeComponent();
                User_name.Content = user.UserName;
                events = eventService.FindAllByUserId(user.Id).ToList();
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
            this.Close();

        }

        private void Add_new_event_Click(object sender, RoutedEventArgs e)
        {
            AddNewEvent addNewEvent = new AddNewEvent(this.user);
            addNewEvent.Show();
            this.Close();
        }
        
        private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Ensure row was clicked and not empty space
            // var row = ItemsControl.ContainerFromElement((DataGrid)sender,
            //                                     e.OriginalSource as DependencyObject) as DataGridRow;
            // var dataGrid = sender as DataGrid;
            // if (dataGrid != null)
            // {
            //  var index = dataGrid.SelectedIndex;
           
            if (grid.SelectedItem == null) return;
            var selectedEvent = grid.SelectedItem as Event;
            Edit_Delete edit_delete = new Edit_Delete(selectedEvent,this.user);
                edit_delete.Show();
                this.Close();
           // }
            //if (row == null) return;
            // else 
            // {
            //     Edit_Delete edit_delete = new Edit_Delete(this.user);
            //    edit_delete.Show();
            //   this.Close();
            //  }

        }
    }
}
