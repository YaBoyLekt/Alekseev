using MeteringApp.Classes;
using MeteringApp.General;
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

namespace MeteringApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditMetersPage.xaml
    /// </summary>
    public partial class AddEditMetersPage : Page
    {
        private Meters _currentMeters = new Meters();
        public AddEditMetersPage(Meters selectedMeters)
        {
            InitializeComponent();
            if (selectedMeters != null)
                _currentMeters = selectedMeters;
            DataContext = _currentMeters;
            _currentMeters.Datetime = DateTime.Today;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentMeters.ClientFirstName))
                errors.AppendLine("Укажите имя клиента");
            if (string.IsNullOrWhiteSpace(_currentMeters.ClientSecondName))
                errors.AppendLine("Укажите фамилию клиента");
            if (string.IsNullOrWhiteSpace(_currentMeters.ColdWaterMeter.ToString()))
                errors.AppendLine("Укажите показания холодной воды");
            if (string.IsNullOrWhiteSpace(_currentMeters.HotWaterMeter.ToString()))
                errors.AppendLine("Укажите показания горячей воды");
            if (Calendar.SelectedDate > DateTime.Today)
                errors.AppendLine("Укажите правильную дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMeters.ID == 0)
                MeteringAppEntities.GetContext().Meters.Add(_currentMeters);
            try
            {
                MeteringAppEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Calendar.SelectedDate;

            _currentMeters.Datetime = selectedDate.Value.Date;
        }
    }
}
