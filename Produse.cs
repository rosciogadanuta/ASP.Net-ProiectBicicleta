namespace BicicleteWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produse")]
    public partial class Produse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produse()
        {
            ComandaProdus = new HashSet<ComandaProdu>();
            CuloareProdus = new HashSet<CuloareProdu>();
        }

        [Key]
        public int ProdusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Denumire { get; set; }

        [Column(TypeName = "money")]
        public decimal Pret { get; set; }

        [StringLength(50)]
        public string Producator { get; set; }

        [StringLength(1000)]
        public string Url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComandaProdu> ComandaProdus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuloareProdu> CuloareProdus { get; set; }
    }
}
