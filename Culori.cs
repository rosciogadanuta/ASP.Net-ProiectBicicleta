namespace BicicleteWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Culori")]
    public partial class Culori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Culori()
        {
            CuloareProdus = new HashSet<CuloareProdu>();
        }

        [Key]
        public int CuloareId { get; set; }

        [Required]
        [StringLength(20)]
        public string Denumire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuloareProdu> CuloareProdus { get; set; }
    }
}
