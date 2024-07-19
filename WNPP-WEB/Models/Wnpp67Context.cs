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

    public virtual DbSet<MMonastery> MMonasteries { get; set; }

    public virtual DbSet<TBranch> TBranches { get; set; }

    public virtual DbSet<TBuddhistLent> TBuddhistLents { get; set; }

    public virtual DbSet<TBuddhistLentDetail> TBuddhistLentDetails { get; set; }

    public virtual DbSet<TMonk> TMonks { get; set; }

    public virtual DbSet<ThaiTemple2567> ThaiTemple2567s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.99;Database=WNPP67;UID=wnpp;PWD=P@55w0rd;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CS_AI");

        modelBuilder.Entity<MMonastery>(entity =>
        {
            entity.ToTable("M_Monastery");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryMonatery)
                .HasMaxLength(100)
                .HasColumnName("Country_Monatery");
            entity.Property(e => e.CreatedByName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfFoundingTxt).HasMaxLength(12);
            entity.Property(e => e.DateOfWisungkhamTxt).HasMaxLength(12);
            entity.Property(e => e.Denomination).HasMaxLength(100);
            entity.Property(e => e.DistrictMonatery)
                .HasMaxLength(100)
                .HasColumnName("District_Monatery");
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.ModifiedByName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.MonasteryName).HasMaxLength(250);
            entity.Property(e => e.MonasteryNo).HasMaxLength(50);
            entity.Property(e => e.MonasteryType).HasMaxLength(50);
            entity.Property(e => e.Notation).HasMaxLength(500);
            entity.Property(e => e.PostCodeMonatery)
                .HasMaxLength(5)
                .HasColumnName("PostCode_Monatery");
            entity.Property(e => e.ProvinceMonatery)
                .HasMaxLength(100)
                .HasColumnName("Province_Monatery");
            entity.Property(e => e.RecordStatus).HasMaxLength(10);
            entity.Property(e => e.RegisterType).HasMaxLength(50);
            entity.Property(e => e.SubDistrictMonatery)
                .HasMaxLength(100)
                .HasColumnName("SubDistrict_Monatery");
            entity.Property(e => e.WisungkhamType).HasMaxLength(50);
        });

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

        modelBuilder.Entity<TBuddhistLent>(entity =>
        {
            entity.ToTable("T_BuddhistLent");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BuddhistLentEndDate).HasColumnType("datetime");
            entity.Property(e => e.BuddhistLentInFo).HasMaxLength(250);
            entity.Property(e => e.BuddhistLentStartDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedByName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.ModifiedByName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.MonkNote).HasMaxLength(250);
            entity.Property(e => e.Notation).HasMaxLength(500);
            entity.Property(e => e.NunsNote).HasMaxLength(250);
            entity.Property(e => e.RecordStatus).HasMaxLength(10);
        });

        modelBuilder.Entity<TBuddhistLentDetail>(entity =>
        {
            entity.ToTable("T_BuddhistLentDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Blid).HasColumnName("BLID");
            entity.Property(e => e.CreatedByName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfOrdination).HasColumnType("datetime");
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.ModifiedByName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.MonkId).HasColumnName("MonkID");
            entity.Property(e => e.MonkName).HasMaxLength(250);
            entity.Property(e => e.MonkNicName).HasMaxLength(50);
            entity.Property(e => e.MonkSeq).HasColumnName("MonkSEQ");
            entity.Property(e => e.Notation).HasMaxLength(500);
            entity.Property(e => e.Preceptor).HasMaxLength(250);
            entity.Property(e => e.RecordStatus).HasMaxLength(10);
            entity.Property(e => e.TempleName).HasMaxLength(250);
        });

        modelBuilder.Entity<TMonk>(entity =>
        {
            entity.ToTable("T_Monk");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CertificateForMonksNo).HasMaxLength(100);
            entity.Property(e => e.CreatedByName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfOrdination).HasColumnType("datetime");
            entity.Property(e => e.FDistrict)
                .HasMaxLength(100)
                .HasColumnName("F_District");
            entity.Property(e => e.FProvince)
                .HasMaxLength(100)
                .HasColumnName("F_Province");
            entity.Property(e => e.FSubDistrict)
                .HasMaxLength(100)
                .HasColumnName("F_SubDistrict");
            entity.Property(e => e.FTemple)
                .HasMaxLength(250)
                .HasColumnName("F_Temple");
            entity.Property(e => e.FirstOrdinationTeacher).HasMaxLength(250);
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.MCountry)
                .HasMaxLength(100)
                .HasColumnName("M_Country");
            entity.Property(e => e.MDateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("M_DateOfBirth");
            entity.Property(e => e.MDistrict)
                .HasMaxLength(100)
                .HasColumnName("M_District");
            entity.Property(e => e.MEmail)
                .HasMaxLength(50)
                .HasColumnName("M_EMail");
            entity.Property(e => e.MEthnicity)
                .HasMaxLength(100)
                .HasColumnName("M_Ethnicity");
            entity.Property(e => e.MFirstName)
                .HasMaxLength(250)
                .HasColumnName("M_FirstName");
            entity.Property(e => e.MHouseNo)
                .HasMaxLength(50)
                .HasColumnName("M_HouseNo");
            entity.Property(e => e.MImage).HasColumnName("M_Image");
            entity.Property(e => e.MLineId)
                .HasMaxLength(50)
                .HasColumnName("M_LineID");
            entity.Property(e => e.MMoo)
                .HasMaxLength(2)
                .HasColumnName("M_Moo");
            entity.Property(e => e.MNationality)
                .HasMaxLength(100)
                .HasColumnName("M_Nationality");
            entity.Property(e => e.MNickName)
                .HasMaxLength(50)
                .HasColumnName("M_NickName");
            entity.Property(e => e.MPhoneNo)
                .HasMaxLength(50)
                .HasColumnName("M_PhoneNO");
            entity.Property(e => e.MPid)
                .HasMaxLength(15)
                .HasColumnName("M_PID");
            entity.Property(e => e.MPostCode)
                .HasMaxLength(5)
                .HasColumnName("M_PostCode");
            entity.Property(e => e.MProvince)
                .HasMaxLength(100)
                .HasColumnName("M_Province");
            entity.Property(e => e.MRoad)
                .HasMaxLength(50)
                .HasColumnName("M_Road");
            entity.Property(e => e.MSubDistrict)
                .HasMaxLength(100)
                .HasColumnName("M_SubDistrict");
            entity.Property(e => e.MSurName)
                .HasMaxLength(250)
                .HasColumnName("M_SurName");
            entity.Property(e => e.MVillage)
                .HasMaxLength(50)
                .HasColumnName("M_Village");
            entity.Property(e => e.ModifiedByName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.MonkName).HasMaxLength(250);
            entity.Property(e => e.MonkTypeName).HasMaxLength(250);
            entity.Property(e => e.Notation).HasMaxLength(500);
            entity.Property(e => e.PDistrict)
                .HasMaxLength(100)
                .HasColumnName("P_District");
            entity.Property(e => e.PProvince)
                .HasMaxLength(100)
                .HasColumnName("P_Province");
            entity.Property(e => e.PSubDistrict)
                .HasMaxLength(100)
                .HasColumnName("P_SubDistrict");
            entity.Property(e => e.PTemple)
                .HasMaxLength(250)
                .HasColumnName("P_Temple");
            entity.Property(e => e.ParticipateTemple).HasMaxLength(250);
            entity.Property(e => e.Preceptor).HasMaxLength(250);
            entity.Property(e => e.PtDistrict)
                .HasMaxLength(100)
                .HasColumnName("PT_District");
            entity.Property(e => e.PtProvince)
                .HasMaxLength(100)
                .HasColumnName("PT_Province");
            entity.Property(e => e.PtSubDistrict)
                .HasMaxLength(100)
                .HasColumnName("PT_SubDistrict");
            entity.Property(e => e.RecordStatus).HasMaxLength(10);
            entity.Property(e => e.SDistrict)
                .HasMaxLength(100)
                .HasColumnName("S_District");
            entity.Property(e => e.SProvince)
                .HasMaxLength(100)
                .HasColumnName("S_Province");
            entity.Property(e => e.SSubDistrict)
                .HasMaxLength(100)
                .HasColumnName("S_SubDistrict");
            entity.Property(e => e.STemple)
                .HasMaxLength(250)
                .HasColumnName("S_Temple");
            entity.Property(e => e.SecondOrdinationTeacher).HasMaxLength(250);
            entity.Property(e => e.TDistrict)
                .HasMaxLength(100)
                .HasColumnName("T_District");
            entity.Property(e => e.TProvince)
                .HasMaxLength(100)
                .HasColumnName("T_Province");
            entity.Property(e => e.TSubDistrict)
                .HasMaxLength(100)
                .HasColumnName("T_SubDistrict");
            entity.Property(e => e.TempleName).HasMaxLength(250);
        });

        modelBuilder.Entity<ThaiTemple2567>(entity =>
        {
            entity.HasKey(e => e.ลำดบ);

            entity.ToTable("ThaiTemple2567");

            entity.Property(e => e.ลำดบ)
                .ValueGeneratedNever()
                .HasColumnName("ลำดับ");
            entity.Property(e => e.จงหวด)
                .HasMaxLength(150)
                .HasColumnName("จังหวัด");
            entity.Property(e => e.ชอวด)
                .HasMaxLength(250)
                .HasColumnName("ชื่อวัด");
            entity.Property(e => e.ชอหมบาน)
                .HasMaxLength(50)
                .HasColumnName("ชื่อหมู่บ้าน");
            entity.Property(e => e.ซอย).HasMaxLength(50);
            entity.Property(e => e.ถนน).HasMaxLength(50);
            entity.Property(e => e.นกาย)
                .HasMaxLength(50)
                .HasColumnName("นิกาย");
            entity.Property(e => e.บานเลขท)
                .HasMaxLength(50)
                .HasColumnName("บ้านเลขที่");
            entity.Property(e => e.ประเภทการขนทะเบยน)
                .HasMaxLength(50)
                .HasColumnName("ประเภทการขึ้นทะเบียน");
            entity.Property(e => e.ประเภทวด)
                .HasMaxLength(50)
                .HasColumnName("ประเภทวัด");
            entity.Property(e => e.รหสวด)
                .HasMaxLength(50)
                .HasColumnName("รหัสวัด");
            entity.Property(e => e.รหสไปรษณย)
                .HasMaxLength(50)
                .HasColumnName("รหัสไปรษณีย์");
            entity.Property(e => e.วนทตงวด)
                .HasMaxLength(50)
                .HasColumnName("วันที่ตั้งวัด");
            entity.Property(e => e.วนทสถานะวด)
                .HasMaxLength(50)
                .HasColumnName("วันที่สถานะวัด");
            entity.Property(e => e.วนทไดรบวสงคามสมา)
                .HasMaxLength(50)
                .HasColumnName("วันที่ได้รับวิสุงคามสีมา");
            entity.Property(e => e.หม)
                .HasMaxLength(50)
                .HasColumnName("หมู่");
            entity.Property(e => e.หมายเหต)
                .HasMaxLength(250)
                .HasColumnName("หมายเหตุ");
            entity.Property(e => e.อเมล)
                .HasMaxLength(50)
                .HasColumnName("อีเมล์");
            entity.Property(e => e.เขตอำเภอ)
                .HasMaxLength(150)
                .HasColumnName("เขต_อำเภอ");
            entity.Property(e => e.เบอรโทรศพท)
                .HasMaxLength(50)
                .HasColumnName("เบอร์โทรศัพท์");
            entity.Property(e => e.เวบไซต)
                .HasMaxLength(50)
                .HasColumnName("เว็บไซต์");
            entity.Property(e => e.แขวงตำบล)
                .HasMaxLength(150)
                .HasColumnName("แขวง_ตำบล");
            entity.Property(e => e.โทรสาร).HasMaxLength(50);
            entity.Property(e => e.ไดรบวสงคามสมา)
                .HasMaxLength(50)
                .HasColumnName("ได้รับวิสุงคามสีมา");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
