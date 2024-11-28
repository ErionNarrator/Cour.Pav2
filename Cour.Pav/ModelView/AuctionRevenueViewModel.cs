using Cour.Pav.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cour.Pav.ModelView
{
    class AuctionRevenueViewModel : BaseClass
    {
        private AucitonContext db = new AucitonContext();

        private ObservableCollection<Auction> _auctionList;
        public ObservableCollection<Auction> AuctionList
        {
            get { return _auctionList; }
            set
            {
                _auctionList = value;
                OnPropertyChanged(nameof(AuctionList));
            }
        }

        public AuctionRevenueViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            var auctions = db.Auctions
                .Include(a => a.Items)
                .ToList()
                .Select(a => new
                {
                    Auction = a,
                    TotalRevenue = a.TotalRevenue
                })
                .OrderByDescending(a => a.TotalRevenue)
                .ToList();

            AuctionList = new ObservableCollection<Auction>(
                auctions.Select(a => a.Auction));
        }

    }
}
