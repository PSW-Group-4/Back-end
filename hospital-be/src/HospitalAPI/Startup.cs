using HospitalAPI.Mapper;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.BuildingManagmentMap.Repository.Implementation;
using HospitalLibrary.BuildingManagmentMap.Service.Implementation;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.RoomsAndEqipment.Repository;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HospitalLibrary.SchedulingAppointment.Service;

namespace HospitalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HospitalDb")).UseLazyLoadingProxies());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphicalEditor", Version = "v1" });
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IAddressRepository, AddressRepository>();
            //Patient
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            //Doctor
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            //Appointment
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDoctorAppointmentService, DoctorAppointmentService>();
            //Room
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();
            //MapItems
            services.AddScoped<IBuildingMapService,BuildingMapService>();
            services.AddScoped<IBuildingMapRepository,BuildingMapRepository>();

            services.AddScoped<IFloorMapService, FloorMapService>();
            services.AddScoped<IFloorMapRepository, FloorMapRepository>();

            services.AddScoped<IRoomMapService, RoomMapService>();
            services.AddScoped<IRoomMapRepository, RoomMapRepository>();

            services.AddScoped<ISchedulingService, SchedulingService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
