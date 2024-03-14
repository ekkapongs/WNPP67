using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BranchRegister.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchType = table.Column<int>(type: "int", nullable: true),
                    BranchTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonasteryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonasteryType = table.Column<int>(type: "int", nullable: true),
                    MonasteryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonasteryPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepositaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepositaryPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonasteryAreaRai = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonasteryAreaNgan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonasteryAreaWa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LandRightsDocuments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfFounding = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EcclesiasticalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EcclesiasticalType = table.Column<int>(type: "int", nullable: true),
                    AbbotTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbbotName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbbotType = table.Column<int>(type: "int", nullable: true),
                    AbbotTemple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preceptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreceptorTemple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAcceptPosition = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AbbotPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbbotEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbbotLineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbbotImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertifierTemple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfOrdination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AbbotSignDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressTextMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNoMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MooMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoadMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDistrictMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCodeMonatery = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBranch", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBranch");
        }
    }
}
