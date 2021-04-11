using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Data.Abstract;
using CourseApp.Data.Concrete;
using CourseApp.Models;
using CourseApp.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace CourseApp
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<CourseContext>(options =>

                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging()
            );

           services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection2")));

            //IRepository talep edilirse EfRepository yollamak icin
            //Burada farklı service tiplerini ogrenmem gerekiyor
            services.AddTransient<ICourseRepository, EfRepository>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IInstructorRepostiory, InstructorRepo>();
            services.AddTransient<IGenericRepository<Contact>, GenericRepository<Contact>>();
            services.AddTransient<IGenericRepository<Adres>, GenericRepository<Adres>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CourseContext Ccontext, UserContext userContext)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed(Ccontext);
                SeedDatabase.Seed(userContext);
                app.UseMvc(routes =>
                {
                    routes.MapRoute("myroute", "{controller=Course}/{action=Index}/{id?}");
                });

            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            //If I decide to use npm as package manager this is the approach to use.
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
            //    RequestPath = new PathString("/vendor")

            //});

            //contoller/action/id?
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("myroute", "{controller=Course}/{action=Index}/{id?}");
            //});

        }
    }
}
