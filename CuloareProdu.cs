namespace BicicleteWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CuloareProdu
    {
        public int ID { get; set; }

        public int CuloareId { get; set; }

        public int ProdusId { get; set; }

        public virtual Culori Culori { get; set; }

        public virtual Produse Produse { get; set; }
    }
}
