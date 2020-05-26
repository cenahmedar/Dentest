using Dentest.UI.DataBase;
using Dentest.UI.Helpers;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Dentest.UI.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        User user;
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

        public ProfilePage()
        {
            InitializeComponent();
            user = Shared.OnlineUser;

            init();

        }

        private void init()
        {
            ProgressOn();
            using (var db = new DentistDbEntities())
            {
                user = Shared.OnlineUser = db.Users.FirstOrDefault(x => x.ID == user.ID);

                txEmail.Text = user.EMAIL;
                txName.Text = user.NAME;
                txSurname.Text = user.SURNAME;
                txUsername.Text = user.USERNAME;

            }
            ProgressOf();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txEmail.Text) || string.IsNullOrEmpty(txName.Text) ||
                string.IsNullOrEmpty(txSurname.Text) || string.IsNullOrEmpty(txUsername.Text))
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }
            ProgressOn();
            using (var db = new DentistDbEntities())
            {
                var model = db.Users.SingleOrDefault(row => row.ID == user.ID);
                model.NAME = txName.Text;
                model.SURNAME = txSurname.Text;
                model.USERNAME = txUsername.Text;
                model.EMAIL = txEmail.Text;
                db.SaveChanges();
                user = Shared.OnlineUser = model;
                MessageBox.Show("Başarılı İşlem.", "");
            }

            ProgressOf();
        }
    }
}
