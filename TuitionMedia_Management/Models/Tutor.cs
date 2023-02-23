//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TuitionMedia_Management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tutor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tutor()
        {
            this.Qualifications = new HashSet<Qualification>();
        }
    
        public int Tutorid { get; set; }
        public string Tutorname { get; set; }
        public System.DateTime JoinDate { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public Nullable<bool> Available { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qualification> Qualifications { get; set; }
    }
}