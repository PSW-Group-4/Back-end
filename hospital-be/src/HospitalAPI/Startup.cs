using HospitalAPI.Mapper;
using HospitalLibrary.Allergies.Repository;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.BuildingManagmentMap.Repository.Implementation;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.BuildingManagmentMap.Service.Implementation;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Feedbacks.Repository;
using HospitalLibrary.Feedbacks.Service;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.RoomsAndEqipment.Repository;
using HospitalLibrary.RoomsAndEqipment.Repository.Implementation;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.Settings;
using HospitalLibrary.Users.Repository;
using HospitalLibrary.Users.Service;
using HospitalLibrary.Vacations.Repository;
using HospitalLibrary.Vacations.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using HospitalLibrary.BloodConsumptionRecords.Repository;
using HospitalLibrary.BloodConsumptionRecords.Service;
using HospitalLibrary.BloodSupplies.Repository;
using HospitalLibrary.BloodSupplies.Service;
using HospitalLibrary.Admissions.Repository;
using HospitalLibrary.Admissions.Service;
using System;
using HospitalAPI.Communications;
using HospitalAPI.Communications.Consumer;
using HospitalLibrary.Allergies.Service;
using HospitalLibrary.AcountActivation.Repository;
using HospitalLibrary.AcountActivation.Service;
using HospitalLibrary.MoveEquipment.Repository.Implementation;
using HospitalLibrary.MoveEquipment.Repository.Interfaces;
using HospitalLibrary.MoveEquipment.Service.Implementation;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Repository;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.MedicalReport.Services;
using HospitalAPI.HostedService;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.Medicines.Repository;
using HospitalLibrary.Medicines.Service;
using HospitalLibrary.Treatments.Repository;
using HospitalLibrary.Treatments.Service;
using HospitalLibrary.BuildingManagment.Repository.Interfaces;
using HospitalLibrary.BuildingManagment.Repository.Implementation;
using HospitalLibrary.BuildingManagment.Service.Interfaces;
using HospitalLibrary.BuildingManagment.Service.Implementation;
using HospitalLibrary.Symptoms.Repository;
using HospitalLibrary.Symptoms.Service;
using HospitalLibrary.Reports.Repository;
using HospitalLibrary.Reports.Service;
using HospitalLibrary.Renovation.Service.Interfaces;
using HospitalLibrary.Renovation.Service.Implementation;
using HospitalLibrary.Renovation.Repository.Interfaces;
using HospitalLibrary.Renovation.Repository.Implementation;
using HospitalLibrary.Consiliums.Repository;
using HospitalLibrary.Consiliums.Service;
using HospitalLibrary.AppointmentReport.Service;
using HospitalLibrary.News;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Repository;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Service;
using HospitalLibrary.MedicalAppointmentReportSession.Repository;
using HospitalLibrary.MedicalAppointmentReportSession.Service;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalLibrary.RenovationSessionAggregate.Services.Implementation;
using HospitalLibrary.RenovationSessionAggregate.Repository.Implementation;
using HospitalLibrary.RenovationSessionAggregate.Repository.Interfaces;
using HospitalLibrary.TenderReport.Service;

namespace HospitalAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HospitalDb")).UseLazyLoadingProxies());

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name="Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Here Enter JWT Token with bearer format like 'Bearer [space] token'"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference
                             = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                             }
                        },
                        new string[] {}
                    }
                });

            });
            services.AddAutoMapper(typeof(MappingProfile));

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddMvc();
            services.AddControllers();


            //News
            services.AddScoped<INewsService, NewsService>();
     

            //AgeGroups
            services.AddScoped<IAgeGroupRepository, AgeGroupRepository>();
            services.AddScoped<IAgeGroupService, AgeGroupService>();

            //Addeess
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();

            //Patient
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();

            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();

            //Acount Activation
            services.AddScoped<IAcountActivationRepository, AcountActivationRepository>();
            services.AddScoped<IAcountActivationService, AcountActivationService>();

            //Allergie
            services.AddScoped<IAllergieRepository, AllergieRepository>();
            services.AddScoped<IAllergieService, AllergieService>();

            //TODO Feedback
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            //Doctor
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();

            //Appointment
            services.AddScoped<IMedicalAppointmentRepository, MedicalAppointmentRepository>();
            services.AddScoped<IMedicalAppointmentService, MedicalAppointmentService>();
            services.AddScoped<IDoctorAppointmentService, DoctorAppointmentService>();

            //BloodConsumptionRecord
            services.AddScoped<IBloodConsumptionRecordRepository, BloodConsumptionRecordRepository>();
            services.AddScoped<IBloodConsumptionRecordService, BloodConsumptionRecordService>();

            //BloodSupply
            services.AddScoped<IBloodSupplyRepository, BloodSupplyRepository>();
            services.AddScoped<IBloodSupplyService, BloodSupplyService>();

            //Room
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IDoctorRoomService, DoctorRoomService>();
            services.AddScoped<IDoctorRoomRepository, DoctorRoomRepository>();

            services.AddScoped<IPatientRoomService, PatientRoomService>();
            services.AddScoped<IPatientRoomRepository, PatientRoomRepository>();

            //Bed
            services.AddScoped<IBedService, BedService>();
            services.AddScoped<IBedRepository, BedRepository>();
            //Building managment
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();

            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            //MapItems
            services.AddScoped<IBuildingMapService, BuildingMapService>();
            services.AddScoped<IBuildingMapRepository, BuildingMapRepository>();

            services.AddScoped<IFloorMapService, FloorMapService>();
            services.AddScoped<IFloorMapRepository, FloorMapRepository>();

            services.AddScoped<IRoomMapService, RoomMapService>();
            services.AddScoped<IRoomMapRepository, RoomMapRepository>();

            services.AddScoped<IAppointmentService, AppointmentService>();

            //Doctor Vacations
            services.AddScoped<IVacationRepository, VacationRepository>();
            services.AddScoped<IVacationService, VacationService>();

            services.AddScoped<IAdmissionRepository, AdmissionRepository>();
            services.AddScoped<IAdmissionService, AdmissionService>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<IMoveEquipmentAppointmentRepository, MoveEquipmentAppointmentRepository>();
            services.AddScoped<IMoveEquipmentAppointmentService, MoveEquipmentAppointmentService>();

            services.AddScoped<IEquipmentToMoveRepository, EquipmentToMoveRepository>();
            services.AddScoped<IEquipmentToMoveService, EquipmentToMoveService>();
            
            services.AddScoped<IAdmissionHistoryRepository, AdmissionHistoryRepository>();
            services.AddScoped<IAdmissionHistoryService, AdmissionHistoryService>();

            services.AddScoped<IMedicalRecordService, MedicalReportService>();

            //Medicines
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineService, MedicineService>();

            //Symptoms
            services.AddScoped<ISymptomRepository, SymptomRepository>();
            services.AddScoped<ISymptomService, SymptomService>();

            //Reports
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();

            //Treatment
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<ITreatmentService, TreatmentService>();

            //Renovation
            services.AddScoped<IRenovationAppointmentRepository, RenovationAppointmentRepository>();
            services.AddScoped<IRenovationAppointmentService, RenovationAppointmentService>();


            //Hosted Service
            services.AddSingleton<ITaskSettings<ReportSendingTask>>(new TaskSettings<ReportSendingTask>(@" */15 * * * *", TimeZoneInfo.Local));
            services.AddHostedService<ReportSendingTask>();

            services.AddSingleton<ITaskSettings<FinishRenovationTask>>(new TaskSettings<FinishRenovationTask>(@" */15 * * * *", TimeZoneInfo.Local));
            services.AddHostedService<FinishRenovationTask>();

            services.AddScoped<IConsumer<BloodSupply>, BloodSupplyStateConsumer>();

            //Consilium
            services.AddScoped<IConsiliumRepository, ConsiliumRepository>();
            services.AddScoped<IConsiliumService, ConsiliumService>();

            //Report
            services.AddScoped<IMedicalAppointmentReportService, MedicalAppointmentReportService>();

            //Medical appointment scheduling session
            services.AddScoped<IMedicalAppointmentSchedulingSessionRepository, MedicalAppointmentSchedulingSessionRepository>();
            services.AddScoped<IMedicalAppointmentSchedulingEventSourcingService, MedicalAppointmentSchedulingEventSourcingService>();
            services.AddScoped<IMedAppSchedulingStatisticsService, MedAppSchedulingStatisticsService>();

            //Medical appointment report session
            services.AddScoped<IMedicalAppointmentReportSessionRepository, MedicalAppointmentReportSessionRepository>();
            services.AddScoped<IMedicalAppointmentReportEventSourcingService, MedicalAppointmentReportEventSourcingService>();
            services.AddScoped<IMedAppReportStatisticsService, MedAppReportStatisticsService>();


            //Renovation session
            services.AddScoped<IRenovationSessionService, RenovationSessionService>();
            services.AddScoped<IRenovationSessionAggregateRootRepository, RenovationSessionAggregateRootRepository>();
            services.AddScoped<IRenovationSessionEventRepository, RenovationSessionEventRepository>();
            services.AddScoped<IRenovationSessionEventService, RenovationSessionEventService>();
            services.AddScoped<IRenovationSessionStatisticsService, RenovationSessionStatisticsService>();

            //Tender Report
            services.AddScoped<ITenderReportService, TenderReportService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllers();
            });
        }
    }
}
