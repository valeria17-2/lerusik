using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class ClientPage : Page
    {
        private string EmptySearchTextBox { get; set; }

        public ClientPage()
        {
            InitializeComponent();
            EmptySearchTextBox = "ФИО...";
            searchTextbox.Text = EmptySearchTextBox;
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new UpdateClientPage());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var client = clientsGrid.SelectedItem as Client;
            if(client == null)
            {
                MessageBox.Show("Выберите строкую");
                return;
            }
            MainFrameHolder.MainFrame.Navigate(new UpdateClientPage(client));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var client = clientsGrid.SelectedItem as Client;
            if(client == null)
            {
                MessageBox.Show("Выберите строкую");
                return;
            }
            ClientRepository.Delete(client);
            LoadData();
        }

        private void LoadData()
        {
            if(string.IsNullOrWhiteSpace(searchTextbox.Text) || searchTextbox.Text == EmptySearchTextBox)
            {
                clientsGrid.ItemsSource = ClientRepository.GetList();
                return;
            }
            clientsGrid.ItemsSource = ClientRepository.GetList(searchTextbox.Text);
        }

        private void SearchTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void SearchTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchTextbox.Text == EmptySearchTextBox)
                searchTextbox.Text = string.Empty;
        }

        private void SearchTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchTextbox.Text == string.Empty || string.IsNullOrWhiteSpace(searchTextbox.Text))
                searchTextbox.Text = EmptySearchTextBox;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            searchTextbox.Text = EmptySearchTextBox;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new MenuPage());
        }
    }
}
