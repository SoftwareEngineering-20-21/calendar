using System.Windows;

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
           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}