using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cour.Pav.Model;

public partial class Buyer : BaseClass
{
    [Key]
    public int BuyerId { get; set; }

    private string buyerName;
    public string BuyerName
    {
        get { return buyerName; } 
        set 
        {  
            buyerName = value;  
            OnPropertyChanged(nameof(BuyerName));
        }
    }

    private string? passwordBuyer;
    public string? PasswordBuyer
    {
        get { return passwordBuyer; }
        set
        {
            passwordBuyer = value; OnPropertyChanged(nameof(PasswordBuyer));
        }
    }

    private string? loginBuyer;
    public string? LoginBuyer
    {
        get { return loginBuyer; }
        set
        {
            loginBuyer = value; OnPropertyChanged(nameof(LoginBuyer));
        }
    }

    [NotMapped]
    public int ItemCount
    {
        get { return Items.Count; }
    }


    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
