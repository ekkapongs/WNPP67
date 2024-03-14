﻿// <auto-generated />
using System;
using BranchRegister.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BranchRegister.Migrations
{
    [DbContext(typeof(BranchRegisterContext))]
    partial class BranchRegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BranchRegister.Models.TBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AbbotEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AbbotImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AbbotLineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AbbotName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AbbotPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AbbotSignDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AbbotTemple")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AbbotTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AbbotType")
                        .HasColumnType("int");

                    b.Property<bool?>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("AddressTextMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BranchType")
                        .HasColumnType("int");

                    b.Property<string>("BranchTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertifierTemple")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfAcceptPosition")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfFounding")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfOrdination")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepositaryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepositaryPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EcclesiasticalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EcclesiasticalType")
                        .HasColumnType("int");

                    b.Property<string>("HouseNoMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandRightsDocuments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("MonasteryAreaNgan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MonasteryAreaRai")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MonasteryAreaWa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MonasteryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonasteryPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MonasteryType")
                        .HasColumnType("int");

                    b.Property<string>("MonasteryTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MooMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCodeMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preceptor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreceptorTemple")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoadMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubDistrictMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VillageMonatery")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBranch");
                });
#pragma warning restore 612, 618
        }
    }
}
