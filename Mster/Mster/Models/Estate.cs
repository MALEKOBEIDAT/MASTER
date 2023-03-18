//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estate()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int EstateId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string UserId { get; set; }
        public Nullable<double> EstatePrice { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string Image6 { get; set; }
        public string Image7 { get; set; }
        public Nullable<double> EstateSize { get; set; }
        public string EstateLocation { get; set; }
        public Nullable<int> EstateStatus { get; set; }
        public Nullable<int> RoomNum { get; set; }
        public Nullable<int> BathRoomNum { get; set; }
        public Nullable<int> BalconyNum { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}