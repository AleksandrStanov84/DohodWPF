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
    public partial class Window1 : Window
    {
        private double SumDochod;
        private double SumRaschod;

        public Window1()
        {
            InitializeComponent();
            using (UserContext db = new UserContext())
            {
                foreach (var item in db.Category)
                    ComboBoxCategory.Items.Add(item);
            }
        }

        private void TextBoxSummDochod_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if ((sender as TextBox).Text.Length > 0)
                    SumDochod = Convert.ToDouble(TextBoxSummDochod.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Вы ввели символ! Пожалуйста,введите цифрy");
            }
        }

        private void TextBoxSummRaschod_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if ((sender as TextBox).Text.Length > 0)
                    SumRaschod = Convert.ToDouble(TextBoxSummRaschod.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Вы ввели символ! Пожалуйста,введите цифрy");
            }
        }

        private void Button_Click_AddDochRasch(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void TextBoxDochod_TextChanged(object sender, TextChangedEventArgs e) { }

        private void TextBoxRaschod_TextChanged(object sender, TextChangedEventArgs e) { }

        private void AddDochot_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                Category categ = null;
                foreach (var item in db.Category)
                {
                    if (item.Name == ComboBoxCategory.SelectedItem.ToString())
                    {
                        categ = item;
                        break;
                    }
                }
                if (TextBoxDochod.Text != null && TextBoxSummDochod.Text != null && DataDochod != null && categ != null)
                {
                    Dochot dochot = new Dochot {
                        Name = TextBoxDochod.Text,
                        Sum = SumDochod,
                        Data = DataDochod.SelectedDate.Value,
                        category = categ
                    };
                    db.Dochot.Add(dochot);
                    MessageBox.Show("Данные дохода добавлены!");
                }
                else
                    MessageBox.Show("Данные введены не корректно!");
                db.SaveChanges();
                TextBoxDochod.Clear();
                TextBoxSummDochod.Clear();
            }
        }

        private void AddRaschod_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                Category categ = null;
                foreach (var item in db.Category)
                {
                    if (item.Name == ComboBoxCategory.SelectedItem.ToString())
                    {
                        categ = item;
                        break;
                    }
                }
                if (TextBoxRaschod.Text != null && TextBoxSummRaschod.Text != null && DataRaschod != null && categ != null)
                {
                    Raschod raschod = new Raschod
                    {
                        Name = TextBoxRaschod.Text,
                        Sum = SumRaschod,
                        Data = DataRaschod.SelectedDate.Value,
                        category = categ
                    };
                    db.Raschod.Add(raschod);
                    MessageBox.Show("Данные расход добавлены!");
                }
                else
                    MessageBox.Show("Данные введены не корректно!");

                db.SaveChanges();
                TextBoxRaschod.Clear();
                TextBoxSummRaschod.Clear();
            }
        }
    }
}
