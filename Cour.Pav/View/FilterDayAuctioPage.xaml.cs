using Cour.Pav.Model;
using Cour.Pav.ModelView;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cour.Pav.View
{
    /// <summary>
    /// Логика взаимодействия для FilterDayAuctioPage.xaml
    /// </summary>
    public partial class FilterDayAuctioPage : Page
    {
  
        public List<Auction> AuctionList { get; set; }
        public FilterDayAuctioPage()
        {
            InitializeComponent();
            DataContext = new FilterDayAuctioPageViewModel();
            
        }

     
    }
}
