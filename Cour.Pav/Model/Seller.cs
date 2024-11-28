using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cour.Pav.Model;

public partial class Seller : BaseClass
{
    [Key]
    public int SellerId { get; set; }

    private string sellerName;
    public string SellerName
    {
        get { return sellerName; } 
        set
        {
            sellerName = value;
            OnPropertyChanged(nameof(SellerName));
        }
    }

    private string? passwordSeller;
    public string? PasswordSeller
    {
        get { return passwordSeller; }
        set
        {
            passwordSeller = value; OnPropertyChanged(nameof(PasswordSeller));
        }
    }


    private string? loginSeller;
    public string? LoginSeller
    {
        get { return loginSeller; }
        set
        {
            loginSeller = value;
            OnPropertyChanged(nameof(LoginSeller));
        }
    }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
