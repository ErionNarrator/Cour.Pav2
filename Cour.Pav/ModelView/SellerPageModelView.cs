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
    class SellerPageModelView : BaseClass
    {
        AucitonContext db = new AucitonContext();
        private ObservableCollection<Item> sellerList;
        public ObservableCollection<Item> SellerList
        {
            get
            {
                return sellerList;
            }
            set
            {
                sellerList = value;
                OnPropertyChanged(nameof(sellerList));
            }
        }

        private Seller? selectSeller;
        public Seller? SelectSeller
        {
            get
            {
                return selectSeller;
            }

            set
            {
                selectSeller = value;
                OnPropertyChanged(nameof(selectSeller));
            }

        }

        public SellerItemPage window;
        public SellerPageModelView()
        {
            
            db.Items.Load();
            SellerList = db.Items.Local.ToObservableCollection();
        }



        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        EditSellerItemPage window = new EditSellerItemPage(new Item());
                        if (window.ShowDialog() == true)
                        {
                            Item item= window.Item;
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
                        Item? item = obj as Item;
                        if(item == null) return;
                        EditSellerItemPage window = new EditSellerItemPage(item!);
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
                    }
                        ));
            }
        }
    }
}
