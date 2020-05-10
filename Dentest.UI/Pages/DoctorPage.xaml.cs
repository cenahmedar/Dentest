using Dentest.UI.DataBase;
using Dentest.UI.Dialogs;
using Dentest.UI.Helpers;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Dentest.UI.Pages
{
    /// <summary>
    /// Interaction logic for DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        private List<Doctor> doctors;
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


        public DoctorPage()
        {
            InitializeComponent();
            getDoctors();
        }



        private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (doctors != null && doctors.Count != 0)
            {
                if (txSearch.Text.Length == 0)
                {
                    mDataGrid.ItemsSource = doctors;

                    this.mDataGrid.CancelEdit();
                    this.mDataGrid.CancelEdit();
                    mDataGrid.Items.Refresh();
                    return;
                }

                var filtered = doctors.Where(o => MContains.Check(o.NAME, txSearch.Text) || MContains.Check(o.SURNAME, txSearch.Text)
                || MContains.Check(o.PERSONELID, txSearch.Text) || MContains.Check(o.ADRESS, txSearch.Text)
                || MContains.Check(o.PHONE, txSearch.Text));

                mDataGrid.ItemsSource = filtered;


                this.mDataGrid.CancelEdit();
                this.mDataGrid.CancelEdit();
                mDataGrid.Items.Refresh();
            }

        }

        private void getDoctors()
        {

            ProgressOn();
            using (var db = new DentistDbEntities())
            {

                doctors = db.Doctors.Where(x=>!x.ISDELETE).ToList();
                if (doctors == null || !doctors.Any())
                {
                    MessageBox.Show("Veri Buluamadı", "");
                    ProgressOf();
                    return;
                }

                mDataGrid.ItemsSource = doctors;
            }

            ProgressOf();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ProgressOn();
            Doctor clickedDoctor = ((FrameworkElement)sender).DataContext as Doctor;
            using (var db = new DentistDbEntities())
            {

                var query = db.Doctors.SingleOrDefault(x => x.ID == clickedDoctor.ID);
                query.ISDELETE = true;
                db.SaveChanges();

            }
            ProgressOf();
            getDoctors();

        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            Doctor clickedDoctor = ((FrameworkElement)sender).DataContext as Doctor;

            var result = await DialogHost.Show(new DoctorEditAddDialog(clickedDoctor), "RootDialog", ExtendedAddSecClosingEventHandler);

        }
        private void ExtendedAddSecClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            getDoctors();
        }

        private async void add_Click(object sender, RoutedEventArgs e)
        {
            var result = await DialogHost.Show(new DoctorEditAddDialog(new Doctor()), "RootDialog", ExtendedAddSecClosingEventHandler);
        }
    }
}
