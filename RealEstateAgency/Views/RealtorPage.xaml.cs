using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Models;
using RealEstateAgency.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class RealtorPage : Page
    {
        private string EmptySearchTextBox { get; set; }

        public RealtorPage()
        {
            InitializeComponent();
            EmptySearchTextBox = "ФИО...";
            searchTextbox.Text = EmptySearchTextBox;
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrameHolder.MainFrame.Navigate(new UpdateRealtorPage());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var realtor = realtorsGrid.SelectedItem as Realtor;
            if (realtor == null)
            {
                MessageBox.Show("Выберите строкую");
                return;
            }
            MainFrameHolder.MainFrame.Navigate(new UpdateRealtorPage(realtor));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var realtor = realtorsGrid.SelectedItem as Realtor;
            if (realtor == null)
            {
                MessageBox.Show("Выберите строкую");
                return;
            }
            RealtorRepository.Delete(realtor);
            LoadData();
        }

        private void LoadData()
        {
            if (string.IsNullOrWhiteSpace(searchTextbox.Text) || searchTextbox.Text == EmptySearchTextBox)
            {
                realtorsGrid.ItemsSource = RealtorRepository.GetList();
                return;
            }
            realtorsGrid.ItemsSource = RealtorRepository.GetList(searchTextbox.Text);
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
