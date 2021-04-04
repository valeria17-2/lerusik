using RealEstateAgency.FrameHolders;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new ClientPage());
        }

        private void RealtorsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new RealtorPage());
        }

        private void RealEstateButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new RealEstatePage());
        }
    }
}
