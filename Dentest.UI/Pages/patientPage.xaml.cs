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
    /// Interaction logic for PaccientPage.xaml
    /// </summary>
    public partial class PaccientPage : Page
    {

        private List<Patient> patients;
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


        private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (patients != null && patients.Count != 0)
            {
                if (txSearch.Text.Length == 0)
                {
                    mDataGrid.ItemsSource = patients;

                    this.mDataGrid.CancelEdit();
                    this.mDataGrid.CancelEdit();
                    mDataGrid.Items.Refresh();
                    return;
                }

                var filtered = patients.Where(o => MContains.Check(o.NAME, txSearch.Text) || MContains.Check(o.SURNAME, txSearch.Text)
                || MContains.Check(o.PERSONELID, txSearch.Text) || MContains.Check(o.ADRESS, txSearch.Text)
                || MContains.Check(o.PHONE, txSearch.Text) || MContains.Check(o.GENDER, txSearch.Text) || MContains.Check(o.INSURANCENO, txSearch.Text));

                mDataGrid.ItemsSource = filtered;


                this.mDataGrid.CancelEdit();
                this.mDataGrid.CancelEdit();
                mDataGrid.Items.Refresh();
            }

        }
        public PaccientPage()
        {
            InitializeComponent();
            getList();
        }

        private void getList()
        {
            ProgressOn();
            using (var db = new DentistDbEntities())
            {

                patients = db.Patients.Where(x => !x.ISDELETE).ToList();
                if (patients == null || !patients.Any())
                {
                    MessageBox.Show("Veri Buluamadı", "");
                    mDataGrid.ItemsSource = null;
                    ProgressOf();
                    return;
                }

                mDataGrid.ItemsSource = patients;
            }

            ProgressOf();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ProgressOn();
            Patient clickedDoctor = ((FrameworkElement)sender).DataContext as Patient;
            using (var db = new DentistDbEntities())
            {

                var query = db.Patients.SingleOrDefault(x => x.ID == clickedDoctor.ID);
                query.ISDELETE = true;
                db.SaveChanges();

            }
            ProgressOf();
            getList();

        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            Patient clickedDoctor = ((FrameworkElement)sender).DataContext as Patient;

            var result = await DialogHost.Show(new PatientEditAddDialog(clickedDoctor), "RootDialog", ExtendedAddSecClosingEventHandler);

        }
        private void ExtendedAddSecClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            getList();
        }

        private async void add_Click(object sender, RoutedEventArgs e)
        {
            var result = await DialogHost.Show(new PatientEditAddDialog(new Patient()), "RootDialog", ExtendedAddSecClosingEventHandler);
        }

    }
}
