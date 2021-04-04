using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Models;
using RealEstateAgency.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class LocationUpdatePage : Page
    {
        private readonly RealEstate _realEstate;

        public LocationUpdatePage()
        {
            InitializeComponent();
            LoadCombobox();
        }

        public LocationUpdatePage(RealEstate realEstate)
        {
            InitializeComponent();
            _realEstate = realEstate;
            realtyTypeCombobox.IsEnabled = false;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal latitude;
            decimal longitude;
            var latitudeSucceded = decimal.TryParse(latitudeTextbox.Text, out latitude);
            var longitudeSucceded = decimal.TryParse(longitudeTextbox.Text, out longitude);
            if (_realEstate == null)
            {
                if(realtyTypeCombobox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тип недвижимости.");
                    return;
                }
                var type = (RealEstateType)realtyTypeCombobox.SelectedItem;
                
                RealEstate realEstate = new RealEstate
                {
                    City = cityTextbox.Text,
                    Street = streetTextbox.Text,
                    HouseNumber = houseTextbox.Text,
                    FlatNumber = flatTextbox.Text
                };

                if (latitudeSucceded)
                    realEstate.Latitude = latitude;

                if (longitudeSucceded)
                    realEstate.Longitude = longitude;

                realEstate.Discriminator = Enum.GetName(typeof(RealEstateType), type);
                RealEstateRepository.Create(realEstate);

                switch (type)
                {
                    case RealEstateType.Flat:
                        MainFrameHolder.MainFrame.Navigate(new UpdateFlatPage(realEstate));
                        break;
                    case RealEstateType.House:
                        MainFrameHolder.MainFrame.Navigate(new UpdateHousePage(realEstate));
                        break;
                    case RealEstateType.Ground:
                        MainFrameHolder.MainFrame.Navigate(new UpdateGroundPage(realEstate));
                        break;
                }
                return;
            }

            _realEstate.City = cityTextbox.Text;
            _realEstate.Street = streetTextbox.Text;
            _realEstate.HouseNumber = houseTextbox.Text;
            _realEstate.FlatNumber = flatTextbox.Text;

            if (latitudeSucceded)
                _realEstate.Latitude = latitude;

            if (longitudeSucceded)
                _realEstate.Latitude = longitude;

            RealEstateRepository.Update(_realEstate);
            MessageBox.Show("Операция успешно завершена.");
            MainFrameHolder.MainFrame.Navigate(new RealEstatePage());
        }

        private void LoadCombobox()
        {
            realtyTypeCombobox.ItemsSource = Enum.GetValues(typeof(RealEstateType));
        }
    }
}
