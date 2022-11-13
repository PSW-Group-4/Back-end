using IntegrationAPI.Communications;
using IntegrationAPI.Mappers;
using IntegrationLibrary.BloodBankNews.Repository;
using IntegrationLibrary.BloodBankNews.Service;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodBanks.Service;
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Integration Project", Version = "v1" });
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IPasswordHasher<BloodBank>, PasswordHasher<BloodBank>>();
            services.AddScoped<IPasswordHandler, PasswordHandler>();
            services.AddScoped<IBloodBankRepository, BloodBankRepository>();
            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddSingleton<IHostedService, NewsConsumer>();
            services.AddControllers();

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
