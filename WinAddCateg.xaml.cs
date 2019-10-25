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
    public partial class WinAddCateg : Window
    {
        public WinAddCateg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                if (TextBoxAddCateg.Text != null || TextBoxAddCateg.Text.Length < 20)
                {
                    Category category = new Category { Name = TextBoxAddCateg.Text };
                    db.Category.Add(category);
                    db.SaveChanges();
                    MessageBox.Show("Категория " + TextBoxAddCateg.Text + " добавлена успешно!");
                }
                else
                    MessageBox.Show("ERRORE!!! Не удалось добавить категорию " + TextBoxAddCateg.Text + "!");
            }
            TextBoxAddCateg.Clear();
        }
    }
}
