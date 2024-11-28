using Cour.Pav.Model;
using Cour.Pav.View;
using System.Windows;
using System.Windows.Documents;

namespace Cour.Pav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new AuctionPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ItemPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new InfoPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new FilterDayAuctioPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new AuctionRevenuePage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate (new SoldPage());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new BuyerDatePage());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new LocationPage());
        }

    

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new BuyerItemPage());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new NumberPurchasesPage());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new SellerPage());
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new BuyerPage());
        }
    }
}