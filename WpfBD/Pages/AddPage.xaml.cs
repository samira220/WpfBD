using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using WpfBD.DBModel;

namespace WpfBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        
        public AddPage()
        {
            InitializeComponent();
            TxtLogin.Text = Convert.ToString(new Random().Next(200000, 220000));
            lv.Login = TxtLogin.Text;
            TxtPassword.Text = Convert.ToString(new Random().Next(500000, 520000));
            lv.Password = TxtPassword.Text;



        }

        User st = new User();
        Log_Us lv = new Log_Us();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSurname.Text) || string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!!");
            }
            else
            {
                st.Name = TxtName.Text;
                st.FName = TxtSurname.Text;
                st.ID_Pass_Log = lv.ID_Pass_Log;
                ConnectionClass.connect.Log_Us.Add(lv);
                ConnectionClass.connect.User.Add(st);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show($"Читатель {TxtSurname.Text} {TxtName.Text} добавлен", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ReaderPage());
            }

        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                st.Photo = File.ReadAllBytes(openFileDialog.FileName);
                MemoryStream byteStream = new MemoryStream(st.Photo);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                IPicture.Source = image;
            }
        }

        private string GenerationLoginPassword(int lenght)
        {
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                TxtLogin.Text = rnd.Next(100, 1000).ToString();
            }
            return TxtLogin.Text;
        }
        private string GenerationLPassword(int lenght)
        {
            Random r = new Random();
            for (int i = 0; i < 3; i++)
            {
                TxtPassword.Text = r.Next(0, 1000).ToString();
            }
            return TxtPassword.Text;
        }

        private void TxtSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

        private void TxtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

        private void TxtPatronumic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

        private void TxtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            {
                NavigationService.GoBack();
            }
        }
    }
}
