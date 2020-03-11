using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dictionary
{
    using Dictionary.Interfaces;
    using Middleware;
    using Dictionary.Models;
    using Microsoft.OpenApi.Models;
    using Repositories;
    using Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddRouting();
            services.AddControllers();
            services.AddSwaggerGen(
                c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dictionary API", Version = "V1" }); });
            services.AddScoped<ITermService, TermService>();
            services.AddScoped<IDataSeeder, DataSeeder>();
            services.AddScoped<ITermRepository, TermRepository>();
            services.AddTransient<ExceptionHandleMiddleware>();
            services.AddSingleton<MongoDbContext>();

            // bind mongo setting
            var mongoSettings = new MongoDatabaseSettings();
            Configuration.Bind("Mongo", mongoSettings);
            services.AddSingleton<IMongoDatabaseSettings>(mongoSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDataSeeder dataSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(
                c => c.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());
            app.UseMiddleware<ExceptionHandleMiddleware>();
            app.UseRouting();
            app.UseEndpoints(
                o => { o.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dictionary V1"));
            dataSeeder.SeedDatabase();
        }
    }
}