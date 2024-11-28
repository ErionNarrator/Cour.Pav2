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
    internal class SellerPageViewModel : BaseClass
    {
        AucitonContext db = new AucitonContext();
        private ObservableCollection<Seller> sellerList;
        public ObservableCollection<Seller> SellerList
        {
            get
            {
                return sellerList;
            }
            set
            {
                sellerList = value;
                OnPropertyChanged(nameof(SellerList));
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
                selectSeller = value; OnPropertyChanged(nameof(SelectSeller));
            }
        }

        public SellerPage window;

        public SellerPageViewModel(SellerPage w)
        {
            this.window = w;
            db.Sellers.Load();
            SellerList = db.Sellers.Local.ToObservableCollection();
        }
        private RelayCommand? addCommands;
        public RelayCommand AddCommands
        {
            get
            {
                return addCommands ??
                    (addCommands = new RelayCommand(obj =>
                    {
                        AddEditSeller window = new AddEditSeller(new Seller());
                        if (window.ShowDialog() == true)
                        {
                            Seller seller = window.Seller;
                            db.Sellers.Add(seller);
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
                        Seller? seller = obj as Seller;
                        if (seller == null) return;
                        AddEditSeller window = new AddEditSeller(seller!);
                        if (window.ShowDialog() == true)
                        {
                            seller.SellerId = window.Seller.SellerId;
                            seller.SellerName = window.Seller.SellerName;
                            seller.LoginSeller = window.Seller.LoginSeller;
                            seller.PasswordSeller = window.Seller.PasswordSeller;
                            db.Entry(seller).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    ));
            }
        }

        private RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(selectSeller =>
                    {
                        Seller? seller = selectSeller as Seller;
                        if (seller == null) return;
                        db.Sellers.Remove(seller);
                        db.SaveChanges();
                    }
                    ));
            }
        }

    }
}
