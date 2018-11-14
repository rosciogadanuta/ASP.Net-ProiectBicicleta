namespace BicicleteWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comenzis = new HashSet<Comenzi>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume { get; set; }

        [Required]
        [StringLength(50)]
        public string Parola { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public bool? Activ { get; set; }

        public bool? Aprobat { get; set; }

        public bool? Admin { get; set; }

        public DateTime Data { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comenzi> Comenzis { get; set; }
    }
}
