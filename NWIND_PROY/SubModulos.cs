//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NWIND_PROY
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubModulos
    {
        public int PKSubModuloId { get; set; }
        public string SubModuloDescripcion { get; set; }
        public int FKModuloId { get; set; }
        public bool SubModuloEstado { get; set; }
    
        public virtual Modulos Modulos { get; set; }
    }
}
