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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace бисер_шоп
{
    /// <summary>
    /// Логика взаимодействия для bag.xaml
    /// </summary>
    public partial class bag : Page
    {
        shopEntities shopEntities = new shopEntities();
        public bag()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Page_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            var temp = shopEntities.zakaz.ToList().Where(a => a.id_user == Loginer.id_user); ; 
            order.ItemsSource = temp;
            tb_count.Text = temp.Count().ToString();
            double sum = 0;
            foreach (var i in temp)
            {
                sum += i.tovar.cena * i.kolichestvo;
            }
            tb_allcount.Text = Math.Round(sum, 2).ToString() + " ₽";
        }
        private void del_Click(object sender, RoutedEventArgs e)
        {
            int delRow = Convert.ToInt32((sender as Button).Tag.ToString());
            shopEntities.zakaz.Remove(shopEntities.zakaz.Where(a => a.id_zakaz == delRow).First());
            shopEntities.SaveChanges();
            Page_Loaded();
            Loginer.UpdateCount(shopEntities);
        }

        private void oform_Click(object sender, RoutedEventArgs e)
        {
            var oplata = new oplata();
            oplata.ShowDialog();
            Loginer.UpdateBag(shopEntities);
            Page_Loaded();
        }
    }
}
