using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Models;
using System.Windows;

namespace RealEstateAgency.Views
{
    public partial class ChooseChangeTypeWindow : Window
    {
        private readonly RealEstate _realEstate;

        public ChooseChangeTypeWindow(RealEstate realEstate)
        {
            InitializeComponent();
            _realEstate = realEstate;
        }

        private void LocationButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new LocationUpdatePage(_realEstate));
            DialogResult = true;
        }

        private void CharacteristicButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_realEstate.Discriminator)
            {
                case nameof(RealEstateType.Flat):
                    MainFrameHolder.MainFrame.Navigate(new UpdateFlatPage(_realEstate));
                    break;
                case nameof(RealEstateType.Ground):
                    MainFrameHolder.MainFrame.Navigate(new UpdateGroundPage(_realEstate));
                    break;
                case nameof(RealEstateType.House):
                    MainFrameHolder.MainFrame.Navigate(new UpdateHousePage(_realEstate));
                    break;
            }
            DialogResult = true;
        }
    }
}
