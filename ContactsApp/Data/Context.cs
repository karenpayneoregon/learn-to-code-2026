#nullable disable

using ConsoleConfigurationLibrary.Classes;
using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ContactsApp.Data;

public partial class Context : DbContext
{
    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DeviceType> DeviceTypes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonAddress> PersonAddresses { get; set; }

    public virtual DbSet<PersonDevice> PersonDevices { get; set; }

    public virtual DbSet<StateProvince> StateProvinces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) // Only configure if not already configured (e.g., via dependency injection)
        {
            optionsBuilder.UseSqlite(AppConnections.Instance.MainConnection);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressLine1)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(200)");
            entity.Property(e => e.AddressLine2)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(200)");
            entity.Property(e => e.City)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(100)");
            entity.Property(e => e.CreatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.PostalCode)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(20)");
            entity.Property(e => e.RowVersion).IsRequired();
            entity.Property(e => e.StateProvinceId).HasColumnType("smallint");
            entity.Property(e => e.UpdatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");

            entity.HasOne(d => d.StateProvince).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StateProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.ToTable("AddressType");

            entity.HasIndex(e => e.AddressTypeName, "AddressType_UQ_AddressType_Name")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.AddressTypeId)
                .ValueGeneratedNever()
                .HasColumnType("smallint");
            entity.Property(e => e.AddressTypeName)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(30)");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.HasIndex(e => e.CountryCode2, "Country_UQ_Country_Code2")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnType("smallint");
            entity.Property(e => e.CountryCode2)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("char(2)");
            entity.Property(e => e.CountryName)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(100)");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.ToTable("Device");

            entity.HasIndex(e => new { e.DeviceTypeId, e.DeviceValue }, "Device_UX_Device_DeviceType_Value")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.CreatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.DeviceTypeId).HasColumnType("smallint");
            entity.Property(e => e.DeviceValue)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(320)");
            entity.Property(e => e.Extension)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnType("bit");
            entity.Property(e => e.RowVersion).IsRequired();
            entity.Property(e => e.UpdatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");

            entity.HasOne(d => d.DeviceType).WithMany(p => p.Devices)
                .HasForeignKey(d => d.DeviceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DeviceType>(entity =>
        {
            entity.ToTable("DeviceType");

            entity.HasIndex(e => e.DeviceTypeName, "DeviceType_UQ_DeviceType_Name")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.DeviceTypeId)
                .ValueGeneratedNever()
                .HasColumnType("smallint");
            entity.Property(e => e.DeviceKind)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(10)");
            entity.Property(e => e.DeviceTypeName)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(30)");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.HasIndex(e => e.GenderName, "Gender_UQ_Gender_GenderName")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.GenderId)
                .ValueGeneratedNever()
                .HasColumnType("smallint");
            entity.Property(e => e.GenderName)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(20)");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.CreatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(100)");
            entity.Property(e => e.GenderId).HasColumnType("smallint");
            entity.Property(e => e.LastName)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(100)");
            entity.Property(e => e.MiddleName)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(100)");
            entity.Property(e => e.Notes)
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(2000)");
            entity.Property(e => e.RowVersion).IsRequired();
            entity.Property(e => e.UpdatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Gender).WithMany(p => p.People).HasForeignKey(d => d.GenderId);
        });

        modelBuilder.Entity<PersonAddress>(entity =>
        {
            entity.ToTable("PersonAddress");

            entity.HasIndex(e => e.AddressId, "PersonAddress_IX_PersonAddress_AddressId").IsDescending();

            entity.HasIndex(e => e.PersonId, "PersonAddress_IX_PersonAddress_PersonId").IsDescending();

            entity.Property(e => e.AddressTypeId).HasColumnType("smallint");
            entity.Property(e => e.CreatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPrimary).HasColumnType("bit");
            entity.Property(e => e.StartDate)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Address).WithMany(p => p.PersonAddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AddressType).WithMany(p => p.PersonAddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person).WithMany(p => p.PersonAddresses)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonDevice>(entity =>
        {
            entity.ToTable("PersonDevice");

            entity.HasIndex(e => e.DeviceId, "PersonDevice_IX_PersonDevice_DeviceId").IsDescending();

            entity.HasIndex(e => e.PersonId, "PersonDevice_IX_PersonDevice_PersonId").IsDescending();

            entity.Property(e => e.CreatedAt)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPrimary).HasColumnType("bit");
            entity.Property(e => e.StartDate)
                .UseCollation("NOCASE")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Device).WithMany(p => p.PersonDevices)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person).WithMany(p => p.PersonDevices)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<StateProvince>(entity =>
        {
            entity.ToTable("StateProvince");

            entity.HasIndex(e => new { e.CountryId, e.StateCode }, "StateProvince_UQ_StateProvince_Country_StateCode")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.StateProvinceId)
                .ValueGeneratedNever()
                .HasColumnType("smallint");
            entity.Property(e => e.CountryId).HasColumnType("smallint");
            entity.Property(e => e.StateCode)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("char(2)");
            entity.Property(e => e.StateName)
                .IsRequired()
                .UseCollation("NOCASE")
                .HasColumnType("nvarchar(100)");

            entity.HasOne(d => d.Country).WithMany(p => p.StateProvinces)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}