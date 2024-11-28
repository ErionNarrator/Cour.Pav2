using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cour.Pav.Model;

public partial class Item : BaseClass
{
    [Key]
    public int ItemId { get; set; }

    private int? auctionId;
    public int? AuctionId
    {
        get { return auctionId; } 
        set
        {
            auctionId = value;
            OnPropertyChanged(nameof(AuctionId));

        }
    }

    private int? lotNumber;
    public int? LotNumber
    {
        get { return lotNumber; }
        set
        {
            lotNumber = value; OnPropertyChanged(nameof(LotNumber));
        }
    }

    private int? sellerId;
    public int? SellerId
    {
        get { return sellerId; }
        set
        {
            sellerId = value; OnPropertyChanged(nameof(SellerId));
        }
    }

    private string? price;
    public string? Price
    {
        get { return price; }
        set
        {
            price = value; OnPropertyChanged(nameof(Price));
        }
    }

    private string? description;
    public string? Description
    {
        get { return description; }
        set
        {
            description = value; OnPropertyChanged(nameof(Description));
        }
    }

    private int? buyerId;
    public int? BuyerId
    {
        get { return buyerId; }
        set
        {
            buyerId = value; OnPropertyChanged( nameof(BuyerId));   
        }
    }



    public virtual Auction? Auction { get; set; }

    public virtual Buyer? Buyer { get; set; }

    public virtual Seller? Seller { get; set; }
}
