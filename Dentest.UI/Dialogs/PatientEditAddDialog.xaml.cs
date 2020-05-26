using Dentest.UI.DataBase;
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
namespace Dentest.UI.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientEditAddDialog.xaml
    /// </summary>
    public partial class PatientEditAddDialog : UserControl
    {

        Patient updatePacient;

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
        public PatientEditAddDialog(Patient patient)
        {
            InitializeComponent();


            updatePacient = patient;

            if (updatePacient.ID != 0)
            {
                save.Content = "GÜNCELLE";
                txName.Text = updatePacient.NAME;
                txSurname.Text = updatePacient.SURNAME;
                txPhone.Text = updatePacient.PHONE;
                txAdress.Text = updatePacient.ADRESS;
                txTc.Text = updatePacient.PERSONELID;
                txSigorta.Text = updatePacient.INSURANCENO;
                pickbirthDay.SelectedDate = updatePacient.BIRTHDAY;
                comboGender.SelectedItem = updatePacient.GENDER;

            }

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.CloseDialogCommand.Execute(false, null);
        }



        private void save_Click(object sender, RoutedEventArgs e)
        {


            var name = txName.Text.Trim();
            var surname = txSurname.Text.Trim();
            var phone = txPhone.Text.Trim();
            var adres = txAdress.Text.Trim();
            var tc = txTc.Text.Trim();
            var incNo = txSigorta.Text.Trim();

            if((comboGender.SelectedItem)==null) {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }
            var gender = ((ComboBoxItem)comboGender.SelectedItem).Content.ToString();


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(adres) ||
                string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(incNo) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(pickbirthDay.Text))
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.", "");
                return;
            }

            var birthday = DateTime.ParseExact(pickbirthDay.Text.ToString(), "d.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

            ProgressOn();
            using (var db = new DentistDbEntities())
            {

                //insert
                if (updatePacient.ID == 0)
                {
                    var model = db.Patients.Add(db.Patients.Create());
                    model.NAME = name;
                    model.SURNAME = surname;
                    model.BIRTHDAY = birthday;
                    model.PHONE = phone;
                    model.ADRESS = adres;
                    model.PERSONELID = tc;
                    model.INSURANCENO = incNo;
                    model.GENDER = gender;
                    db.SaveChanges();
                }
                //update
                else
                {
                    var model = db.Patients.SingleOrDefault(row => row.ID == updatePacient.ID);
                    model.NAME = name;
                    model.SURNAME = surname;
                    model.BIRTHDAY = birthday;
                    model.PHONE = phone;
                    model.ADRESS = adres;
                    model.PERSONELID = tc;
                    model.INSURANCENO = incNo;
                    model.GENDER = gender;
                    db.SaveChanges();

                }

            }

            ProgressOf();
            DialogHost.CloseDialogCommand.Execute(false, null);

        }


    }
}
