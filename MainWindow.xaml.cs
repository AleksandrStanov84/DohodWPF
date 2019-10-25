using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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

namespace DochodRaschod
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (UserContext db = new UserContext())
            {
                //Category category = new Category { Name = "Дом" }; db.Category.Add(category);
                //Category category1 = new Category { Name = "Работа" }; db.Category.Add(category1);
                //Category category2 = new Category { Name = "Учеба" }; db.Category.Add(category2);
                //Category category3 = new Category { Name = "Семья" }; db.Category.Add(category3);

                //Dochot dochot = new Dochot { Name = "Зарплата", Sum = 800, Data = new DateTime(2019, 10, 09), category = category }; db.Dochot.Add(dochot);
                //Dochot dochot1 = new Dochot { Name = "Продукты", Sum = 280, Data = new DateTime(2018, 06, 29), category = category3 }; db.Dochot.Add(dochot1);
                //Dochot dochot2 = new Dochot { Name = "Оплата за обучение", Sum = 3800, Data = new DateTime(2019, 08, 11), category = category2 }; db.Dochot.Add(dochot2);

                //Raschod raschod = new Raschod { Name = "Кофе", Sum = 15, Data = new DateTime(2018, 11, 03), category = category1 }; db.Raschod.Add(raschod);
                //Raschod raschod1 = new Raschod { Name = "Завтрак", Sum = 60, Data = new DateTime(2019, 02, 15), category = category3 }; db.Raschod.Add(raschod1);
                //Raschod raschod2 = new Raschod { Name = "Топливо", Sum = 200, Data = new DateTime(2018, 12, 07), category = category1 }; db.Raschod.Add(raschod2);
                // Для удаления колекции
                //foreach (var item in db.Category)
                //    db.Category.Remove(item);
                // db.SaveChanges();
            }
        }

        private void Button_Click_NewWin(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.ShowDialog();

            List<Category> categories = new List<Category>();
            using (UserContext db = new UserContext())
            {
                foreach (var item in db.Category)
                    categories.Add(item);
                TB.ItemsSource = categories;
            }
        }

        private void TB_Loaded(object sender, RoutedEventArgs e)
        {
            List<Category> categories = new List<Category>();
            using (UserContext db = new UserContext())
            {
                foreach (var item in db.Category)
                    categories.Add(item);
                TB.ItemsSource = categories;
            }
        }

        private void Button_Click_Raschod(object sender, RoutedEventArgs e)
        {
            List<Raschod> raschods = new List<Raschod>();
            using (UserContext db = new UserContext())
            {
                foreach (var item in db.Raschod.Include("category"))
                    raschods.Add(item);
                TB.ItemsSource = raschods;
            }
        }

        private void Button_Click_Dochod(object sender, RoutedEventArgs e)
        {
            List<Dochot> dochots = new List<Dochot>();
            using (UserContext db = new UserContext())
            {
                foreach (var item in db.Dochot.Include("category"))
                    dochots.Add(item);
                TB.ItemsSource = dochots;
            }
        }

        private void TB_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Win2Sum win2 = new Win2Sum();
            win2.ShowDialog();

            if (win2.count == 3)
            {
                LSum.Content = "Разница составила: " + win2.AllSum.ToString() + " грн";
                LabelRes.Content = win2.res;
            }
            else if (win2.count == 2)
            {
                LSum.Content = "Расход составил: " + win2.AllSumRaschod.ToString() + " грн";
                LabelRes.Content = win2.res;
            }
            else if (win2.count == 1)
            {
                LSum.Content = "Доход составил: " + win2.AllSumDochod.ToString() + " грн";
                LabelRes.Content = win2.res;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WinAddCateg winAddCat = new WinAddCateg();
            winAddCat.ShowDialog();
        }

        private void ButtonDelCateg_Click(object sender, RoutedEventArgs e)
        {
            WinDelCateg winDelCateg = new WinDelCateg();
            winDelCateg.ShowDialog();
        }
    }
}
