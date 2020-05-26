using Dentest.UI.DataBase;
using Jarloo.Calendar;
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

namespace Dentest.UI.Pages
{
    /// <summary>
    /// Interaction logic for CalPage.xaml
    /// </summary>
    public partial class CalPage : Page
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

        public CalPage()
        {
            InitializeComponent();

            List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            cboMonth.ItemsSource = months;

            for (int i = -50; i < 50; i++)
            {
                cboYear.Items.Add(DateTime.Today.AddYears(i).Year);
            }

            cboMonth.SelectedItem = months.FirstOrDefault(w => w == DateTime.Today.ToString("MMMM"));
            cboYear.SelectedItem = DateTime.Today.Year;

            cboMonth.SelectionChanged += (o, e) => RefreshCalendar();
            cboYear.SelectionChanged += (o, e) => RefreshCalendar();
            // var temp = Calendar.Days[0].Notes = "ss";

            getList();
        }



        private void RefreshCalendar()
        {
            if (cboYear.SelectedItem == null) return;
            if (cboMonth.SelectedItem == null) return;

            int year = (int)cboYear.SelectedItem;

            int month = cboMonth.SelectedIndex + 1;

            DateTime targetDate = new DateTime(year, month, 1);

            Calendar.BuildCalendar(targetDate);

            getList();
        }

        private void Calendar_DayChanged(object sender, DayChangedEventArgs e)
        {
            //save the text edits to persistant storage
        }

        private void getList()
        {
            ProgressOn();
            var dates = Calendar.Days.Select(x => x.Date).ToList();
            using (var db = new DentistDbEntities())
            {
                var first = dates[0];
                var last = dates[dates.Count - 1];
                var list = db.VW_Appointment.Where(x=> x.DATE >= first && x.DATE <= last).ToList();

                foreach(var item in list)
                {
                    Calendar.Days.FirstOrDefault(x => x.Date == item.DATE).Notes = string.IsNullOrEmpty( Calendar.Days.FirstOrDefault(x => x.Date == item.DATE).Notes)? item.PATIENTFULLNAME 
                        : Calendar.Days.FirstOrDefault(x => x.Date == item.DATE).Notes + " - "+ item.PATIENTFULLNAME;
                }
            }

            ProgressOf();
           
        }
    }
}
