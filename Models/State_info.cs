//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class State_info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public State_info()
        {
            this.City_Info = new HashSet<City_Info>();
            this.Emp_Info = new HashSet<Emp_Info>();
        }
    
        public int State_Id { get; set; }
        public string State_Name { get; set; }
        public Nullable<int> Country_RefId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<City_Info> City_Info { get; set; }
        public virtual Country_Info Country_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_Info> Emp_Info { get; set; }
    }
}
