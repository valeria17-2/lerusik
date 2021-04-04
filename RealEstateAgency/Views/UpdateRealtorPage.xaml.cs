using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class UpdateRealtorPage : Page
    {
        private readonly Realtor _realtor;

        public UpdateRealtorPage()
        {
            InitializeComponent();
        }

        public UpdateRealtorPage(Realtor realtor)
        {
            InitializeComponent();
            _realtor = realtor;
            LoadRealtor();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextbox.Text) || string.IsNullOrEmpty(lastNameTextbox.Text)
                || string.IsNullOrEmpty(patronymicTextbox.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены: Фамилия, Имя, Отчество.");
                return;
            }

            if (_realtor == null)
            {
                Realtor realtor = new Realtor
                {
                    LastName = lastNameTextbox.Text,
                    FirstName = firstNameTextbox.Text,
                    Patronymic = patronymicTextbox.Text,
                    CommissionShare = string.IsNullOrWhiteSpace(commissionTextbox.Text) ? 0 : Convert.ToInt32(commissionTextbox.Text)
                };
                RealtorRepository.Create(realtor);
            }
            else
            {
                _realtor.LastName = string.IsNullOrWhiteSpace(lastNameTextbox.Text) ? null : lastNameTextbox.Text;
                _realtor.FirstName = string.IsNullOrWhiteSpace(firstNameTextbox.Text) ? null : firstNameTextbox.Text;
                _realtor.Patronymic = string.IsNullOrWhiteSpace(patronymicTextbox.Text) ? null : patronymicTextbox.Text;
                _realtor.CommissionShare = string.IsNullOrWhiteSpace(commissionTextbox.Text) ? 0 : int.Parse(commissionTextbox.Text);
                RealtorRepository.Update(_realtor);
            }

            MessageBox.Show("Действие успешно совершено.");
            MainFrameHolder.MainFrame.Navigate(new RealtorPage());
        }

        private void LoadRealtor()
        {
            lastNameTextbox.Text = _realtor.LastName;
            firstNameTextbox.Text = _realtor.FirstName;
            patronymicTextbox.Text = _realtor.Patronymic;
            commissionTextbox.Text = _realtor.CommissionShare.ToString();
        }
    }
}
