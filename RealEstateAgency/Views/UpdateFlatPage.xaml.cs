using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class UpdateFlatPage : Page
    {
        private readonly RealEstate _realEstate;

        public UpdateFlatPage(RealEstate realEstate)
        {
            InitializeComponent();
            _realEstate = realEstate;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int roomsQuantity;
            int floor;
            decimal square;
            int.TryParse(roomsQuntityTextbox.Text, out roomsQuantity);
            int.TryParse(floorTextbox.Text, out floor);
            decimal.TryParse(squareTextbox.Text, out square);
            _realEstate.RoomsQuantity = roomsQuantity;
            _realEstate.Floor = floor;
            _realEstate.Square = square;
            RealEstateRepository.Update(_realEstate);
            MessageBox.Show("Действие успешно выполнено.");
            MainFrameHolder.MainFrame.Navigate(new RealEstatePage());
        }
    }
}
