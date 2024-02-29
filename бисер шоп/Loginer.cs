using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace бисер_шоп
{
    public class Loginer
    {
        public static int id_user { get; set; } = 0;
        public static string login { get; set; } = " ";
        public static int Count { get; set; } = 0;
        public static string nickimya { get; set; } = " ";
        public static string par { get; set; } = " ";
        public static string tel { get; set; } = " ";
        public static string poch { get; set; } = " ";

        public static void UpdateLogin()
        {

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(okno))
                {
                    (window as okno).tb_login.Text = login;
                }
            }
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(user))
                {
                    (window as user).nick.Text = nickimya;
                    (window as user).pw.Text = par;
                    (window as user).tf.Text = tel;
                    (window as user).pt.Text = poch;
                }
            }
        }

        public static void UpdateCount(shopEntities shopEntities)
        {
            var temp = shopEntities.zakaz.ToList().Where(c => c.id_user == id_user).Count();
            Count = temp;
            UpdateLogin();
        }

        public static void UpdateBag(shopEntities shopEntities)
        {
            var temp = shopEntities.zakaz.Where(a => a.id_user == Loginer.id_user);
            if (temp != null)
            {
                shopEntities.zakaz.RemoveRange(temp);
                shopEntities.SaveChanges();
            }
        }
    }

}
