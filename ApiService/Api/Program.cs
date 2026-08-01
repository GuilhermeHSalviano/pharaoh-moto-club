using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Services;
using Entities;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

string ApiKey = builder.Configuration["ApiKey"]!;

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie( x => x.Cookie.Name = "token")
.AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters() {
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiKey))
    };
    options.Events = new JwtBearerEvents {
        OnMessageReceived = context => {
            context.Token = context.Request.Cookies["token"];
            return Task.CompletedTask;
        }
    };
});

var MyAllowedSpecificOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

if (MyAllowedSpecificOrigins == null || MyAllowedSpecificOrigins.Length == 0) {
    throw new InvalidOperationException("CorsSettings:AllowedOrigins não está configurado ou está vazio. Adicione as configurações em ApiService/appsettings.json.");
}

Console.WriteLine($"Configured CORS origins: {string.Join(", ", MyAllowedSpecificOrigins)}");

builder.Services.AddCors(options => {
    options.AddPolicy(name: "AllowedSpecificOrigins",
        policy => {
            policy.WithOrigins(MyAllowedSpecificOrigins)
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.WebHost.UseUrls("http://0.0.0.0:5000");



builder.Services.AddScoped<MemberServices>();
builder.Services.AddScoped<Comment>();
builder.Services.AddScoped<TypeOfEvent>();
builder.Services.AddScoped<Event>();
builder.Services.AddScoped<EventAttendant>();
builder.Services.AddScoped<EventServices>();
builder.Services.AddScoped<EditEvent>();
builder.Services.AddScoped<CommentServices>();
builder.Services.AddScoped<EventAttendantServices>();
builder.Services.AddScoped<TypeOfEventServices>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowedSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
