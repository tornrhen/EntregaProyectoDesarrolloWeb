//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoConsula.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resultado
    {
        public int IdT_Resultado { get; set; }
        public int IdF_Respuesta { get; set; }
        public int IdF_Prueba { get; set; }
        public int Intento { get; set; }
    
        public virtual Prueba Prueba { get; set; }
        public virtual Respuesta Respuesta { get; set; }
    }
}
