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
    public partial class Win2Sum : Window
    {
        public double AllSumDochod = 0;
        public double AllSumRaschod = 0;
        public double AllSum = 0;
        public int count = 0;
        public string res;

        public Win2Sum()
        {
            InitializeComponent();
            using (UserContext db = new UserContext())
            {
                foreach (var item in db.Category)
                    ComboBoxSum.Items.Add(item);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count += 1;
            AllSumDochod = 0;
            using (UserContext db = new UserContext())
            {
                Category categ = null;
                foreach (var item in db.Category)
                {
                    if (item.Name == ComboBoxSum.SelectedItem.ToString())
                    {
                        categ = item;
                        break;
                    }
                }
                if (categ != null)
                {
                    foreach (var item in db.Dochot.Include("category"))
                    {
                        if (item.category.Name == categ.Name)
                            AllSumDochod += item.Sum;
                    }
                    foreach (var item in db.Raschod)
                    {
                        if (item.category.Name == categ.Name)
                            AllSumRaschod += item.Sum;
                    }

                    if (AllSumDochod > AllSumRaschod)
                        res = "[+]";
                    else if (AllSumDochod == AllSumRaschod)
                        res = "[=]";
                    else
                        res = "[-]";
                    MessageBox.Show("Сумма дохода посчитана!");
                }
                else { MessageBox.Show("ERROR! Не удалось подсчитать!"); }
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            count = 0;
            count += 2;
            AllSumRaschod = 0;

            using (UserContext db = new UserContext())
            {
                Category categ = null;
                foreach (var item in db.Category)
                {
                    if (item.Name == ComboBoxSum.SelectedItem.ToString())
                    {
                        categ = item;
                        break;
                    }
                }
                if (categ != null)
                {
                    foreach (var item in db.Raschod.Include("category"))
                    {
                        if (item.category.Name == categ.Name)
                            AllSumRaschod += item.Sum;
                    }
                    foreach (var item in db.Dochot)
                    {
                        if (item.category.Name == categ.Name)
                            AllSumDochod += item.Sum;
                    }

                    if (AllSumDochod > AllSumRaschod)
                        res = "[+]";
                    else if (AllSumDochod == AllSumRaschod)
                        res = "[=]";
                    else
                        res = "[-]";
                    MessageBox.Show("Сумма расхода посчитана!");
                }
                else { MessageBox.Show("ERROR! Не удалось подсчитать!"); }
            }
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            count = 0;
            count += 3;
            AllSumDochod = 0;
            AllSumRaschod = 0;
            AllSum = 0;
            using (UserContext db = new UserContext())
            {
                Category categ = null;
                foreach (var item in db.Category)
                {
                    if (item.Name == ComboBoxSum.SelectedItem.ToString())
                    {
                        categ = item;
                        break;
                    }
                }
                if (categ != null)
                {
                    foreach (var item in db.Dochot.Include("category"))
                    {
                        if (item.category.Name == categ.Name)
                            AllSumDochod += item.Sum;
                    }
                    foreach (var item in db.Raschod.Include("category"))
                    {
                        if (item.category.Name == categ.Name)
                            AllSumRaschod += item.Sum;
                    }
                    AllSum = AllSumDochod - AllSumRaschod;

                    if (AllSumDochod > AllSumRaschod)
                        res = "[+]";
                    else if (AllSumDochod == AllSumRaschod)
                        res = "[=]";
                    else
                        res = "[-]";
                    MessageBox.Show("Разница между доходом и расходом посчитана!");
                }
                else { MessageBox.Show("ERROR! Не удалось подсчитать!"); }
            }
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
