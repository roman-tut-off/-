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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace бисер_шоп
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Window window;
        shopEntities shopEntities = new shopEntities();
        public MainWindow()
        {
            InitializeComponent();
            Loginer.UpdateLogin();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var loginer = shopEntities.users.ToList().Where(a => a.nickname == tb_log.Text & a.parol == pw_pas.Password);
            if (loginer.Count() == 1)
            {
                Loginer.id_user = loginer.First().id_user;
                Loginer.login = loginer.First().nickname;
                Loginer.nickimya = loginer.First().nickname;
                Loginer.par = loginer.First().parol;
                Loginer.tel = loginer.First().telefon;
                Loginer.poch = loginer.First().pochta;
                Loginer.UpdateCount(shopEntities);
                var okno = new okno();
                this.Close();
                okno.Show();
                
            }
            else
            {
                MessageBox.Show($"Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
