using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Repositories;
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

namespace RealEstateAgency.Views
{
    public partial class UpdateHousePage : Page
    {
        private readonly RealEstate _realEstate;

        public UpdateHousePage(RealEstate realEstate)
        {
            InitializeComponent();
            _realEstate = realEstate;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int roomsQuantity;
            int floorsQuantity;
            decimal square;
            int.TryParse(roomsQuantityTextbox.Text, out roomsQuantity);
            int.TryParse(floorsQuantityTextbox.Text, out floorsQuantity);
            decimal.TryParse(squareTextbox.Text, out square);
            _realEstate.RoomsQuantity = roomsQuantity;
            _realEstate.Floor = floorsQuantity;
            _realEstate.Square = square;
            RealEstateRepository.Update(_realEstate);
            MessageBox.Show("Действие успешно выполнено.");
            MainFrameHolder.MainFrame.Navigate(new RealEstatePage());
        }
    }
}
