//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios.Models
{
	using Newtonsoft.Json;
	using System;
    using System.Collections.Generic;
    
    public partial class MarcasVehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarcasVehiculo()
        {
            this.Vehiculos = new HashSet<Vehiculo>();
        }
    
        public int id_marca { get; set; }
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[JsonIgnore]
		public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
