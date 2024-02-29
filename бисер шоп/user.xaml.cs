using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace бисер_шоп
{
    /// <summary>
    /// Логика взаимодействия для user.xaml
    /// </summary>
    public partial class user : Window
    {
        shopEntities shopEntities = new shopEntities();
        public user()
        {
            InitializeComponent();
            Loginer.UpdateLogin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pw_v(object sender, RoutedEventArgs e)
        {
            pw.Visibility = Visibility.Visible;
        }

        private void pw_h(object sender, RoutedEventArgs e)
        {
            pw.Visibility = Visibility.Hidden;
        }
    }
}
