using Microsoft.EntityFrameworkCore;
using EFCore6.Bal;
using EFCore6.Dal;
using System.Reflection;

namespace EFCore6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper((options) =>
            {
                options.AllowNullCollections = true; // Define null as default value of collection
            }, Assembly.GetExecutingAssembly());
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                options.UseInMemoryDatabase("InMemoryDB1");             // InMemory database
                //options.UseSqlServer("name=DefaultOracleConnection"); // Oracle SQL database
            }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);
            builder.Services.AddScoped<StudentsBal>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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