using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Esoft.Data;

namespace Esoft.Pages
{
    public partial class ListViewApartmentPage : Page
    {
        private int currentPage = 1;
        private const int pageSize = 20;
        private House _selectedHouse;
        private List<Apartment> allApartments;

        public ListViewApartmentPage(House selectedHouse)
        {
            InitializeComponent();
            _selectedHouse = selectedHouse;
            LoadApartments();
            LoadHouses();
        }

        private void LoadHouses()
        {
            try
            {
                using (var context = EsoftEntities.GetContext())
                {
                    var houses = context.House
                        .Where(h => !h.IsDeleted)
                        .ToList();

                    var allHousesOption = new House { Number = "Все дома" };
                    houses.Insert(0, allHousesOption);

                    HouseComboBox.ItemsSource = houses;
                    HouseComboBox.DisplayMemberPath = "Number";
                    HouseComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ошибка при загрузке домов", ex);
            }
        }

        private void LoadApartments()
        {
            var apartments = EsoftEntities.GetContext().Apartment
                .Where(a => a.HouseID == _selectedHouse.ID)
                .ToList();
            allApartments = apartments;
            ApartmentListView.ItemsSource = apartments;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }

        private void FilterApartments()
        {
            try
            {
                var apartments = allApartments.AsQueryable();

                if (!string.IsNullOrWhiteSpace(ApartmentNumberTextBox.Text))
                {
                    apartments = apartments
                        .Where(a => a.Number.Contains(ApartmentNumberTextBox.Text));
                }

                if (HouseComboBox.SelectedItem is House selectedHouse && selectedHouse.Number != "Все дома")
                {
                    apartments = apartments
                        .Where(a => a.HouseID == selectedHouse.ID);
                }

                var filteredApartments = apartments
                    .OrderBy(a => a.House.Number)
                    .ThenBy(a => a.Number)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                ApartmentListView.ItemsSource = filteredApartments;

                if (!filteredApartments.Any())
                {
                    MessageBox.Show("Нет квартир, соответствующих критериям поиска.");
                }

                UpdatePageInfo(apartments.Count());
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Ошибка при фильтрации квартир", ex);
            }
        }

        private void UpdatePageInfo(int totalItems)
        {
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            PageInfoTextBlock.Text = $"Страница {currentPage} из {totalPages}";
        }

        private void AddApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            var addApartmentPage = new AddApartmentPage();
            addApartmentPage.ApartmentAdded += OnApartmentAdded;
            NavigationService.Navigate(addApartmentPage);
        }

        private void OnApartmentAdded(Apartment newApartment)
        {
            allApartments.Add(newApartment);
            FilterApartments();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)allApartments.Count / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                FilterApartments();
            }
        }

        private void ApartmentNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterApartments();
        }

        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterApartments();
        }

        private void HouseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterApartments();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterApartments();
        }

        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}");
        }
    }
}
