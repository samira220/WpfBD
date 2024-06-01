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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtLogin.Text) || string.IsNullOrEmpty(PsPassword.Password))
                {
                    MessageBox.Show("Пожалуйста, заполните логин и пароль!!!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var a = ConnectionClass.connect.Log_Us.Where(d => d.Login == TxtLogin.Text && d.Password == PsPassword.Password).FirstOrDefault();
                    if (a != null)
                    {
                        var z = a.User.FirstOrDefault();
                        if (a.ID_Pass_Log == a.ID_Pass_Log)
                        {
                            MessageBox.Show($"Добро пожаловать {z.FName} {z.Name} ", "Авторизация прошла успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new ReaderPage());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль неверный!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        //private void CheckPassword_Click(object sender, RoutedEventArgs e)
        //{
        //    var checkBox = sender as CheckBox;
        //    if (checkBox.IsChecked.Value)
        //    {
        //        pwdTextBox.Text = pwdPasswordBox.Password; // скопируем в TextBox из PasswordBox
        //        pwdTextBox.Visibility = Visibility.Visible; // TextBox - отобразить
        //        pwdPasswordBox.Visibility = Visibility.Hidden; // PasswordBox - скрыть
        //    }
        //    else
        //    {
        //        pwdPasswordBox.Password = pwdTextBox.Text; // скопируем в PasswordBox из TextBox 
        //        pwdTextBox.Visibility = Visibility.Hidden; // TextBox - скрыть
        //        pwdPasswordBox.Visibility = Visibility.Visible; // PasswordBox - отобразить
        //    }
        //}
    }
}
