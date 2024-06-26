using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WNPP_WEB.Models;

public partial class Imdb67Context : DbContext
{
    public Imdb67Context()
    {
    }

    public Imdb67Context(DbContextOptions<Imdb67Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TFileDb> TFileDbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.99;Database=imdb67;UID=wnpp;PWD=P@55w0rd;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CS_AI");

        modelBuilder.Entity<TFileDb>(entity =>
        {
            entity.ToTable("T_FileDB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedByName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.FileNotation).HasMaxLength(500);
            entity.Property(e => e.FileType).HasMaxLength(100);
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.ModifiedByName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Notation).HasMaxLength(500);
            entity.Property(e => e.RecordStatus).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
