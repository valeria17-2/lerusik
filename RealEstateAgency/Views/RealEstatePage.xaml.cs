using RealEstateAgency.Database;
using RealEstateAgency.Filters;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Models;
using RealEstateAgency.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class RealEstatePage : Page
    {
        private string EmptySearchTextBox { get; set; }

        private bool SearchTextboxHasValue { get => !string.IsNullOrWhiteSpace(searchTextbox.Text) && searchTextbox.Text != EmptySearchTextBox; }

        public RealEstatePage()
        {
            InitializeComponent();
            EmptySearchTextBox = "Адрес...";
            searchTextbox.Text = EmptySearchTextBox;
            LoadData();
            LoadCombobox();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new LocationUpdatePage());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var realEstate = realEstateGrid.SelectedItem as RealEstate;
            if (realEstate == null)
            {
                MessageBox.Show("Выберите строкую");
                return;
            }
            ChooseChangeTypeWindow window = new ChooseChangeTypeWindow(realEstate);
            window.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var realEstate = realEstateGrid.SelectedItem as RealEstate;
            if (realEstate == null)
            {
                MessageBox.Show("Выберите строкую");
                return;
            }

            RealEstateRepository.Delete(realEstate);
            LoadData();
        }

        private void LoadData()
        {
            if (SearchTextboxHasValue || realEstateCombobox.SelectedItem != null)
            {
                RealEstateFilter filter = new RealEstateFilter
                {
                    Address = SearchTextboxHasValue ? searchTextbox.Text : null
                };
                if (realEstateCombobox.SelectedItem != null)
                    filter.RealEstateType = (RealEstateType)realEstateCombobox.SelectedItem;
                realEstateGrid.ItemsSource = RealEstateRepository.GetList(filter);
                return;
            }
            realEstateGrid.ItemsSource = RealEstateRepository.GetList();
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
            realEstateCombobox.SelectedItem = null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new MenuPage());
        }

        private void RealEstateCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void LoadCombobox()
        {
            realEstateCombobox.ItemsSource = Enum.GetValues(typeof(RealEstateType));
        }
    }
}
