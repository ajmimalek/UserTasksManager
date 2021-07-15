using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserTasksManager.Data;
using Microsoft.OpenApi.Models;


namespace UserTasksManager
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
            //les services tels que le contexte de base de données doivent être inscrits auprès du conteneur d’injection de dépendances.
            //Le conteneur fournit le service aux contrôleurs.
            services.AddDbContext<UserTasksContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AppConnection")));
            services.AddControllers();
            services.AddScoped<IUserTasksRepo, UserTasksRepo>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "User'Tasks Manager API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserTasksContext context)
        {
            //Swagger : API Documentation
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User'Tasks Manager API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Swagger : API Documentation
                app.UseSwagger();

                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("v1/swagger.json", "User'Tasks Manager API V1");
                });
            }

            //DB will be created when launching the application
            context.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
