using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MaturitetnaSpletnaStran.DataDB
{
    public partial class MaturitetnaContext : DbContext
    {
        public MaturitetnaContext()
        {
        }

        public MaturitetnaContext(DbContextOptions<MaturitetnaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientUser> ClientUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Initial Catalog=Maturitetna;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.Name, "UQ__clients__72E12F1B0422C7CF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ClientUser>(entity =>
            {
                entity.ToTable("client_users");

                entity.HasIndex(e => e.Email, "UQ__client_u__AB6E6164AC58C467")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ClientUsers)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__client_us__id_cl__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
