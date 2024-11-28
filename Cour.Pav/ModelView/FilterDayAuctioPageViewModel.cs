using Cour.Pav.Model;
using Cour.Pav.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cour.Pav.ModelView
{
    internal class FilterDayAuctioPageViewModel : BaseClass
    {
        AucitonContext db = new AucitonContext();
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

        public AuctionPage window;

        private Auction? selectAuction;
        public Auction? SelectAuction
        {
            get { return selectAuction; }
            set
            {
                selectAuction = value; OnPropertyChanged(nameof(SelectAuction));

            }
        }

        public FilterDayAuctioPageViewModel()
        {
            db.Auctions.Load();
            AuctionList = db.Auctions.Local.ToObservableCollection();
        
        }

        //Поиск по интервалу дат, (От/До и сам фильтр для поиска), вывод идет в FilterDayAuctioPage и работает с DatePicker
        //НЕ повторяй своих ошибок и не делай фильтрацию через ComboBox

        private DateTime? _selectedStartDate;
        public DateTime? SelectedStartDate
        {
            get => _selectedStartDate;
            set
            {
                _selectedStartDate = value;
                OnPropertyChanged(nameof(SelectedStartDate));
            }
        }



        private DateTime? _selectedEndDate;
        public DateTime? SelectedEndDate
        {
            get => _selectedEndDate;
            set
            {
                _selectedEndDate = value;
                OnPropertyChanged(nameof(SelectedEndDate));
            }
        }


        private RelayCommand? _filterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return _filterCommand ??
                    (_filterCommand = new RelayCommand(obj =>
                    {
                        if (SelectedStartDate == null || SelectedEndDate == null)
                        {

                            return;
                        }

                        var filteredAuctions = db.Auctions
                            .Where(a => a.Date >= SelectedStartDate.Value && a.Date <= SelectedEndDate.Value)
                            .ToList();

                        AuctionList = new ObservableCollection<Auction>(filteredAuctions);
                    }));
            }
        }

    }
}
