
using Microsoft.EntityFrameworkCore;
using Wood.Application;
using Request.Infrastructure;
using System.Reflection;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JWT.Data;
using JWT.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddInfrastructure(builder.Configuration);
    
// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAplications();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddDbContext<DeliveryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };
    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = GetTokenValidationParameters(builder.Configuration);

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = (context) =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("IsTokenExpired", "true");
                    }
                    return Task.CompletedTask;
                }
            };
        });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.MapControllers();
app.Run();


    static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
    {
        return new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["JWT:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero,
        };
    } 
    
