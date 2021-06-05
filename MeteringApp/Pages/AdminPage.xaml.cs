using MeteringApp.Classes;
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
using MeteringApp.General;

namespace MeteringApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditUserPage(null));
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            DGridUsers.Visibility = Visibility.Hidden;
            DGridHistory.Visibility = Visibility.Visible;
            BtnAdd.Visibility = Visibility.Hidden;
            BtnDel.Visibility = Visibility.Hidden;
            TextBoxUserSearch.Visibility = Visibility.Hidden;
        }
        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            DGridHistory.Visibility = Visibility.Hidden;
            DGridUsers.Visibility = Visibility.Visible;
            BtnAdd.Visibility = Visibility.Visible;
            BtnDel.Visibility = Visibility.Visible;
            TextBoxUserSearch.Visibility = Visibility.Visible;
        }

        private void BtnEditPass_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditUserPage((sender as Button).DataContext as Users));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MeteringAppEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHistory.ItemsSource = MeteringAppEntities.GetContext().LoginHistory.ToList();
                DGridUsers.ItemsSource = MeteringAppEntities.GetContext().Users.ToList();
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGridUsers.SelectedItems.Cast<Users>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MeteringAppEntities.GetContext().Users.RemoveRange(usersForRemoving);
                    MeteringAppEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridUsers.ItemsSource = MeteringAppEntities.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void TextBoxUserSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Users> currentUser = MeteringAppEntities.GetContext().Users.ToList();
            currentUser = currentUser.Where(p => p.LastName.ToLower().Contains(TextBoxUserSearch.Text.ToLower()) || p.Username.ToLower().Contains(TextBoxUserSearch.Text.ToLower())).ToList();
            DGridUsers.ItemsSource = currentUser;
        }
    }
}
