using System.Text;
using ApiAuth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


var Key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin=", policy => policy.RequireRole("manager"));
    options.AddPolicy("Employee=", policy => policy.RequireRole("employee"));
});




var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
