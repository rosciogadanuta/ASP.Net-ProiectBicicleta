namespace BicicleteWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comenzi")]
    public partial class Comenzi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comenzi()
        {
            ComandaProdus = new HashSet<ComandaProdu>();
        }

        [Key]
        public int ComandaId { get; set; }

        public int UserId { get; set; }

        public DateTime Data { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComandaProdu> ComandaProdus { get; set; }

        public virtual User User { get; set; }
    }
}
