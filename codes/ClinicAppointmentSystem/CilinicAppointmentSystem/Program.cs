using CAS.Application;
using CAS.Application.Contract;
using CAS.Domain.DoctorAggregate.Repositories;
using CAS.Infrastructure.InMemoryDatabase;
using Newtonsoft.Json.Converters;

namespace CilinicAppointmentSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
        });

        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}