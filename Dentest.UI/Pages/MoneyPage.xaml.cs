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
    /// Interaction logic for MoneyPage.xaml
    /// </summary>
    public partial class MoneyPage : Page
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
                || MContains.Check(o.PRICE.ToString(), txSearch.Text));

                mDataGrid.ItemsSource = filtered;


                this.mDataGrid.CancelEdit();
                this.mDataGrid.CancelEdit();
                mDataGrid.Items.Refresh();
            }

        }

        public MoneyPage()
        {
            InitializeComponent();
            getList();
        }

        private void getList()
        {
            ProgressOn();
            using (var db = new DentistDbEntities())
            {

                list = db.VW_Appointment.Where(x=>x.ISPAID).ToList();
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

    }
}
