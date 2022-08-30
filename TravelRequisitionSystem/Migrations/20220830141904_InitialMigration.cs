using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelRequisitionSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "travelRequestDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinatioCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposedDepartureTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelClass = table.Column<int>(type: "int", nullable: false),
                    TripType = table.Column<int>(type: "int", nullable: false),
                    ChargeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisitionStatus = table.Column<int>(type: "int", nullable: false),
                    RequisitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travelRequestDetails", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "travelRequestDetails");
        }
    }
}
