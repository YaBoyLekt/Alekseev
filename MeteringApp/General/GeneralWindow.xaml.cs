using MeteringApp.Classes;
using MeteringApp.Pages;
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

namespace MeteringApp
{
    /// <summary>
    /// Логика взаимодействия для GeneralWindow.xaml
    /// </summary>
    public partial class GeneralWindow : Window
    {
        public GeneralWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
            Manager.MainFrame = MainFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                ResizeMode = ResizeMode.CanResize;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
                ResizeMode = ResizeMode.NoResize;
                Height = 600;
                Width = 1000;
            }
        }
    }
}
