﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Datos
{
    public class LugarCE
    {
        
        [Required]
        [Display]
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Usuario { get; set; }
        [Required]
        public string Categoria { get; set; }
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display (Name = "Fecha de Inicio")]
        public System.DateTime FechaInicio { get; set; }
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Fin")]
        public Nullable<System.DateTime> FechaFin { get; set; }
        [Required]
        [Display]
        public Nullable<int> Capacidad { get; set; }
        [Required]
        [Display]
        public Nullable<int> Asistentes { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
    }
    [MetadataType(typeof(LugarCE))]
    public partial class Lugar
    {   

    }
}