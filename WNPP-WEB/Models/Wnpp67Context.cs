using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WNPP_WEB.Models;

public partial class Wnpp67Context : DbContext
{
    public Wnpp67Context()
    {
    }

    public Wnpp67Context(DbContextOptions<Wnpp67Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TBranch> TBranches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.99;Database=WNPP67;UID=wnpp;PWD=P@55w0rd;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CS_AI");

        modelBuilder.Entity<TBranch>(entity =>
        {
            entity.ToTable("T_Branch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AbbotEmail)
                .HasMaxLength(50)
                .HasColumnName("AbbotEMail");
            entity.Property(e => e.AbbotImageUrl).HasMaxLength(250);
            entity.Property(e => e.AbbotLineId)
                .HasMaxLength(50)
                .HasColumnName("AbbotLineID");
            entity.Property(e => e.AbbotName).HasMaxLength(250);
            entity.Property(e => e.AbbotPhoneNo)
                .HasMaxLength(50)
                .HasColumnName("AbbotPhoneNO");
            entity.Property(e => e.AbbotSignDate).HasColumnType("datetime");
            entity.Property(e => e.AbbotTemple).HasMaxLength(250);
            entity.Property(e => e.AbbotTitle).HasMaxLength(50);
            entity.Property(e => e.AddressTextMonatery)
                .HasMaxLength(500)
                .HasColumnName("AddressText_Monatery");
            entity.Property(e => e.BranchName).HasMaxLength(250);
            entity.Property(e => e.BranchTypeName).HasMaxLength(50);
            entity.Property(e => e.CertifierName).HasMaxLength(250);
            entity.Property(e => e.CertifierTemple).HasMaxLength(250);
            entity.Property(e => e.CountryMonatery)
                .HasMaxLength(100)
                .HasColumnName("Country_Monatery");
            entity.Property(e => e.CreatedByName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfAcceptPosition).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfFounding).HasColumnType("datetime");
            entity.Property(e => e.DateOfOrdination).HasColumnType("datetime");
            entity.Property(e => e.DateOfRegister).HasColumnType("datetime");
            entity.Property(e => e.DepositaryName).HasMaxLength(50);
            entity.Property(e => e.DepositaryPhoneNo)
                .HasMaxLength(50)
                .HasColumnName("DepositaryPhoneNO");
            entity.Property(e => e.DistrictMonatery)
                .HasMaxLength(100)
                .HasColumnName("District_Monatery");
            entity.Property(e => e.EcclesiasticalTitle).HasMaxLength(50);
            entity.Property(e => e.HouseNoMonatery)
                .HasMaxLength(50)
                .HasColumnName("HouseNo_Monatery");
            entity.Property(e => e.LandRightsDocuments).HasMaxLength(50);
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.ModifiedByName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.MonasteryAreaNgan).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MonasteryAreaRai).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MonasteryAreaWa).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MonasteryName).HasMaxLength(250);
            entity.Property(e => e.MonasteryPhoneNo)
                .HasMaxLength(50)
                .HasColumnName("MonasteryPhoneNO");
            entity.Property(e => e.MonasteryTypeName).HasMaxLength(50);
            entity.Property(e => e.MooMonatery)
                .HasMaxLength(2)
                .HasColumnName("Moo_Monatery");
            entity.Property(e => e.Notation).HasMaxLength(500);
            entity.Property(e => e.PostCodeMonatery)
                .HasMaxLength(5)
                .HasColumnName("PostCode_Monatery");
            entity.Property(e => e.Preceptor).HasMaxLength(250);
            entity.Property(e => e.PreceptorTemple).HasMaxLength(250);
            entity.Property(e => e.ProvinceMonatery)
                .HasMaxLength(100)
                .HasColumnName("Province_Monatery");
            entity.Property(e => e.RecordStatus).HasMaxLength(10);
            entity.Property(e => e.RoadMonatery)
                .HasMaxLength(50)
                .HasColumnName("Road_Monatery");
            entity.Property(e => e.SubDistrictMonatery)
                .HasMaxLength(100)
                .HasColumnName("SubDistrict_Monatery");
            entity.Property(e => e.VillageMonatery)
                .HasMaxLength(50)
                .HasColumnName("Village_Monatery");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
