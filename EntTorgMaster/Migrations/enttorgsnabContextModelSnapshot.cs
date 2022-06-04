﻿// <auto-generated />
using System;
using EntTorgMaster.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntTorgMaster.Migrations
{
    [DbContext(typeof(enttorgsnabContext))]
    partial class enttorgsnabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_unicode_ci")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb3");

            modelBuilder.Entity("EntTorgMaster.Data.DoorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Enable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DoorTypes");
                });

            modelBuilder.Entity("EntTorgMaster.Data.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<decimal?>("Volume")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("isEnable")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("EntTorgMaster.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("DateCreate")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Shet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("ShetDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntTorgMaster.Data.OrderDoor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DoorTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Dovod")
                        .HasColumnType("int");

                    b.Property<bool>("Framuga")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("FramugaH")
                        .HasColumnType("int");

                    b.Property<int>("H")
                        .HasColumnType("int");

                    b.Property<string>("Marking")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Nalichnik")
                        .HasColumnType("int");

                    b.Property<int?>("NavesCount")
                        .HasColumnType("int");

                    b.Property<int?>("NavesStvorkaCount")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Open")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Ral")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("S")
                        .HasColumnType("int");

                    b.Property<bool>("SEqual")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Shild")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("W")
                        .HasColumnType("int");

                    b.Property<int?>("WindowCount")
                        .HasColumnType("int");

                    b.Property<int?>("WindowStvorkaCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoorTypeId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDoors");
                });

            modelBuilder.Entity("EntTorgMaster.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntTorgMaster.Data.OrderDoor", b =>
                {
                    b.HasOne("EntTorgMaster.Data.DoorType", "DoorType")
                        .WithMany("OrderDoors")
                        .HasForeignKey("DoorTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntTorgMaster.Data.Order", "Order")
                        .WithMany("OrderDoors")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoorType");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EntTorgMaster.Data.DoorType", b =>
                {
                    b.Navigation("OrderDoors");
                });

            modelBuilder.Entity("EntTorgMaster.Data.Order", b =>
                {
                    b.Navigation("OrderDoors");
                });
#pragma warning restore 612, 618
        }
    }
}
