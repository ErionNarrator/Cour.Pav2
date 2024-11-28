using Cour.Pav.Model;
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
    /// Логика взаимодействия для EditSellerItemPage.xaml
    /// </summary>
    public partial class EditSellerItemPage : Window
    {
        private AucitonContext AucitonContext = new AucitonContext();
        public Item Item { get; set; }
        public List<Auction> AuctionList { get; set; }
        public List<Seller> SellerList { get; set; }
        public EditSellerItemPage(Item item)
        {
            InitializeComponent();
            Item = item;
            DataContext = Item;
            ComboBoxAuctionId.ItemsSource = AucitonContext.Auctions.ToList();
            ComboBoxSellerId.ItemsSource = AucitonContext.Sellers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult=false;
        }
    }
}
