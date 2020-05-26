using Dentest.UI.DataBase;
using Dentest.UI.Helpers;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Dentest.UI.Dialogs
{
    /// <summary>
    /// Interaction logic for AppointmentEditAddDialog.xaml
    /// </summary>
    public partial class AppointmentEditAddDialog : UserControl
    {

        Appointment updateAppointment;

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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) &&
                !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)) &&
                !(e.Text == "." && ((TextBox)sender).Text.Length == 0))
                e.Handled = false;

            else
                e.Handled = true;
        }
        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        public AppointmentEditAddDialog(Appointment appointment)
        {
            InitializeComponent();
            updateAppointment = appointment;

            init();

        }


        private void init()
        {
            using (var db = new DentistDbEntities())
            {
                var doctors = db.Doctors.Where(x => !x.ISDELETE).Select(x => new SimpleModel { NAME = x.NAME + " " + x.SURNAME, ID = x.ID }).ToList<SimpleModel>();
                comboDoctor.ItemsSource = doctors;

                var patients = db.Patients.Where(x => !x.ISDELETE).Select(x => new SimpleModel { NAME = x.NAME + " " + x.SURNAME, ID = x.ID }).ToList<SimpleModel>();
                comboHasta.ItemsSource = patients;



                comboType.ItemsSource = Shared.types;



                if (updateAppointment.ID != 0)
                {
                    save.Content = "GÜNCELLE";

                    pickerDate.SelectedDate = updateAppointment.DATE;


                    var indexsDoc = doctors.Select((car, index) => new { car, index }).First(c => c.car.ID == updateAppointment.DOCTORID).index;
                    comboDoctor.SelectedIndex = indexsDoc;

                    var indexsPat = patients.Select((car, index) => new { car, index }).First(c => c.car.ID == updateAppointment.PATIENTID).index;
                    comboHasta.SelectedIndex = indexsPat;

                    var indexsType = Shared.types.Select((car, index) => new { car, index }).First(c => c.car.NAME == updateAppointment.TYPE).index;
                    comboType.SelectedIndex = indexsType;


                    var todaysAppo = db.Appointments.Where(x => x.DOCTORID == updateAppointment.DOCTORID && x.DATE == updateAppointment.DATE && x.HOUR != updateAppointment.HOUR).Select(x => x.HOUR).ToList();
                    var allHoures = Shared.houres;

                    allHoures = allHoures.Where(x => !todaysAppo.Contains(x.ID)).ToList();
                    comboHour.ItemsSource = allHoures;

                    var indexhour = allHoures.Select((car, index) => new { car, index }).First(c => c.car.ID == updateAppointment.HOUR).index;
                    comboHour.SelectedIndex = indexhour;

                    txPrice.Text = updateAppointment.PRICE+"";
                    txDescription.Text = updateAppointment.DESCRIPTION;
                    chPaid.IsChecked = updateAppointment.ISPAID;
                    chCame.IsChecked = updateAppointment.ISCAME;
            

                }

            }
        }

        private void comboDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getDays();
        }


        private void pickerDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            getDays();
        }

        private void getDays()
        {
            if (string.IsNullOrEmpty(pickerDate.Text.ToString()))
            {
                comboHour.ItemsSource = null;
                return;

            }

            var selectedDoc = comboDoctor.SelectedItem as SimpleModel;
            var date = DateTime.ParseExact(pickerDate.Text.ToString(), "d.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture).Date;


            if (selectedDoc == null || date == null)
            {
                comboHour.ItemsSource = null;
                return;
            }

            using (var db = new DentistDbEntities())
            {
                var todaysAppo = db.Appointments.Where(x => x.DOCTORID == selectedDoc.ID && x.DATE == date).Select(x => x.HOUR).ToList();
                var allHoures = Shared.houres;

                allHoures = allHoures.Where(x => !todaysAppo.Contains(x.ID)).ToList();
                comboHour.ItemsSource = allHoures;

            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.CloseDialogCommand.Execute(false, null);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            if ((comboDoctor.SelectedItem) == null)
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }


            if ((comboHasta.SelectedItem) == null)
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }

            if ((comboType.SelectedItem) == null)
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }


            if ((comboHour.SelectedItem) == null)
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }


            var price = txPrice.Text.Trim();
            var desc = txDescription.Text.Trim();

            var doctor = ((SimpleModel)comboDoctor.SelectedItem).ID;
            var patient = ((SimpleModel)comboHasta.SelectedItem).ID;
            var type = ((SimpleModel)comboType.SelectedItem).NAME;
            var hour = ((SimpleModel)comboHour.SelectedItem).ID;
            var isPaid = chPaid.IsChecked;
            var isCame = chCame.IsChecked;


            if (string.IsNullOrEmpty(price) || string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(pickerDate.Text))
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }

            var date = DateTime.ParseExact(pickerDate.Text.ToString(), "d.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);


            ProgressOn();
            using (var db = new DentistDbEntities())
            {

                //insert
                if (updateAppointment.ID == 0)
                {
                    var model = db.Appointments.Add(db.Appointments.Create());
                    model.DOCTORID = doctor;
                    model.PATIENTID = patient;
                    model.DATE = date;
                    model.HOUR = hour;
                    model.PRICE = decimal.Parse(price);
                    model.ISCAME = (bool)isCame;
                    model.ISPAID = (bool)isPaid;
                    model.TYPE = type;
                    model.DESCRIPTION = desc;
                    db.SaveChanges();
                }
                //update
                else
                {
                    var model = db.Appointments.SingleOrDefault(row => row.ID == updateAppointment.ID);
                    model.DOCTORID = doctor;
                    model.PATIENTID = patient;
                    model.DATE = date;
                    model.HOUR = hour;
                    model.PRICE = decimal.Parse(price);
                    model.ISCAME = (bool)isCame;
                    model.ISPAID = (bool)isPaid;
                    model.TYPE = type;
                    model.DESCRIPTION = desc;
                    db.SaveChanges();

                }

            }

            ProgressOf();
            DialogHost.CloseDialogCommand.Execute(false, null);

        }

    }
}
