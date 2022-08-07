using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Api.Configurations;
using Posterr.Application.AutoMapper;
using Posterr.Infrastructure.Data.Context;
using Posterr.Shared.Kernel.Entity;
using Posterr.Infrastructure.InversionOfControl;

namespace Posterr.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
            });

            services.AddDbContext<PosterrContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("PosterrConnection")
                )
            );
            AutoMapperConfig.RegisterMappings();
            services.AddSwagger();
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            services.AddMvc();
            services.AddLogging();
            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(Startup));

            services.RegisterServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.AddMiddlewares();
            app.UseSwaggerSetup();

            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.AddMigration<PosterrContext>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
        }
    }
}
