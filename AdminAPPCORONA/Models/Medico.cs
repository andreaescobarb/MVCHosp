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

    public partial class Medico
    {
        public int IDMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
        public string Sabado { get; set; }
        public string Titulos { get; set; }

        [Display(Name = "Especialidad")]
        public int IDEspecialidad { get; set; }

        public virtual Especialidade Especialidade { get; set; }
    }
}