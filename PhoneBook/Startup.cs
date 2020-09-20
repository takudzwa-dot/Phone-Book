using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Api.Services;
using PhoneBook.Data.Context;

namespace PhoneBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public const string CORSPOLICY_ALLOWSPECIFIC = "allowspecific";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PhoneBookContext>(
                opt => opt.UseNpgsql(Configuration.GetConnectionString("PhoneBookContext"))
                );
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IPhoneBookService, PhoneBookService>();
            services.AddScoped<IEntryService, EntryService>();

            services.AddCors(options =>
            {
                options.AddPolicy(CORSPOLICY_ALLOWSPECIFIC, builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();                
                });
            });

            services.AddOpenApiDocument(cfg =>
            {
                cfg.PostProcess = doc =>
                {
                    doc.Info.Title = "PhoneBook API";
                    doc.Info.Version = "v1.0";
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(CORSPOLICY_ALLOWSPECIFIC);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            if (Configuration.GetValue<bool>("DisplaySwagger"))
                app.UseSwaggerUi3();
        }
    }
}
