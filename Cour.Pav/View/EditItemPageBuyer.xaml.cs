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
    /// Логика взаимодействия для EditItemPageBuyer.xaml
    /// </summary>
    public partial class EditItemPageBuyer : Window
    {
        private AucitonContext AucitonContext = new AucitonContext();
        public Item Item { get; set; }
        public List<Buyer> BuyerList { get; set; }
        public EditItemPageBuyer(Item item)
        {
            InitializeComponent();
            Item = item;
            DataContext = Item;
            ComboBoxBuyerId.ItemsSource = AucitonContext.Buyers.ToList();
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
