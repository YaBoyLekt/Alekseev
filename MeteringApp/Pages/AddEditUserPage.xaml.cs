using MeteringApp.General;
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
using MeteringApp.Classes;

namespace MeteringApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditUserPage.xaml
    /// </summary>
    public partial class AddEditUserPage : Page
    {
        private Users _currentUser = new Users();
        public AddEditUserPage(Users selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentUser = selectedUser;
            DataContext = _currentUser;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.Username))
                errors.AppendLine("Укажите имя учетной записи");
            if (string.IsNullOrWhiteSpace(_currentUser.FirstName))
                errors.AppendLine("Укажите имя пользователя");
            if (string.IsNullOrWhiteSpace(_currentUser.LastName))
                errors.AppendLine("Укажите фамилию пользователя");
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Укажите пароль");
            else
            {
                Regex r = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"); ;
                if (r.IsMatch(_currentUser.Password))
                    errors.AppendLine("В пароле содержатся недопустимые символы");
            }       

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.ID == 0)
                MeteringAppEntities.GetContext().Users.Add(_currentUser);
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
    }
}
