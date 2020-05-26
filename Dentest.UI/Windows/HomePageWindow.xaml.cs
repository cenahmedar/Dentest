using Dentest.UI.Pages;
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
    /// Interaction logic for HomePageWindow.xaml
    /// </summary>
    public partial class HomePageWindow : Window
    {
        public HomePageWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new MainPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var docColor = btnDoc.Template.FindName("doctorColor", btnDoc) as Rectangle;
            var colorPac = btnPacc.Template.FindName("colorPac", btnPacc) as Rectangle;
            var listColor = btnList.Template.FindName("listColor", btnList) as Rectangle;
            var calColor = btnCal.Template.FindName("calColor", btnCal) as Rectangle;
            var moneyColor = btnMoney.Template.FindName("moneyColor", btnMoney) as Rectangle;


            docColor.Fill = Brushes.Aquamarine;
            colorPac.Fill = Brushes.Gray;
            listColor.Fill = Brushes.Gray;
            calColor.Fill = Brushes.Gray;
            moneyColor.Fill = Brushes.Gray;

            mainFrame.NavigationService.Navigate(new DoctorPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var docColor = btnDoc.Template.FindName("doctorColor", btnDoc) as Rectangle;
            var colorPac = btnPacc.Template.FindName("colorPac", btnPacc) as Rectangle;
            var listColor = btnList.Template.FindName("listColor", btnList) as Rectangle;
            var calColor = btnCal.Template.FindName("calColor", btnCal) as Rectangle;
            var moneyColor = btnMoney.Template.FindName("moneyColor", btnMoney) as Rectangle;


            docColor.Fill = Brushes.Gray;
            colorPac.Fill = Brushes.Aquamarine;
            listColor.Fill = Brushes.Gray;
            calColor.Fill = Brushes.Gray;
            moneyColor.Fill = Brushes.Gray;

            mainFrame.NavigationService.Navigate(new PaccientPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var docColor = btnDoc.Template.FindName("doctorColor", btnDoc) as Rectangle;
            var colorPac = btnPacc.Template.FindName("colorPac", btnPacc) as Rectangle;
            var listColor = btnList.Template.FindName("listColor", btnList) as Rectangle;
            var calColor = btnCal.Template.FindName("calColor", btnCal) as Rectangle;
            var moneyColor = btnMoney.Template.FindName("moneyColor", btnMoney) as Rectangle;


            docColor.Fill = Brushes.Gray;
            colorPac.Fill = Brushes.Gray;
            listColor.Fill = Brushes.Aquamarine;
            calColor.Fill = Brushes.Gray;
            moneyColor.Fill = Brushes.Gray;

            mainFrame.NavigationService.Navigate(new ListPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var docColor = btnDoc.Template.FindName("doctorColor", btnDoc) as Rectangle;
            var colorPac = btnPacc.Template.FindName("colorPac", btnPacc) as Rectangle;
            var listColor = btnList.Template.FindName("listColor", btnList) as Rectangle;
            var calColor = btnCal.Template.FindName("calColor", btnCal) as Rectangle;
            var moneyColor = btnMoney.Template.FindName("moneyColor", btnMoney) as Rectangle;


            docColor.Fill = Brushes.Gray;
            colorPac.Fill = Brushes.Gray;
            listColor.Fill = Brushes.Gray;
            calColor.Fill = Brushes.Aquamarine;
            moneyColor.Fill = Brushes.Gray;

            mainFrame.NavigationService.Navigate(new CalPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var docColor = btnDoc.Template.FindName("doctorColor", btnDoc) as Rectangle;
            var colorPac = btnPacc.Template.FindName("colorPac", btnPacc) as Rectangle;
            var listColor = btnList.Template.FindName("listColor", btnList) as Rectangle;
            var calColor = btnCal.Template.FindName("calColor", btnCal) as Rectangle;
            var moneyColor = btnMoney.Template.FindName("moneyColor", btnMoney) as Rectangle;


            docColor.Fill = Brushes.Gray;
            colorPac.Fill = Brushes.Gray;
            listColor.Fill = Brushes.Gray;
            calColor.Fill = Brushes.Gray;
            moneyColor.Fill = Brushes.Aquamarine;

            mainFrame.NavigationService.Navigate(new MoneyPage());
        }

        //profile
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var docColor = btnDoc.Template.FindName("doctorColor", btnDoc) as Rectangle;
            var colorPac = btnPacc.Template.FindName("colorPac", btnPacc) as Rectangle;
            var listColor = btnList.Template.FindName("listColor", btnList) as Rectangle;
            var calColor = btnCal.Template.FindName("calColor", btnCal) as Rectangle;
            var moneyColor = btnMoney.Template.FindName("moneyColor", btnMoney) as Rectangle;


            docColor.Fill = Brushes.Gray;
            colorPac.Fill = Brushes.Gray;
            listColor.Fill = Brushes.Gray;
            calColor.Fill = Brushes.Gray;
            moneyColor.Fill = Brushes.Gray;

            mainFrame.NavigationService.Navigate(new ProfilePage());
        }

        //logout
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            LoginWindow main = new LoginWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
