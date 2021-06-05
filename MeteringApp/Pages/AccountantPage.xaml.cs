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
using Word = Microsoft.Office.Interop.Word;

namespace MeteringApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountantPage.xaml
    /// </summary>
    public partial class AccountantPage : Page
    {
        private Word.Document document = null;
        public AccountantPage()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditMetersPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MeteringAppEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridMeters.ItemsSource = MeteringAppEntities.GetContext().Meters.ToList();
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var metersForRemoving = DGridMeters.SelectedItems.Cast<Meters>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {metersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MeteringAppEntities.GetContext().Meters.RemoveRange(metersForRemoving);
                    MeteringAppEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridMeters.ItemsSource = MeteringAppEntities.GetContext().Meters.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEditMeters_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditMetersPage((sender as Button).DataContext as Meters));
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            FormDocument();

            document.Application.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Show();
            document.Application.Quit();
            document = null;

            // даёт доступ к элементам окна StartWindow
            GeneralWindow startWindow = (GeneralWindow)Application.Current.MainWindow;

            startWindow.GeneralWindow1.WindowState = WindowState.Minimized;
        }

        private void FormDocument()
        {
            try
            {
                var rows = DGridMeters.ItemsSource.Cast<Meters>().ToList();
                if (rows.Count == 0)
                {
                    MessageBox.Show("Нет выбранных книг", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var app = new Word.Application();
                document = app.Documents.Add();
                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table table = document.Tables.Add(tableRange, rows.Count + 1, 6);
                table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;
                cellRange = table.Cell(1, 1).Range;
                cellRange.Text = "№";
                cellRange = table.Cell(1, 2).Range;
                cellRange.Text = "Имя клиента";
                cellRange = table.Cell(1, 3).Range;
                cellRange.Text = "Фамилия клиента";
                cellRange = table.Cell(1, 4).Range;
                cellRange.Text = "Показания холодной воды";
                cellRange = table.Cell(1, 5).Range;
                cellRange.Text = "Показания горячей воды";
                cellRange = table.Cell(1, 6).Range;
                cellRange.Text = "Дата";

                table.Rows[1].Range.Bold = 1;
                int currentRow = 1;
                foreach (var row in rows)
                {
                    currentRow++;
                    cellRange = table.Cell(currentRow, 1).Range;
                    cellRange.Text = row.ID.ToString();

                    cellRange = table.Cell(currentRow, 2).Range;
                    cellRange.Text = row.ClientFirstName;

                    cellRange = table.Cell(currentRow, 3).Range;
                    cellRange.Text = row.ClientSecondName;

                    cellRange = table.Cell(currentRow, 4).Range;
                    cellRange.Text = row.ColdWaterMeter.ToString();

                    cellRange = table.Cell(currentRow, 5).Range;
                    cellRange.Text = row.HotWaterMeter.ToString();

                    cellRange = table.Cell(currentRow, 6).Range;
                    cellRange.Text = row.Datetime.ToShortDateString();
                }

                document.Paragraphs.Add();
                Word.Paragraph sum = document.Paragraphs.Add();
                sum.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                Word.Range sumRange = sum.Range;
                sumRange.Bold = 1;
            }
            catch
            {
                MessageBox.Show("Ошибка в формировании отчета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
