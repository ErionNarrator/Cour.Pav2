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
    internal class ItemPageViewModel : BaseClass
    {
        AucitonContext db = new AucitonContext();
        private ObservableCollection<Item> itemList;
        public ObservableCollection<Item> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged(nameof(itemList));
            }
        }

        public ItemPage window;

        private Item? selectItem;
        public Item? SelectItem
        {
            get
            {
                return selectItem;
            }
            set
            {
                selectItem = value;
                OnPropertyChanged(nameof(selectItem));
            }
        }

        public ItemPageViewModel()
        {
            db.Items.Load();
            ItemList = db.Items.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? 
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditItem window = new AddEditItem(new Item());
                        if (window.ShowDialog() == true)
                        {
                            Item item = window.Item;
                            db.Items.Local.Add(item);
                            db.SaveChanges();
                        }
                            
                      
                        
                    }
                    ));
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
                        if (item == null) return;
                        AddEditItem window = new AddEditItem(item!);
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

        RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(selectedItem =>
                    {
                        // получаем выделенный объект
                        Item? item = selectItem as Item;
                        if (item == null) return;
                        db.Items.Remove(item);
                        db.SaveChanges();
                    }));
            }
        }
    }
}
