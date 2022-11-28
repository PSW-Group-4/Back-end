using System;
using IntegrationAPI.Authorization;
using IntegrationAPI.Mappers;
using IntegrationAPI.Dtos;
using IntegrationLibrary.BloodBankNews.Repository;
using IntegrationLibrary.BloodBankNews.Service;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Service;
using IntegrationLibrary.Settings;
using IntegrationLibrary.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodReport.Service;
using IntegrationLibrary.BloodReport.Repository;
using IntegrationLibrary.BloodUsages.Service;
using IntegrationLibrary.ReportConfigurations.Service;
using Microsoft.AspNetCore.Mvc;
using IntegrationAPI.HostedServices;
using IntegrationAPI.Dtos.ReportsConfiguration;
using Confluent.Kafka;
using IntegrationAPI.Communications.Mail;
using IntegrationAPI.Communications.Consumer;
using IntegrationAPI.Communications.Producer;
using IntegrationLibrary.BloodRequests.Model;

namespace IntegrationAPI
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
            services.AddDbContext<IntegrationDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("IntegrationDb")).UseLazyLoadingProxies());

            services.AddControllers();
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


            services.AddScoped<ExternalAuthorizationFilter>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IPasswordHasher<BloodBank>, PasswordHasher<BloodBank>>();
            services.AddScoped<IConverter<News, NewsDto>, NewsConverter>();
            services.AddScoped<IPasswordHandler, PasswordHandler>();
            services.AddScoped<IBloodBankRepository, BloodBankRepository>();
            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();
            services.AddScoped<IBloodRequestService, BloodRequestService>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<IBbReportConfigRepository, BbReportConfigRepository>();
            services.AddScoped<IBbReportConfigService, BbReportConfigService>();
            services.AddScoped<IBloodUsageService, BloodUsageService>();
            services.AddScoped<IBloodUsageRepository, BloodUsageRepository>();
            services.AddScoped<IBbReportService, BbReportService>();
            services.AddScoped<IBbReportRepository, BbReportRepository>();
            services.AddScoped<IConverter<ReportConfiguration, ReportConfigurationDto>, ReportConfigurationConverter>();
            services.AddScoped<IConsumer<News>, NewsConsumer>();
            services.AddScoped<IProducer<BloodRequest>, BloodRequestProducer>();


            services.AddControllers();

     
            services.AddSingleton<ITaskSettings<ReportSendingTask>>(new TaskSettings<ReportSendingTask>(@" */1 * * * *", TimeZoneInfo.Local));
            services.AddHostedService<ReportSendingTask>();
           
                //@"* 0 4 * * *"
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
