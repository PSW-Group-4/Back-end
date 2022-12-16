using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Users.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.CreateTable(
                name: "AcountActivationInfos",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivationToken = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcountActivationInfos", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    StreetNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgeGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GropuName = table.Column<string>(type: "text", nullable: true),
                    MinAge = table.Column<int>(type: "integer", nullable: false),
                    MaxAge = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodSupply",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodGroup = table.Column<int>(type: "integer", maxLength: 1, nullable: true),
                    RhFactor = table.Column<int>(type: "integer", maxLength: 10, nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodSupply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<Password>(type: "jsonb", nullable: true),
                    IsAccountActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    suspicious_activities = table.Column<List<SuspiciousActivity>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsFree = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Equipments_equipmentId",
                        column: x => x.equipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentToMoves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentToMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentToMoves_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    FloorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Workhours = table.Column<string>(type: "text", nullable: true),
                    BedIds = table.Column<List<Guid>>(type: "uuid[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LicenceNum = table.Column<string>(type: "text", nullable: true),
                    Speciality = table.Column<string>(type: "text", nullable: true),
                    WorkingTimeStart = table.Column<string>(type: "text", nullable: true),
                    WorkingTimeEnd = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Jmbg = table.Column<Jmbg>(type: "jsonb", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CoordinateX = table.Column<int>(type: "integer", nullable: true),
                    CoordinateY = table.Column<int>(type: "integer", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Width = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    FloorId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapItem_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MapItem_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MapItem_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomsEquipment",
                columns: table => new
                {
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsEquipment", x => new { x.RoomId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_RoomsEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsEquipment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodConsumptionRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AmountValue = table.Column<double>(type: "double precision", nullable: true),
                    BloodType = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodConsumptionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodConsumptionRecords_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodGroup = table.Column<int>(type: "integer", maxLength: 1, nullable: true),
                    RhFactor = table.Column<int>(type: "integer", maxLength: 10, nullable: true),
                    ChosenDoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Jmbg = table.Column<Jmbg>(type: "jsonb", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_ChosenDoctorId",
                        column: x => x.ChosenDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    Urgent = table.Column<bool>(type: "boolean", nullable: false),
                    VacationStatus = table.Column<int>(type: "integer", nullable: false),
                    DeniedRequestReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uuid", nullable: true),
                    BloodConsumptionRecordId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_BloodConsumptionRecords_BloodConsumptionRecordId",
                        column: x => x.BloodConsumptionRecordId,
                        principalTable: "BloodConsumptionRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatments_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsCanceled = table.Column<bool>(type: "boolean", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    EquipmentToMoveId = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: true),
                    RenovationAppointment_Type = table.Column<int>(type: "integer", nullable: true),
                    RoomRenovationPlans = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_EquipmentToMoves_EquipmentToMoveId",
                        column: x => x.EquipmentToMoveId,
                        principalTable: "EquipmentToMoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    IsAnonimous = table.Column<bool>(type: "boolean", nullable: false),
                    IsDesiredPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergies",
                columns: table => new
                {
                    AllergiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergies", x => new { x.AllergiesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    arrivalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsiliumDoctor",
                columns: table => new
                {
                    ConsiliumsId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiliumDoctor", x => new { x.ConsiliumsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Appointments_ConsiliumsId",
                        column: x => x.ConsiliumsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalAppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Appointments_MedicalAppointmentId",
                        column: x => x.MedicalAppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdmissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DischargeReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionHistories_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportSymptom",
                columns: table => new
                {
                    ReportsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SymptomsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSymptom", x => new { x.ReportsId, x.SymptomsId });
                    table.ForeignKey(
                        name: "FK_ReportSymptom_Reports_ReportsId",
                        column: x => x.ReportsId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSymptom_Symptoms_SymptomsId",
                        column: x => x.SymptomsId,
                        principalTable: "Symptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinePrescription",
                columns: table => new
                {
                    MedicinesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PrescriptionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePrescription", x => new { x.MedicinesId, x.PrescriptionsId });
                    table.ForeignKey(
                        name: "FK_MedicinePrescription_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePrescription_Prescriptions_PrescriptionsId",
                        column: x => x.PrescriptionsId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionHistories_AdmissionId",
                table: "AdmissionHistories",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientId",
                table: "Admissions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_RoomId",
                table: "Admissions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_TreatmentId",
                table: "Admissions",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EquipmentToMoveId",
                table: "Appointments",
                column: "EquipmentToMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_equipmentId",
                table: "Beds",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodConsumptionRecords_DoctorId",
                table: "BloodConsumptionRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumDoctor_DoctorsId",
                table: "ConsiliumDoctor",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AddressId",
                table: "Doctors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToMoves_EquipmentId",
                table: "EquipmentToMoves",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingId",
                table: "Floors",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_MapItem_BuildingId",
                table: "MapItem",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_MapItem_FloorId",
                table: "MapItem",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_MapItem_RoomId",
                table: "MapItem",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescription_PrescriptionsId",
                table: "MedicinePrescription",
                column: "PrescriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientsId",
                table: "PatientAllergies",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ChosenDoctorId",
                table: "Patients",
                column: "ChosenDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ReportId",
                table: "Prescriptions",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MedicalAppointmentId",
                table: "Reports",
                column: "MedicalAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSymptom_SymptomsId",
                table: "ReportSymptom",
                column: "SymptomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsEquipment_EquipmentId",
                table: "RoomsEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_BloodConsumptionRecordId",
                table: "Treatments",
                column: "BloodConsumptionRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_MedicineId",
                table: "Treatments",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_DoctorId",
                table: "Vacations",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcountActivationInfos");

            migrationBuilder.DropTable(
                name: "AdmissionHistories");

            migrationBuilder.DropTable(
                name: "AgeGroups");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "BloodSupply");

            migrationBuilder.DropTable(
                name: "ConsiliumDoctor");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MapItem");

            migrationBuilder.DropTable(
                name: "MedicinePrescription");

            migrationBuilder.DropTable(
                name: "PatientAllergies");

            migrationBuilder.DropTable(
                name: "ReportSymptom");

            migrationBuilder.DropTable(
                name: "RoomsEquipment");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "BloodConsumptionRecords");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "EquipmentToMoves");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
