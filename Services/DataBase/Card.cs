//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Card
    {
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public Nullable<int> Wallet_WalletId { get; set; }
    
        public virtual Wallet Wallet { get; set; }
    }
}
