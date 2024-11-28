using Cour.Pav.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cour.Pav.ModelView
{
    class BuyerDatePageViewModel : BaseClass
    {
        private AucitonContext db = new AucitonContext();

        private DateTime? startDate;
        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime? endDate;
        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private ObservableCollection<Buyer> filteredBuyers;
        public ObservableCollection<Buyer> FilteredBuyers
        {
            get { return filteredBuyers; }
            set
            {
                filteredBuyers = value;
                OnPropertyChanged(nameof(FilteredBuyers));
            }
        }

        private RelayCommand? filterBuyersCommand;
        public RelayCommand FilterBuyersCommand
        {
            get
            {
                return filterBuyersCommand ??
                    (filterBuyersCommand = new RelayCommand(obj =>
                    {
                        if (StartDate.HasValue && EndDate.HasValue)
                        {
                            var buyers = db.Items
                                .Where(i => i.Auction.Date >= StartDate.Value && i.Auction.Date <= EndDate.Value && i.BuyerId.HasValue)
                                .Select(i => i.Buyer)
                                .Distinct()
                                .ToList();

                            FilteredBuyers = new ObservableCollection<Buyer>(buyers);
                        }
                        else
                        {
                            FilteredBuyers = new ObservableCollection<Buyer>();
                        }
                    }));
            }
        }
    }
}
