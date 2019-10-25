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

namespace DochodRaschod
{
    public partial class WinDelCateg : Window
    {
        public WinDelCateg()
        {
            InitializeComponent();
            using (UserContext db = new UserContext())
            {
                foreach (var item in db.Category)
                    ComboBoxDel.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                Category categ = null;
                foreach (var item in db.Category)
                {
                    if (item.Name == ComboBoxDel.SelectedItem.ToString())
                    {
                        categ = item;
                        break;
                    }
                }
                if (categ != null)
                {
                    foreach (var item in db.Category)
                    {
                        if (item.Name == categ.Name)
                            db.Category.Remove(item);
                    }
                }
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
