// <auto-generated />
using System;
using Document.WorkFlow.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Document.WorkFlow.Migrations
{
    [DbContext(typeof(PurchaseOrderContext))]
    [Migration("20220616193249_PurchaseDB")]
    partial class PurchaseDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Document.WorkFlow.Models.PurchaseOrder", b =>
                {
                    b.Property<string>("CurrencyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ForeignID")
                        .HasColumnType("int");

                    b.Property<string>("PODate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PONumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SearchString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalGross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalNet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalVat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Void")
                        .HasColumnType("int");

                    b.ToTable("PurchaseOrder", (string)null);
                });

            modelBuilder.Entity("Document.WorkFlow.Models.PurchaseOrderLine", b =>
                {
                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForeignID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PartNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int");

                    b.Property<int>("QuantityReceived")
                        .HasColumnType("int");

                    b.Property<string>("UnitMeasure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VatValue")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("PurchaseOrderLine", (string)null);
                });

            modelBuilder.Entity("Document.WorkFlow.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"), 1L, 1);

                    b.Property<string>("Accounts_Ref")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_dATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vat_Reg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Void")
                        .HasColumnType("int");

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
