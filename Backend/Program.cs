using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Backend.BusinessLayer.Interface;
using Backend.BusinessLayer.Services;
using Backend.Context;
using Backend.Mappings;
using Backend.MiddleWare;
using Backend.Repository.Interface;
using Backend.Repository.Services;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Serilog
// var logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "Car_Wash.txt");
// Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)!);

// var logger = new LoggerConfiguration()
//     .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
//     .MinimumLevel.Information()
//     .CreateLogger();

// builder.Host.UseSerilog(); // Add this line

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

builder.Services.AddScoped<JwtToken>();

builder
    .Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Add database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProgramConnectionString"))
);

builder.Services.AddAutoMapper(typeof(AutoMappersProfile));

//add containers
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<CarService>();

// Register the OrderService and OrderRepository
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentReceiptRepository, PaymentReceiptRepository>();
builder.Services.AddScoped<IPaymentReceiptService, PaymentReceiptService>();
builder.Services.AddScoped<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddScoped<IPromoCodeService, PromoCodeService>();
builder.Services.AddScoped<IOrderAddOnRepository, OrderAddOnRepository>();
builder.Services.AddScoped<IOrderAddOnService, OrderAddOnService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IWasherOrderRepository, WasherOrderRepository>();
builder.Services.AddScoped<WasherOrderService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAssignOrderRepository, AssignOrderRepository>();
builder.Services.AddScoped<AssignOrderService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

//add service to conatiner
//builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
    
//Enable JWT Authorization in swagger UI
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer {token} to authenticate",
        }
    );
    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                Array.Empty<string>()
            },
        }
    );
});
builder.WebHost.UseKestrel();

//Add identity
builder
    .Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//Add Authentication (Jwt)
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(Options =>
    {
        Options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            ),
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll"); 
app.MapControllers();
app.Run();
