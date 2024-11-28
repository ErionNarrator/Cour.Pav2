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
    class AuctionPageViewModel : BaseClass
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

        public AuctionPageViewModel(AuctionPage w)
        {
            this.window = w;
            db.Auctions.Load();
            AuctionList = db.Auctions.Local.ToObservableCollection();
            UpdateCards();
        }

    

        public void UpdateCards()
        {
            //window.AuctionContainer.Children.Clear();
            //foreach (Auction auction in auctionList)
            //{
            //    AddEditAuction suc = new AddEditAuction(auction);
            //    window.AuctionContainer.Children.Add(suc);
            //}
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditAuction window = new AddEditAuction(new Auction());
                        if (window.ShowDialog() == true)
                        {
                            Auction auction = window.Auction;
                            db.Auctions.Local.Add(auction);
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
                        Auction? auction = obj as Auction;
                        if (auction == null) return;
                        AddEditAuction window = new AddEditAuction(auction!);
                        if (window.ShowDialog() == true)
                        {
                            auction.AuctionId = window.Auction.AuctionId;
                            auction.AuctionName = window.Auction.AuctionName;   
                            auction.Date = window.Auction.Date;
                            auction.Location = window.Auction.Location;
                            auction.Specifications = window.Auction.Specifications; 
                            db.Entry(auction).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    ));
            }
        }


        RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        Auction? auction = selectAuction as Auction;
                        if (auction == null) return;
                        db.Auctions.Remove(auction);
                        db.SaveChanges();
                    }
                    ));
            }
        }


        




    }
}
