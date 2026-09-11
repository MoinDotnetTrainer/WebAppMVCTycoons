using Dataaccess.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVCRepos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<AppDb>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Constr"));
            });


            // DI
            builder.Services.AddScoped<Dataaccess.IService.IUsers, Dataaccess.Services.UsersService>();
            builder.Services.AddScoped<Dataaccess.IService.IValidate, Dataaccess.Services.ValidateService>();
            builder.Services.AddScoped<Dataaccess.IService.IRelation, Dataaccess.Services.RelationService>();
            builder.Services.AddScoped<Dataaccess.IService.IUsersSp, Dataaccess.Services.UsersServiceSp>();


            // Line line of Ur instance
            builder.Services.AddTransient<Dataaccess.IService.ITransient, Dataaccess.Services.TaskService>();
            builder.Services.AddScoped<Dataaccess.IService.Iscoped, Dataaccess.Services.TaskService>();
            builder.Services.AddSingleton<Dataaccess.IService.Isingleton, Dataaccess.Services.TaskService>();


            // cookies --> single

            //session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=UsersOps}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
