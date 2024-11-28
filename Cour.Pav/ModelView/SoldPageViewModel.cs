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
    internal class SoldPageViewModel : BaseClass
    {
        AucitonContext db = new AucitonContext();
        private ObservableCollection<Item> itemList;
        public ObservableCollection<Item> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged(nameof(ItemList));
            }
        }





        public ItemPage window;

        private Item? selectItem;
        public Item? SelectItem
        {
            get { return selectItem; }
            set
            {
                selectItem = value; OnPropertyChanged(nameof(selectItem));
            }
        }

        public SoldPageViewModel()
        {
            db.Items.Load();
            ItemList = db.Items.Local.ToObservableCollection();
        }

        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

            }
        }


        private DateTime? selectedStartDate;
        public DateTime? SelectedStartDate
        {
            get => selectedStartDate;
            set
            {
                selectedStartDate = value;
                OnPropertyChanged(nameof(SelectedStartDate));
            }
        }

        private DateTime? selectedEndDate;
        public DateTime? SelectedEndDate
        {
            get => selectedEndDate;
            set
            {
                selectedEndDate = value;
                OnPropertyChanged(nameof(SelectedEndDate));
            }
        }

        private RelayCommand? filterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return filterCommand ??
                    (filterCommand = new RelayCommand(obj =>
                    {
                        if (SelectedStartDate == null || SelectedEndDate == null)
                        {
                            return;
                        }

                        var filteredItems = db.Items
                            .Where(i => i.BuyerId.HasValue &&
                                        i.Auction.Date >= SelectedStartDate.Value &&
                                        i.Auction.Date <= SelectedEndDate.Value)
                            .ToList();

                        ItemList = new ObservableCollection<Item>(filteredItems);
                    }));
            }
        }
    }
}
