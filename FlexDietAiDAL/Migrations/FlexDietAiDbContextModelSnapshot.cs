﻿// <auto-generated />
using System;
using FlexDietAiDAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlexDietAiDAL.Migrations
{
    [DbContext(typeof(FlexDietAiDbContext))]
    partial class FlexDietAiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FlexDietAiDAL.Models.DietMenu", b =>
                {
                    b.Property<int>("DietMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DietMenuId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("InitialDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Kcal")
                        .HasColumnType("integer");

                    b.Property<string>("Menu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserDietId")
                        .HasColumnType("integer");

                    b.HasKey("DietMenuId");

                    b.HasIndex("UserDietId");

                    b.ToTable("DietsMenus");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BashPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.UserData", b =>
                {
                    b.Property<int>("UserDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserDataId"));

                    b.Property<DateOnly>("Dof")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Somatotype")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("UserDataId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersData");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.UserDiet", b =>
                {
                    b.Property<int>("UserDietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserDietId"));

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("UserDietId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersDiets");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.UserHealth", b =>
                {
                    b.Property<int>("UsersHealthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UsersHealthId"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("UsersHealthId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersHealth");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.DietMenu", b =>
                {
                    b.HasOne("FlexDietAiDAL.Models.UserDiet", "UserDiet")
                        .WithMany("DietMenu")
                        .HasForeignKey("UserDietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDiet");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.UserData", b =>
                {
                    b.HasOne("FlexDietAiDAL.Models.User", "User")
                        .WithOne("UserData")
                        .HasForeignKey("FlexDietAiDAL.Models.UserData", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.UserDiet", b =>
                {
                    b.HasOne("FlexDietAiDAL.Models.User", "User")
                        .WithMany("UserDiet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.UserHealth", b =>
                {
                    b.HasOne("FlexDietAiDAL.Models.User", "User")
                        .WithMany("UserHealth")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.User", b =>
                {
                    b.Navigation("UserData");

                    b.Navigation("UserDiet");

                    b.Navigation("UserHealth");
                });

            modelBuilder.Entity("FlexDietAiDAL.Models.UserDiet", b =>
                {
                    b.Navigation("DietMenu");
                });
#pragma warning restore 612, 618
        }
    }
}
