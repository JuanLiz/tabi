using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sieve.Services;
using Tabi.Context;
using Tabi.Helpers;
using Tabi.Model;
using Tabi.Repositories;
using Tabi.Services;
using static Tabi.Services.ICropService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add connection string to the database
builder.Services.AddDbContext<TabiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ISieveProcessor, TabiSieveProcessor>();


// Add scoped repositories
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<ICropManagementRepository, CropManagementRepository>();
builder.Services.AddScoped<ICropManagementTypeRepository, CropManagementTypeRepository>();
builder.Services.AddScoped<ICropStateRepository, CropStateRepository>();
builder.Services.AddScoped<ICropTypeRepository, CropTypeRepository>();
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IHarvestRepository, HarvestRepository>();
builder.Services.AddScoped<IHarvestPaymentRepository, HarvestPaymentRepository>();
builder.Services.AddScoped<IHarvestStateRepository, HarvestStateRepository>();
builder.Services.AddScoped<ILotRepository, LotRepository>();
builder.Services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
builder.Services.AddScoped<ISlopeTypeRepository, SlopeTypeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();


// Add scoped services
builder.Services.AddScoped<ICropService, CropService>();
builder.Services.AddScoped<ICropManagementService, CropManagementService>();
builder.Services.AddScoped<ICropManagementTypeService, CropManagementTypeService>();
builder.Services.AddScoped<ICropStateService, CropStateService>();
builder.Services.AddScoped<ICropTypeService, CropTypeService>();
builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<IHarvestService, HarvestService>();
builder.Services.AddScoped<IHarvestPaymentService, HarvestPaymentService>();
builder.Services.AddScoped<IHarvestStateService, HarvestStateService>();
builder.Services.AddScoped<ILotService, LotService>();
builder.Services.AddScoped<IPaymentTypeService, PaymentTypeService>();
builder.Services.AddScoped<ISlopeTypeService, SlopeTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();


// Authentication and authorization
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen(swagger =>
{
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}

        }
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
