using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DemirbasTakipApp.API.Models
{
    public partial class DemirbasTakipContext : DbContext
    {
        public DemirbasTakipContext()
        {
        }

        public DemirbasTakipContext(DbContextOptions<DemirbasTakipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Insanlar> Insanlar { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseNpgsql("Host=localhost;Database=DemirbasTakip;Username=postgres;Password=sql123");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insanlar>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MedeniDurum)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sehir)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Tel).HasColumnType("numeric");
            });

            modelBuilder.Entity<Urunler>(entity =>
            {
                entity.HasIndex(e => e.AlanKisi)
                    .HasName("fki_f");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.AlanKisi).HasColumnName("Alan_Kisi");

                entity.Property(e => e.BirimFiyati).HasColumnName("Birim_Fiyati");

                entity.Property(e => e.SeriNo).HasColumnName("Seri_No");

                entity.Property(e => e.UrunIsim)
                    .IsRequired()
                    .HasColumnName("Urun_isim")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.AlanKisiNavigation)
                    .WithMany(p => p.Urunler)
                    .HasForeignKey(d => d.AlanKisi)
                    .HasConstraintName("insan_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
