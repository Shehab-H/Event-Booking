using Application.Queries;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web.Config;
using Web.UserServices;

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
            builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key: "JwtConfig"));
            builder.Services.AddScoped<IEventInstancesRepository, EventInstancesRepository>();
            builder.Services.AddScoped<ISeatsRepository, SeatsRepository>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventCrudRepository, EventCrudRepository>();
            builder.Services.AddScoped<ISeatedInstanceRepository, SeatedInstanceRepository>();
            builder.Services.AddScoped<ISeatedVenueRepository, SeatedVenueRepository>();
            builder.Services.AddScoped<ISaveFile, SaveFile>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BookingDbContext>()
                ;

            builder.Services.AddAuthentication(
                configureOptions: options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                )
                .AddJwtBearer( jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(key: "JwtConfig:Secret").Value);
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true,
                        ValidateLifetime = true
                    };
                }        
                );

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
            });

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}