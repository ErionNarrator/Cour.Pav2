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
    /// Логика взаимодействия для AddEditSeller.xaml
    /// </summary>
    public partial class AddEditSeller : Window
    {
        public Seller Seller { get; set; }
        public AddEditSeller(Seller seller)
        {
            InitializeComponent();
            Seller = seller;
            DataContext = Seller;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
