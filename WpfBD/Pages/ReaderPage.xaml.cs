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
using WpfBD.classes;

namespace WpfBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReaderPage.xaml
    /// </summary>
    public partial class ReaderPage : Page
    {
        public ReaderPage()
        {
            InitializeComponent();
            LvReader.ItemsSource = ConnectionClass.connect.User.ToList();
            Refresh();
        }
        public void Refresh()
        {
            LvReader.ItemsSource = null;
            LvReader.ItemsSource = ConnectionClass.connect.User.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var d = (sender as Button).DataContext as DBModel.User;
                if (d != null)
                {
                    ConnectionClass.connect.User.Remove(d);
                    ConnectionClass.connect.SaveChanges();
                    Refresh();
                    MessageBox.Show($"Читатель {d.FName} {d.Name} удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext as DBModel.User;
           NavigationService.Navigate(new EditPage(a));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BooksPage());
        }
    }
}
