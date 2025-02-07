using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Esoft.Data;

namespace Esoft.Pages
{
    public partial class ListViewHousePage : Page
    {
        public ListViewHousePage()
        {
            InitializeComponent();
            LoadHouses();
            LoadResidentialComplexes();
        }

        private void LoadHouses()
        {
            try
            {
                var houses = EsoftEntities.GetContext().House
                    .Include("ResidentialComplex")
                    .Include("Street")
                    .Include("Apartment")
                    .ToList();
                HouseListView.ItemsSource = houses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке домов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadResidentialComplexes()
        {
            try
            {
                var complexes = EsoftEntities.GetContext().ResidentialComplex.ToList();
                complexes.Insert(0, new ResidentialComplex { Name = "Все улицы" }); 
                ResidentialComplexComboBox.ItemsSource = complexes;
                ResidentialComplexComboBox.DisplayMemberPath = "Name"; 
                ResidentialComplexComboBox.SelectedIndex = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке жилых комплексов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResidentialComplexComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterHouses();
        }

        private void StreetTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterHouses();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterHouses();
        }

        private void FilterHouses()
        {
            try
            {
                var filteredHouses = EsoftEntities.GetContext().House
                    .Include("ResidentialComplex")
                    .Include("Street")
                    .Include("Apartment")
                    .AsQueryable();

                if (ResidentialComplexComboBox.SelectedItem is ResidentialComplex selectedComplex && selectedComplex.Name != "Все улицы")
                {
                    filteredHouses = filteredHouses.Where(h => h.ResidentialComplexID == selectedComplex.ID);
                }

                if (!string.IsNullOrEmpty(StreetTextBox.Text))
                {
                    filteredHouses = filteredHouses.Where(h => h.Street.Name.Contains(StreetTextBox.Text));
                }

                HouseListView.ItemsSource = filteredHouses.OrderBy(h => h.Street.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации домов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NavigateToApartmentPage(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedHouse = HouseListView.SelectedItem as House;

                if (selectedHouse == null)
                {
                    MessageBox.Show("Выберите дом для перехода к квартирам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (selectedHouse.Apartment == null || !selectedHouse.Apartment.Any())
                {
                    MessageBox.Show("Для выбранного дома нет доступных квартир.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Classes.Manager.MainFrame.Navigate(new Pages.ListViewApartmentPage(selectedHouse));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при переходе на страницу квартир: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NavigateToReportPage(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Manager.MainFrame.Navigate(new Pages.ReportPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при переходе на страницу отчетов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
