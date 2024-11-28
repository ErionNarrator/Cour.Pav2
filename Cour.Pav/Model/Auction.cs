using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cour.Pav.Model;

public partial class Auction : BaseClass
{
    [Key]
    public int AuctionId { get; set; }

    [Required]

    private string? auctionName;
    public string AuctionName
    {
        get { return auctionName; }
        set
        {
            auctionName = value;
            OnPropertyChanged(nameof(AuctionName));
        }
    }

    private DateTime? date;
    public DateTime? Date
    {
        get { return date; }
        set
        {
            date = value; OnPropertyChanged(nameof(Date));
        }
    }

    private string location;
    public string Location
    {
        get { return location; }
        set
        {
            location = value; OnPropertyChanged(nameof(Location));
        }
    }

    private string? specifications;
    public string? Specifications
    {
        get { return specifications; }
        set
        {
            specifications = value; OnPropertyChanged(nameof(Specifications));
        }
    }

    //Таблица для подщета дохода аукциона, вывод даных идет AuctionRevenuePage, decimal для данных прибыли
    [NotMapped]
    public decimal TotalRevenue
    {
        get
        {
            return Items
                .Where(i => i.BuyerId.HasValue) // Учитываем только проданные предметы
                .Sum(i => decimal.TryParse(i.Price, out var price) ? price : 0);
        }
    }
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
