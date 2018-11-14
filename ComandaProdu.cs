namespace BicicleteWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ComandaProdu
    {
        public int ID { get; set; }

        public int ComandaId { get; set; }

        public int ProdusId { get; set; }

        public int Cantitate { get; set; }

        [Column(TypeName = "money")]
        public decimal PretCumparare { get; set; }

        public virtual Comenzi Comenzi { get; set; }

        public virtual Produse Produse { get; set; }
    }
}
