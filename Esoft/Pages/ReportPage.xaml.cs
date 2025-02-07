using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Esoft.Data;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
            LoadResidentialComplexes();
        }

        private void LoadResidentialComplexes()
        {
            try
            {
                using (var context = EsoftEntities.GetContext())
                {
                    var complexes = context.ResidentialComplex
                        .Where(rc => !rc.IsDeleted) // Фильтр для исключения удаленных комплексов
                        .ToList();
                    ResidentialComplexComboBox.ItemsSource = complexes;
                    ResidentialComplexComboBox.DisplayMemberPath = "Name"; // Отображаем название комплекса
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ошибка при загрузке жилых комплексов", ex);
            }
        }

        // Обработчик изменения выбора в ComboBox
        private void ResidentialComplexComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GenerateReport();
        }

        // Генерация отчета
        private void GenerateReport()
        {
            try
            {
                if (ResidentialComplexComboBox.SelectedItem is ResidentialComplex selectedComplex)
                {
                    var reportData = GetReportData(selectedComplex.ID);
                    ReportListView.ItemsSource = reportData;
                }
                else
                {
                    MessageBox.Show("Выберите жилой комплекс для генерации отчета.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ошибка при генерации отчета", ex);
            }
        }

        // Получение данных для отчета
        private List<ReportItem> GetReportData(int residentialComplexId)
        {
            using (var context = EsoftEntities.GetContext())
            {
                var reportData = context.ResidentialComplex
                    .Where(rc => rc.ID == residentialComplexId)
                    .Select(rc => new ReportItem
                    {
                        ResidentialComplex = rc,
                        TotalApartments = rc.House.Sum(h => h.Apartment.Count(a => !a.IsDeleted)),
                        SoldApartments = rc.House.Sum(h => h.Apartment.Count(a => a.IsSold && !a.IsDeleted)),
                        AvailableApartments = rc.House.Sum(h => h.Apartment.Count(a => !a.IsSold && !a.IsDeleted))
                    })
                    .ToList();

                return reportData;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }

        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // Класс для хранения данных отчета
    public class ReportItem
    {
        public ResidentialComplex ResidentialComplex { get; set; }
        public int TotalApartments { get; set; }
        public int SoldApartments { get; set; }
        public int AvailableApartments { get; set; }
    }
}
