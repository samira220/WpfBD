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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        DBModel.User user;
        public EditPage(DBModel.User user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = user;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var a = ConnectionClass.connect.User.Where(z => z.ID_User == user.ID_User).FirstOrDefault();
            if (string.IsNullOrEmpty(TxtSurname.Text) || string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("Заполните все поля!!!");
            }
            else
            {
                a.FName = TxtSurname.Text;
                a.Name = TxtName.Text;
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Изменения сохранены", "Изменения данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
