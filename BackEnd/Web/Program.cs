using Application.Queries;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BookingDbContext>(
                options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEventInstancesRepository, EventInstancesRepository>();
            builder.Services.AddScoped<ISeatsRepository, SeatsRepository>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetEventsByDateRangeQuery).Assembly));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowSpecifcOrigin",
                                  policy =>
                                  {
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyHeader();
                                  });
            });

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("AllowSpecifcOrigin");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}