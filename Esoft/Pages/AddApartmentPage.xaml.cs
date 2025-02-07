using Esoft.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    public partial class AddApartmentPage : Page
    {
        public event Action<Apartment> ApartmentAdded;
        public AddApartmentPage()
        {
            InitializeComponent();
            LoadHouses();
        }

        private void LoadHouses()
        {
            try
            {
                using (var context = new EsoftEntities())
                {
                    HouseComboBox.ItemsSource = context.House.Where(h => !h.IsDeleted).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке домов: {ex.Message}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NumberTextBox.Text) ||
                    string.IsNullOrWhiteSpace(AreaTextBox.Text) ||
                    string.IsNullOrWhiteSpace(RoomsCountTextBox.Text) ||
                    string.IsNullOrWhiteSpace(FloorTextBox.Text) ||
                    HouseComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                using (var context = new EsoftEntities())
                {
                    var apartment = new Apartment
                    {
                        Number = NumberTextBox.Text,
                        Area = double.Parse(AreaTextBox.Text),
                        CountOfRooms = int.Parse(RoomsCountTextBox.Text),
                        Floor = int.Parse(FloorTextBox.Text),
                        HouseID = ((House)HouseComboBox.SelectedItem).ID,
                        IsSold = false,
                        IsDeleted = false
                    };

                    context.Apartment.Add(apartment);
                    context.SaveChanges();
                    MessageBox.Show("Квартира успешно добавлена.");
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении квартиры: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            NumberTextBox.Text = string.Empty;
            AreaTextBox.Text = string.Empty;
            RoomsCountTextBox.Text = string.Empty;
            FloorTextBox.Text = string.Empty;
            HouseComboBox.SelectedItem = null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }
    }
}
