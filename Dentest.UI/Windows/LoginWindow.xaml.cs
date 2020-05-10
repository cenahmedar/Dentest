using Dentest.UI.DataBase;
using Dentest.UI.Helpers;
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

namespace Dentest.UI.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private void ProgressOn()
        {
            mainWindow.IsEnabled = false;
            progressBar.Visibility = Visibility.Visible;
        }

        private void ProgressOf()
        {
            mainWindow.IsEnabled = true;
            progressBar.Visibility = Visibility.Hidden;
        }

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var username = txUsername.Text;
            var password = txPassword.Password;

            if(username==null || username.Length == 0)
            {
                MessageBox.Show("Lütfen Kullanıcı Adı Giriniz", "");
                return;
            }

            if (password == null || password.Length == 0)
            {
                MessageBox.Show("Lütfen Şifre Adı Giriniz", "");
                return;
            }

            ProgressOn();
            using(var db = new DentistDbEntities())
            {
                var user = db.Users.FirstOrDefault(x => x.USERNAME == username);
                if (user == null)
                {
                    MessageBox.Show("Kullanıcı Buluamadı", "");
                    ProgressOf();
                    return;
                }

                if(user.PASSWORD!= password)
                {
                    MessageBox.Show("Yanlış Şifre", "");
                    ProgressOf();
                    return;
                }

                Shared.OnlineUser = user;

                HomePageWindow main = new HomePageWindow();
                App.Current.MainWindow = main;
                this.Close();
                main.Show();

            }

           

        }
    }
}
