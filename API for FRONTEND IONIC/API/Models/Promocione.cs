//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promocione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promocione()
        {
            this.ServiciosEnPromocions = new HashSet<ServiciosEnPromocion>();
        }
    
        public int IDPromocion { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public Nullable<System.DateTime> FechaExpiracion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiciosEnPromocion> ServiciosEnPromocions { get; set; }
    }
}
