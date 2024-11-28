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
    /// Логика взаимодействия для AddEditAuction.xaml
    /// </summary>
    public partial class AddEditAuction : Window
    {
        public Auction Auction { get; private set; }
        public AddEditAuction(Auction auction)
        {
            InitializeComponent();
            Auction = auction;
            DataContext = Auction;
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
