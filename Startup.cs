using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtectYou
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /*
               endpoints.MapAreaControllerRoute(
                   name: "Post",
                   areaName: "Admin",
                   pattern: "/ {controller=Post}/{action=Index

                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=AdminHome}/{action=Index}");*/


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "About",
                    pattern: "{controller=About}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "Contact",
                    pattern: "{controller=Contact}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "Events",
                    pattern: "{controller=Events}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "Work",
                    pattern: "{controller=ourWork}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "Team",
                    pattern: "{controller=Team}/{action=Index}");

                endpoints.MapControllerRoute(
                   name: "Volunteer",
                   pattern: "{controller=Volunteer}/{action=Index}");

                        /*================Admin=================*/

                endpoints.MapControllerRoute(
                   name: "AdminHome",
                   pattern: "{controller=AdminHome}/{action=Index}");

                endpoints.MapControllerRoute(
                   name: "AdminPost",
                   pattern: "{controller=AdminPost}/{action=Index}");

                endpoints.MapControllerRoute(
                   name: "Adminlogin",
                   pattern: "{controller=AdminLogin}/{action=Login}");

                /*================Needy=================*/

                endpoints.MapControllerRoute(
                   name: "Signup_Needy_Person",
                   pattern: "{controller=NeedySignup}/{action=Signup}");

                endpoints.MapControllerRoute(
                   name: "Signin_Needy_Person",
                   pattern: "{controller=NeedySignin}/{action=Login}");

                endpoints.MapControllerRoute(
                   name: "Upload a Post",
                   pattern: "{controller=UploadPost}/{action=UploadPost}");

                /*================Donor=================*/

                endpoints.MapControllerRoute(
                   name: "DonorSignup",
                   pattern: "{controller=donorSignup}/{action=Register}");

                endpoints.MapControllerRoute(
                   name: "DonorSignin",
                   pattern: "{controller=donorSignin}/{action=Login}");

                /*================NGO=================*/

                endpoints.MapControllerRoute(
                   name: "NgoSignup",
                   pattern: "{controller=ngoSignup}/{action=Signup}");


                endpoints.MapControllerRoute(
                   name: "NgoSignup",
                   pattern: "{controller=ImageProcessing}/{action=Index}");
            });
        }
    }
}
