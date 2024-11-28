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
    /// Логика взаимодействия для AddEditItem.xaml
    /// </summary>
    public partial class AddEditItem : Window
    {
        private AucitonContext AucitonContext = new AucitonContext();
        public Item Item { get; set; }
        public List<Auction> AuctionList { get; set; }
        public List<Buyer> BuyerList { get; set; }
        public List<Seller> SellerList { get; set; }
        public AddEditItem(Item item)
        {
            InitializeComponent();
            Item = item;
            DataContext = Item;
            ComboBoxAuctionId.ItemsSource = AucitonContext.Auctions.ToList();
            ComboBoxBuyerId.ItemsSource = AucitonContext.Buyers.ToList();
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
