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
    
    public partial class Pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedidos()
        {
            this.Detalles_de_pedidos = new HashSet<Detalles_de_pedidos>();
        }
    
        public int IdPedido { get; set; }
        public string IdCliente { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<System.DateTime> FechaPedido { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public Nullable<System.DateTime> FechaEnvío { get; set; }
        public Nullable<int> FormaEnvío { get; set; }
        public Nullable<decimal> Cargo { get; set; }
        public string Destinatario { get; set; }
        public string DirecciónDestinatario { get; set; }
        public string CiudadDestinatario { get; set; }
        public string RegiónDestinatario { get; set; }
        public string CódPostalDestinatario { get; set; }
        public string PaísDestinatario { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Compañías_de_envíos Compañías_de_envíos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalles_de_pedidos> Detalles_de_pedidos { get; set; }
        public virtual Empleados Empleados { get; set; }
    }
}
