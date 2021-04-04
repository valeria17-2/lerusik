using RealEstateAgency.FrameHolders;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrameHolder.MainFrame = mainFrame;
        }

        public void Navigate(Page page)
        {
            MainFrameHolder.MainFrame.Navigate(page);
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
