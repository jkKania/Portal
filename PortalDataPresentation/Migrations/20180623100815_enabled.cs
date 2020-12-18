using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PortalDataPresentation.Migrations
{
    public partial class enabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    KeyName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RecordCreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    InstalationID = table.Column<int>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OutID = table.Column<int>(nullable: false),
                    RecordCreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementDataViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataTypeName = table.Column<string>(nullable: true),
                    MeasurmentDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementDataViewModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostMeasurementsVM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataTypeName = table.Column<string>(nullable: true),
                    InstalationName = table.Column<string>(nullable: true),
                    LocationName = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMeasurementsVM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArtisticInstalation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurentLocationId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RecordCreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisticInstalation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArtisticInstalation_Location_CurentLocationId",
                        column: x => x.CurentLocationId,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataTypeID = table.Column<int>(nullable: false),
                    InstalationID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    MeasurmentDate = table.Column<DateTime>(nullable: false),
                    RecordCreateTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeasurementData_DataType_DataTypeID",
                        column: x => x.DataTypeID,
                        principalTable: "DataType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementData_ArtisticInstalation_InstalationID",
                        column: x => x.InstalationID,
                        principalTable: "ArtisticInstalation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementData_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtisticInstalation_CurentLocationId",
                table: "ArtisticInstalation",
                column: "CurentLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementData_DataTypeID",
                table: "MeasurementData",
                column: "DataTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementData_InstalationID",
                table: "MeasurementData",
                column: "InstalationID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementData_LocationID",
                table: "MeasurementData",
                column: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementData");

            migrationBuilder.DropTable(
                name: "MeasurementDataViewModel");

            migrationBuilder.DropTable(
                name: "PostMeasurementsVM");

            migrationBuilder.DropTable(
                name: "DataType");

            migrationBuilder.DropTable(
                name: "ArtisticInstalation");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
