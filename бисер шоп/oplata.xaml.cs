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
    /// Логика взаимодействия для oplata.xaml
    /// </summary>
    public partial class oplata : Window
    {
        shopEntities shopEntities = new shopEntities();
        public oplata()
        {
            InitializeComponent();
        }


        private void oplat_Click(object sender, RoutedEventArgs e)
        {
            if ((number.Text.Length == 16) & (srok.Text.Length == 5) & (cvc.Text.Length==3))
            {
                this.Close();
                MessageBox.Show($"Мы начали собирать ваш заказ!\n Спасибо за покупку", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Loginer.UpdateBag(shopEntities);
            }
            else
            {
                MessageBox.Show($"Данные карты введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
