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
    
    public partial class Wallet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wallet()
        {
            this.Bills = new HashSet<Bill>();
            this.Cards = new HashSet<Card>();
        }
    
        public int WalletId { get; set; }
        public string Name { get; set; }
        public int Regular_UserId { get; set; }
        public int Valute_ValuteId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Card> Cards { get; set; }
        public virtual Regular Regular { get; set; }
        public virtual Valute Valute { get; set; }
    }
}
