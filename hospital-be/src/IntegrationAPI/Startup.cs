using System;
using System.Collections.Generic;
using System.Text;
using IntegrationAPI.Authorization;
using IntegrationAPI.Mappers;
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
using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.BloodSubscriptions.Service;
using IntegrationLibrary.BloodSubscriptions.Repository;
using IntegrationLibrary.TenderApplications.Service;
using IntegrationLibrary.TenderApplications.Repository;
using IntegrationAPI.Communications.Mail;
using IntegrationAPI.Communications.Consumer;
using IntegrationAPI.Communications.Producer;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationAPI.Communications.Consumer.BloodBankNews;
using IntegrationAPI.Dtos;
using IntegrationAPI.Communications.Consumer.BloodRequestResponse;
using HospitalLibrary.BloodSupplies.Model;
using IntegrationAPI.Communications.Consumer.ReceivedBlood;
using IntegrationLibrary.Common;
using IntegrationAPI.Communications.Producer.BloodSubscription;
using IntegrationLibrary.BloodSubscriptionResponses.Repository;
using IntegrationLibrary.BloodSubscriptionResponses.Service;
using IntegrationLibrary.ManagerBloodRequests.Repository;
using IntegrationLibrary.ManagerBloodRequests.Service;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository;
using IntegrationLibrary.Tendering.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Tendering.DomainEventStore;
using IntegrationAPI.Communications.SharedStorage;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuers = new List<string> 
                        {
                            "http://localhost:5000/",
                            "http://localhost:16177/"
                        },
                        ValidAudiences = new List<string> 
                        {
                            "http://localhost:5000/",
                            "http://localhost:16177/"
                        },
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                    options.Events = new JwtBearerEvents
                    {                        
                        OnAuthenticationFailed = async ctx => 
                        {
                            var putBreakpointHere = true;
                            var exceptionMessage = ctx.Exception;
                        },
                    };
                });
            
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IPasswordHasher<BloodBank>, PasswordHasher<BloodBank>>();
            services.AddScoped<IConverter<News, NewsDto>, NewsConverter>();
            services.AddScoped<IConverter<Tender, TenderDto>, TenderConverter>();
            services.AddScoped<IPasswordHandler, PasswordHandler>();
            services.AddScoped<IBloodBankRepository, BloodBankRepository>();
            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();
            services.AddScoped<IBloodRequestService, BloodRequestService>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<IReportConfigurationRepository, ReportConfigurationRepository>();
            services.AddScoped<IReportConfigurationService, ReportConfigurationService>();
            services.AddScoped<IBloodUsageService, BloodUsageService>();
            services.AddScoped<IBloodUsageRepository, BloodUsageRepository>();
            services.AddScoped<IBbReportService, BbReportService>();
            services.AddScoped<IBbReportRepository, BbReportRepository>();
            services.AddScoped<IConverter<ReportConfiguration, ReportConfigurationDto>, ReportConfigurationConverter>();
            services.AddScoped<ITenderRepository, TenderRepository>();
            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<IBloodSubscriptionRepository, BloodSubscriptionRepository>();
            services.AddScoped<IBloodSubscriptionService, BloodSubscriptionService>();
            services.AddScoped<ITenderApplicationService, TenderApplicationService>();
            
            services.AddScoped<ITenderApplicationRepository, TenderApplicationRepository>();
            services.AddScoped<IProducer, Producer>();
            services.AddScoped<IConsumer<News>, NewsConsumer>();
            services.AddScoped<IConsumer<BloodRequest>, BloodRequestResponseConsumer>();
            services.AddScoped<IConsumer<Blood>, BloodConsumer>();
            services.AddScoped<IBloodSubscriptionResponseRepository, BloodSubscriptionResponseRepository>();
            services.AddScoped<IBloodSubscriptionResponseService, BloodSubscriptionResponseService>();

            services.AddScoped<ISftpService, SftpService>();

            services.AddScoped<IEventStore<TenderingEvent>, TenderingEventStore>();

            services.AddScoped<IManagerRequestRepository, ManagerRequestRepository>();
            services.AddScoped<IManagerRequestService, ManagerRequestService>();
            services.AddControllers();

            services.AddSingleton<ITaskSettings<ReportSendingTask>>(new TaskSettings<ReportSendingTask>(@" */1 * * * *", TimeZoneInfo.Local));
            services.AddHostedService<ReportSendingTask>();

            // @ 2 am every 1st in month @"0 2 1 * *"
            services.AddSingleton<ITaskSettings<SubscriptionScheduler>>(new TaskSettings<SubscriptionScheduler>(@" */1 * * * *", TimeZoneInfo.Local));
            services.AddHostedService<SubscriptionScheduler>();
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
            });
        }
    }
}
