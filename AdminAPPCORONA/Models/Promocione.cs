//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminAPPCORONA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Promocione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promocione()
        {
            this.ServiciosEnPromocions = new HashSet<ServiciosEnPromocion>();
        }
        [Display(Name = "Promoción")]
        public int IDPromocion { get; set; }
        [Display(Name = "Promoción")]
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        [Display(Name = "Fecha de Expiración")]
        public Nullable<System.DateTime> FechaExpiracion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiciosEnPromocion> ServiciosEnPromocions { get; set; }
    }
}