
using Asp.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<Dataaccess.Models.AppDb>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Constr"));
            });


            //api versioning dependency
            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true; // if no version is specied the application will exe default method 
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0); // if verison id specid this will execute
                options.ReportApiVersions = true;  // responce header inluces supported version
            }).AddMvc(o =>
            {
                o.Conventions.Add(new VersionByNamespaceConvention()); //version controller based on their namespace
            }).AddApiExplorer(x =>
            {
                x.GroupNameFormat = "'v'V";
                x.SubstituteApiVersionInUrl = true; // this helpful for swagger
            });

            builder.Services.AddScoped<Dataaccess.IService.IUsers, Dataaccess.Services.UsersService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
