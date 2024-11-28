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
    class LocationPageViewModel : BaseClass
    {
        private AucitonContext db = new AucitonContext();

        private ObservableCollection<Auction> auctionList;
        public ObservableCollection<Auction> AuctionList
        {
            get { return auctionList; }
            set
            {
                auctionList = value;
                OnPropertyChanged(nameof(AuctionList));
            }
        }
        public LocationPageViewModel()
        {
            db.Auctions.Load();
            AuctionList = db.Auctions.Local.ToObservableCollection();

        }

        private string selectedLocation;
        public string SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }




        //Что бы не забыл:
        // Фильтруем по SelectedLocation и выводим список аукционов у которых совпадают SelectedLocation,

        private RelayCommand? filterByLocationCommand;
        public RelayCommand FilterByLocationCommand
        {
            get
            {
                return filterByLocationCommand ??
                    (filterByLocationCommand = new RelayCommand(obj =>
                    {
                        if (!string.IsNullOrEmpty(SelectedLocation))
                        {
                            var filteredAuctions = db.Auctions
                                .Where(a => a.Location == SelectedLocation)
                                .ToList();
                            AuctionList = new ObservableCollection<Auction>(filteredAuctions);
                        }
                        else
                        {
                            db.Auctions.Load();
                            AuctionList = db.Auctions.Local.ToObservableCollection();
                        }
                    }));
            }
        }

      

       
    }
}
