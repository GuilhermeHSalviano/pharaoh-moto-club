using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ElectionBackgroundService;
using Services;
using Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ry74cBQva5dThwbwchR9jhbtRFnJxWSZ"))
    };
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder => {
            builder.WithOrigins("http://localhost:5173",
                                "https://pharaoh-moto-club.netlify.app/")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<ElectionServices>();
builder.Services.AddScoped<VotesServices>();
builder.Services.AddScoped<CandidacyServices>();
builder.Services.AddScoped<ElectionCountingServices>();
builder.Services.AddScoped<EditElection>();
builder.Services.AddScoped<MemberServices>();
builder.Services.AddScoped<Comment>();
builder.Services.AddScoped<TypeOfEvent>();
builder.Services.AddScoped<Event>();
builder.Services.AddScoped<EventAttendant>();
builder.Services.AddScoped<EventServices>();
builder.Services.AddScoped<EditEvent>();
builder.Services.AddScoped<CommentServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
