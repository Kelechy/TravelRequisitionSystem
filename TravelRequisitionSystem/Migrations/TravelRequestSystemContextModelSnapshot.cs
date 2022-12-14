// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelRequisitionSystem.Context;

namespace TravelRequisitionSystem.Migrations
{
    [DbContext(typeof(TravelRequestSystemContext))]
    partial class TravelRequestSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TravelRequisitionSystem.Model.TravelRequestDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ChargeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinatioCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProposedDepartureTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequisitionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequisitionStatus")
                        .HasColumnType("int");

                    b.Property<string>("SourceCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TravelClass")
                        .HasColumnType("int");

                    b.Property<string>("TravelerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TripType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("travelRequestDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
