﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data.Data
{
    public partial class hopeupermanDbContext : IdentityDbContext<IdentityUser>
    {
        public hopeupermanDbContext()
        {
        }

        public hopeupermanDbContext(DbContextOptions<hopeupermanDbContext> options)
            : base(options)
        {
        }
       
        public virtual DbSet<AdminData> AdminData { get; set; }
        public virtual DbSet<MapMarkers> MapMarkers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = tcp:hopeuperman.database.windows.net, 1433; Initial Catalog = hopeupermanDb; Persist Security Info = False; User ID = hopeuperman; Password=Superman911; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=hopeuperman_db;Integrated Security=true");

            modelBuilder.Entity<AdminData>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("adminData");

                entity.Property(e => e.AdminId).HasColumnName("adminId");

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adminEmail");

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adminPassword");

                entity.Property(e => e.AdminUsername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adminUsername");
            });

            modelBuilder.Entity<MapMarkers>(entity =>
            {
                entity.HasKey(e => e.MarkerId);

                entity.ToTable("mapMarkers");

                entity.HasIndex(e => e.AddedbyAdmin, "IX_mapMarkers_addedbyAdmin");

                entity.Property(e => e.MarkerId).HasColumnName("markerId");

                entity.Property(e => e.AddedbyAdmin).HasColumnName("addedbyAdmin");

                entity.Property(e => e.Translation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("translation");

                entity.Property(e => e.Dialect)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dialect");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationName");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.MainLangauge)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mainLangauge");

                entity.Property(e => e.Tag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tag");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.MapMarkers)
                    .HasForeignKey(d => d.AddedbyAdmin)
                    .HasConstraintName("FK_mapMarkers_ToTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}