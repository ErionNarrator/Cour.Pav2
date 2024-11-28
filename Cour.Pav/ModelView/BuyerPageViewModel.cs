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
    internal class BuyerPageViewModel : BaseClass
    {
        AucitonContext db = new AucitonContext();
        private ObservableCollection<Buyer> buyerList;
        public ObservableCollection<Buyer> BuyerList
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

        private Buyer? selectBuyer;
        public Buyer? SelectBuyer
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

        public BuyerPage window;

        public BuyerPageViewModel(BuyerPage w)
        {
            this.window = w;
            db.Buyers.Load();
            BuyerList = db.Buyers.Local.ToObservableCollection();
        }

        private RelayCommand? addCommands;
        public RelayCommand AddCommands
        {
            get
            {
                return addCommands ??
                    (addCommands = new RelayCommand(obj =>
                    {
                        AddEditBuyer window = new AddEditBuyer(new Buyer());
                        if (window.ShowDialog() == true)
                        {
                            Buyer buyer = window.Buyer;
                            db.Buyers.Add(buyer);
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
                        Buyer? buyer = obj as Buyer;
                        if (buyer == null) return;
                        AddEditBuyer window = new AddEditBuyer(buyer!);
                        if (window.ShowDialog() == true)
                        {
                            buyer.BuyerId = window.Buyer.BuyerId;
                            buyer.BuyerName = window.Buyer.BuyerName;
                            buyer.LoginBuyer = window.Buyer.LoginBuyer;
                            buyer.PasswordBuyer = window.Buyer.PasswordBuyer;
                            db.Entry(buyer).State=EntityState.Modified;
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
                    (deleteCommand = new RelayCommand(selectBuyer =>
                    {
                        Buyer? buyer= selectBuyer as Buyer;
                        if (buyer == null) return;
                        db.Buyers.Remove(buyer);
                        db.SaveChanges();
                    }
                    ));
            }
        }

    }
}
