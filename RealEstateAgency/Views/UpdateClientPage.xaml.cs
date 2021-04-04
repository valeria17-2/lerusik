using RealEstateAgency.Database;
using RealEstateAgency.FrameHolders;
using RealEstateAgency.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class UpdateClientPage : Page
    {
        private readonly Client _client;

        public UpdateClientPage()
        {
            InitializeComponent();
        }

        public UpdateClientPage(Client client)
        {
            InitializeComponent();
            _client = client;
            LoadClient();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextbox.Text) && string.IsNullOrEmpty(phoneTextbox.Text))
            {
                MessageBox.Show("Хотя бы одно поле должно быть заполнено: почта, номер телефона.");
                return;
            }

            if (_client == null)
            {
                Client client = new Client
                {
                    LastName = lastNameTextbox.Text,
                    FirstName = firstNameTextbox.Text,
                    Patronymic = patronymicTextbox.Text,
                    PhoneNumber = phoneTextbox.Text,
                    Email = emailTextbox.Text
                };
                ClientRepository.Create(client);
            }
            else
            {
                _client.LastName = string.IsNullOrWhiteSpace(lastNameTextbox.Text) ? null : lastNameTextbox.Text;
                _client.FirstName = string.IsNullOrWhiteSpace(firstNameTextbox.Text) ? null : firstNameTextbox.Text;
                _client.Patronymic = string.IsNullOrWhiteSpace(patronymicTextbox.Text) ? null : patronymicTextbox.Text;
                _client.PhoneNumber = string.IsNullOrWhiteSpace(phoneTextbox.Text) ? null : phoneTextbox.Text;
                _client.Email = string.IsNullOrWhiteSpace(emailTextbox.Text) ? null : emailTextbox.Text;
                ClientRepository.Update(_client);
            }

            MessageBox.Show("Действие успешно совершено.");
            MainFrameHolder.MainFrame.Navigate(new ClientPage());
        }

        private void LoadClient()
        {
            lastNameTextbox.Text = _client.LastName;
            firstNameTextbox.Text = _client.FirstName;
            patronymicTextbox.Text = _client.Patronymic;
            phoneTextbox.Text = _client.PhoneNumber;
            emailTextbox.Text = _client.Email;
        }
    }
}
