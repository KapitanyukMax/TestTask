﻿// <auto-generated />
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(TestTaskDbContext))]
    partial class TestTaskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Account", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Contact", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.HasIndex("AccountName");

                    b.ToTable("Contacts", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Incident", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.HasIndex("AccountName");

                    b.ToTable("Incidents", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Contact", b =>
                {
                    b.HasOne("DataAccess.Entities.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DataAccess.Entities.Incident", b =>
                {
                    b.HasOne("DataAccess.Entities.Account", "Account")
                        .WithMany("Incidents")
                        .HasForeignKey("AccountName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DataAccess.Entities.Account", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Incidents");
                });
#pragma warning restore 612, 618
        }
    }
}
