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
    class ItemPageBuyerModelView : BaseClass
    {
        AucitonContext db = new AucitonContext();
        private ObservableCollection<Item> buyerList;
        public ObservableCollection<Item> BuyerList
        {
            get
            {
                return buyerList;
            }
            set
            {
                buyerList = value;
                OnPropertyChanged(nameof(BuyerList));
            }
        }

        private Item? selectBuyer;
        public Item? SelectBuyer
        {
            get
            {
                return selectBuyer;
            }
            set
            {
                selectBuyer = value; OnPropertyChanged(nameof(SelectBuyer));
            }
        }

        public ItemPageBuyer window;

        public ItemPageBuyerModelView()
        {
            db.Items.Load();
            BuyerList = db.Items.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        EditItemPageBuyer window = new EditItemPageBuyer(new Item());
                        if (window.ShowDialog() == true)
                        {
                            Item item = window.Item;
                            db.Items.Add(item);
                            db.SaveChanges();
                        }
                    }));
            }
        }

        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand(obj =>
                    {
                        Item? item= obj as Item;
                        if (item == null) return;
                        EditItemPageBuyer window = new EditItemPageBuyer(item!);
                        if (window.ShowDialog() == true)
                        {
                            item.ItemId = window.Item.ItemId;
                            item.LotNumber = window.Item.LotNumber;
                            item.AuctionId = window.Item.AuctionId;
                            item.SellerId = window.Item.SellerId;
                            item.BuyerId = window.Item.BuyerId;
                            item.Price = window.Item.Price;
                            item.Description = window.Item.Description;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }));
            }
        }
    }
}
