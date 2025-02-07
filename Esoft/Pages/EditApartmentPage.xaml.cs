using Esoft.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    public partial class EditApartmentPage : Page
    {
        private Apartment _apartment;

        public EditApartmentPage(Apartment apartment)
        {
            InitializeComponent();
            _apartment = apartment;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new EsoftEntities())
                {
                    HouseComboBox.ItemsSource = context.House.Where(h => !h.IsDeleted).ToList();
                    NumberTextBox.Text = _apartment.Number;
                    AreaTextBox.Text = _apartment.Area.ToString();
                    RoomsCountTextBox.Text = _apartment.CountOfRooms.ToString();
                    FloorTextBox.Text = _apartment.Floor.ToString();
                    HouseComboBox.SelectedItem = context.House.FirstOrDefault(h => h.ID == _apartment.HouseID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
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
                    var apartment = context.Apartment.FirstOrDefault(a => a.ID == _apartment.ID);
                    if (apartment != null)
                    {
                        apartment.Number = NumberTextBox.Text;
                        apartment.Area = double.Parse(AreaTextBox.Text);
                        apartment.CountOfRooms = int.Parse(RoomsCountTextBox.Text);
                        apartment.Floor = int.Parse(FloorTextBox.Text);
                        apartment.HouseID = ((House)HouseComboBox.SelectedItem).ID;

                        context.SaveChanges();
                        MessageBox.Show("Изменения успешно сохранены.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }
    }
}

