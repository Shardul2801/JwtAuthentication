using JwtBackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
 
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
 
 
 
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
// builder.Services.AddCors(options=>
// {
//     options.AddPolicy("MyPolicy",builder=>builder.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyMethod()
//     .AllowAnyHeader().AllowCredentials()
//     );
// });

builder.Services.AddCors(
    options=>{options.AddDefaultPolicy(
        builder=>{builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();}
    );
});
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(OptionsBuilderConfigurationExtensions=>{
OptionsBuilderConfigurationExtensions.UseSqlServer(builder.Configuration.GetConnectionString("myconn"));
});
 
builder.Services.AddAuthentication(x=>{
    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x=>{
    x.RequireHttpsMetadata=false;
    x.SaveToken=true;
    x.TokenValidationParameters=new TokenValidationParameters{
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ltimindtree...............")),
        ValidateAudience=false,
        ValidateIssuer=false,
        ClockSkew=TimeSpan.Zero
    };
});
 
 
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
 
app.UseCors();
 
app.UseAuthentication();
 
app.UseAuthorization();
 
app.MapControllers();
 
app.Run();