using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для okno.xaml
    /// </summary>
    public partial class okno : Window
    {
        shopEntities shopEntities = new shopEntities();
        public static bool _clicked = false;
        public okno()
        {
            InitializeComponent();
            Loginer.UpdateLogin();
            ShowDataAll(0);
        }

        void ShowDataAll(int argument) // Отображает товары из таблицы бд
        {
            using (shopEntities cont = new shopEntities())
            {
                var data = cont.tovar;
                prod.ItemsSource = data.ToList();
            }
        }

        void ShowData(int _id) // Отображает товары из таблицы бд
        {
            using (shopEntities cont = new shopEntities())
            {
                var data = cont.tovar.Where(p => p.id_kat == _id);
                prod.ItemsSource = data.ToList();
            }
        }


        private void log_Click(object sender, RoutedEventArgs e)
        {
            var user = new user();
            user.ShowDialog();
        }

        private void o_Click(object sender, RoutedEventArgs e)
        {
            fon.Visibility = Visibility.Hidden;
            _clicked = true;
            ShowData(2);
            fr_Content.Navigate(null);
            sc_prod.Visibility = Visibility.Visible;
            prod.Visibility = Visibility.Visible;
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            fon.Visibility = Visibility.Hidden;
            _clicked = true;
            ShowData(3);
            fr_Content.Navigate(null);
            sc_prod.Visibility = Visibility.Visible;
            prod.Visibility = Visibility.Visible;
        }

        private void k_Click(object sender, RoutedEventArgs e)
        {
            fon.Visibility = Visibility.Hidden;
            _clicked = true;
            ShowData(1);
            fr_Content.Navigate(null);
            sc_prod.Visibility = Visibility.Visible;
            prod.Visibility = Visibility.Visible;
        }

        private void v_Click(object sender, RoutedEventArgs e)
        {
            fon.Visibility = Visibility.Hidden;
            _clicked = true;
            ShowDataAll(0);
            fr_Content.Navigate(null);
            sc_prod.Visibility = Visibility.Visible;
            prod.Visibility = Visibility.Visible;
        }

        private void tb_poisk_key(object sender, KeyEventArgs e)
        {

            shopEntities cont = new shopEntities();
            prod.ItemsSource = cont.tovar.Where(k => k.title.ToString().Contains(tb_poisk.Text)).ToList();
            if (tb_poisk.Text == "")
            {
                prod.ItemsSource = cont.tovar.ToList();
            }
        }

        private void tb_poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_poisk.Text.Length == 0)
            {
                search.Visibility = Visibility.Visible;
            }
            else
            {
                search.Visibility = Visibility.Hidden;
            }
        }

        private void bag_Click(object sender, RoutedEventArgs e)
        {
            fon.Visibility = Visibility.Hidden;
            sc_prod.Visibility = Visibility.Hidden;
            prod.Visibility = Visibility.Hidden;
            fr_Content.Navigate(new bag());
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            if (Loginer.id_user != 0)
            {
                int AddTovar = Convert.ToInt32((sender as Button).Tag.ToString());
                shopEntities.zakaz.Add(new zakaz { kolichestvo = 1, id_tovar = AddTovar, id_user = Loginer.id_user });
                shopEntities.SaveChanges();
                Loginer.UpdateCount(shopEntities);
            }
        }

    }
}
