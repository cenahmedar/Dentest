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
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {

        private List<VW_Appointment> list;
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
            if (list != null && list.Count != 0)
            {
                if (txSearch.Text.Length == 0)
                {
                    mDataGrid.ItemsSource = list;

                    this.mDataGrid.CancelEdit();
                    this.mDataGrid.CancelEdit();
                    mDataGrid.Items.Refresh();
                    return;
                }

                var filtered = list.Where(o => MContains.Check(o.DOCTORFULLNAME, txSearch.Text) || MContains.Check(o.DOCTORFULLNAME, txSearch.Text)
                || MContains.Check(o.DESCRIPTION, txSearch.Text) || MContains.Check(o.TYPE, txSearch.Text)
                || MContains.Check(o.HOUR.ToString(), txSearch.Text) || MContains.Check(o.DATE.ToString(), txSearch.Text) || MContains.Check(o.PRICE.ToString(), txSearch.Text));

                mDataGrid.ItemsSource = filtered;


                this.mDataGrid.CancelEdit();
                this.mDataGrid.CancelEdit();
                mDataGrid.Items.Refresh();
            }

        }


        public ListPage()
        {
            InitializeComponent();
            getList();
        }

        private void getList()
        {
            ProgressOn();
            using (var db = new DentistDbEntities())
            {

                list = db.VW_Appointment.ToList();
                if (list == null || !list.Any())
                {
                    MessageBox.Show("Veri Buluamadı", "");
                    mDataGrid.ItemsSource = null;
                    ProgressOf();
                    return;
                }

                mDataGrid.ItemsSource = list;
            }

            ProgressOf();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ProgressOn();
            VW_Appointment clickedDoctor = ((FrameworkElement)sender).DataContext as VW_Appointment;
            using (var db = new DentistDbEntities())
            {

                var query = db.Appointments.SingleOrDefault(x => x.ID == clickedDoctor.ID);
                db.Appointments.Attach(query);
                db.Appointments.Remove(query);
                db.SaveChanges();

            }
            ProgressOf();
            getList();

        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            VW_Appointment temp = ((FrameworkElement)sender).DataContext as VW_Appointment;
            Appointment clickedDoctor = new Appointment
            {
                ID = temp.ID,
                DOCTORID = temp.DOCTORID,
                PATIENTID = temp.PATIENTID,
                DATE = temp.DATE,
                HOUR = temp.HOUR,
                PRICE = temp.PRICE,
                ISCAME = temp.ISCAME,
                ISPAID = temp.ISPAID,
                TYPE = temp.TYPE,
                DESCRIPTION = temp.DESCRIPTION
            };
            var result = await DialogHost.Show(new AppointmentEditAddDialog(clickedDoctor), "RootDialog", ExtendedAddSecClosingEventHandler);

        }
        private void ExtendedAddSecClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            getList();
        }

        private async void add_Click(object sender, RoutedEventArgs e)
        {
            var result = await DialogHost.Show(new AppointmentEditAddDialog(new Appointment()), "RootDialog", ExtendedAddSecClosingEventHandler);
        }




    }
}
