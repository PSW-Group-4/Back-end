using HospitalAPI.Mapper;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.BuildingManagmentMap.Repository.Implementation;
using HospitalLibrary.BuildingManagmentMap.Service.Implementation;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Feedbacks.Repository;
using HospitalLibrary.Feedbacks.Service;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.RoomsAndEqipment.Repository;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.Settings;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HospitalLibrary.SchedulingAppointment.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HospitalLibrary.Users.Service;
using HospitalLibrary.Users.Repository;
using HospitalLibrary.Allergies.Repository;
using HospitalLibrary.Core.Service;

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

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphicalEditor", Version = "v1" });
            });

            services.AddAutoMapper(typeof(MappingProfile));

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
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

            //Addeess
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();

            //Patient
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();

            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //Allergie
            services.AddScoped<IAllergieRepository, AllergieRepository>();

            //TODO Feedback
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

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
