namespace BicicleteWeb
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Biciclete : DbContext
    {
        public Biciclete()
            : base("name=Biciclete")
        {
        }

        public virtual DbSet<ComandaProdu> ComandaProdus { get; set; }
        public virtual DbSet<Comenzi> Comenzis { get; set; }
        public virtual DbSet<CuloareProdu> CuloareProdus { get; set; }
        public virtual DbSet<Culori> Culoris { get; set; }
        public virtual DbSet<Produse> Produses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComandaProdu>()
                .Property(e => e.PretCumparare)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Comenzi>()
                .HasMany(e => e.ComandaProdus)
                .WithRequired(e => e.Comenzi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Culori>()
                .Property(e => e.Denumire)
                .IsUnicode(false);

            modelBuilder.Entity<Culori>()
                .HasMany(e => e.CuloareProdus)
                .WithRequired(e => e.Culori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produse>()
                .Property(e => e.Denumire)
                .IsUnicode(false);

            modelBuilder.Entity<Produse>()
                .Property(e => e.Pret)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Produse>()
                .Property(e => e.Producator)
                .IsUnicode(false);

            modelBuilder.Entity<Produse>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Produse>()
                .HasMany(e => e.ComandaProdus)
                .WithRequired(e => e.Produse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produse>()
                .HasMany(e => e.CuloareProdus)
                .WithRequired(e => e.Produse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Nume)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Parola)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comenzis)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
