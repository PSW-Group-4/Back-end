﻿// <auto-generated />
using System;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HospitalLibrary.Appointments.Model.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.BuildingMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<int>("CoordinateX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordinateY")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("BuildingMaps");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.FloorMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CoordinateX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordinateY")
                        .HasColumnType("integer");

                    b.Property<Guid?>("FloorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("FloorMaps");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.RoomMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CoordinateX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordinateY")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomMaps");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HospitalLibrary.Doctors.Model.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("LicenceNum")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<string>("Speciality")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("WorkingTimeEnd")
                        .HasColumnType("text");

                    b.Property<string>("WorkingTimeStart")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoomId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalLibrary.Patients.Model.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Blocked")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("Lbo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid?>("DoctorRoomId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorRoomId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("FloorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("Rooms");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Room");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.CafeteriaRoom", b =>
                {
                    b.HasBaseType("HospitalLibrary.RoomsAndEqipment.Model.Room");

                    b.Property<string>("Workhours")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("CafeteriaRoom");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.DoctorRoom", b =>
                {
                    b.HasBaseType("HospitalLibrary.RoomsAndEqipment.Model.Room");

                    b.HasDiscriminator().HasValue("DoctorRoom");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Floor", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Building", null)
                        .WithMany("FloorList")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.BuildingMap", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.FloorMap", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId");

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.RoomMap", b =>
                {
                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Doctors.Model.Doctor", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Patients.Model.Patient", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Equipment", b =>
                {
                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.DoctorRoom", null)
                        .WithMany("EquipmentList")
                        .HasForeignKey("DoctorRoomId");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Room", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Floor", null)
                        .WithMany("RoomList")
                        .HasForeignKey("FloorId");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Building", b =>
                {
                    b.Navigation("FloorList");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Floor", b =>
                {
                    b.Navigation("RoomList");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.DoctorRoom", b =>
                {
                    b.Navigation("EquipmentList");
                });
#pragma warning restore 612, 618
        }
    }
}
