//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Lugar
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        [Required]
        public string Latitud { get; set; }
        [Required]
        public string Longitud { get; set; }
    }
}
