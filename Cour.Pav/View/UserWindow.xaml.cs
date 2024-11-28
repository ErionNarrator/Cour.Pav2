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
using System.Windows.Shapes;

namespace Cour.Pav.View
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
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
            FrameContainer.Navigate(new SoldPage());
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new SellerItemPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameContainer.Navigate(new ItemPageBuyer());
        }
    }
}
