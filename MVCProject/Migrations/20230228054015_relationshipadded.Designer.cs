﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleMVCProject.Data;

#nullable disable

namespace MVCProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230228054015_relationshipadded")]
    partial class relationshipadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCProject.Domains.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MVCProject.Domains.Person", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MVCProject.Domains.PersonsInfoLanguages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonInfoInDifferentLanguage");
                });

            modelBuilder.Entity("MVCProject.Domains.PersonsInfoLanguages", b =>
                {
                    b.HasOne("MVCProject.Domains.Language", "Language")
                        .WithMany("PersonInfoDifferentLanguage")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Domains.Person", "Person")
                        .WithMany("PersonInfoLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MVCProject.Domains.Language", b =>
                {
                    b.Navigation("PersonInfoDifferentLanguage");
                });

            modelBuilder.Entity("MVCProject.Domains.Person", b =>
                {
                    b.Navigation("PersonInfoLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
