﻿using System.Text.Json.Serialization;
using Application;
using Application.Hubs;
using Freezone.Core.CrossCuttingConcerns.Exceptions;
using Freezone.Core.Security.JWT;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Hangfire;
using Persistence;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddDistributedMemoryCache();
//builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");
//TODO: Configuration
builder.Services.AddHangfire(config=> { config.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireServer")); });
builder.Services.AddHangfireServer();


TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Authentication: "Bearer JWT_TOKEN"
       .AddJwtBearer(opt =>
       {
           opt.SaveToken = true;
           opt.Events = new JwtBearerEvents
           {
               OnMessageReceived = context =>
               {
                   var accessToken = context.Request.Query["access_token"];

                   if (!string.IsNullOrEmpty(accessToken))
                   {
                       context.Token = accessToken;
                   }
                   return Task.CompletedTask;
               },
               OnAuthenticationFailed = context =>
               {
                   var exception = context.Exception;
                   return Task.CompletedTask;
               }
           };
           opt.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidIssuer = tokenOptions?.Issuer,
               ValidateAudience = true,
               ValidAudience = tokenOptions?.Audience,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions?.SecurityKey!)
           };
       });

builder.Services.AddHttpContextAccessor();
GlobalHost.HubPipeline.AddModule(new JwtHeaderModule());
builder.Services.AddSignalR(opt =>
{
    // SignalR Options Configuration
});
//builder.Services.AddSignalR<ChatHub>();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    /* Nesnelerin içerisinde birbirini gösteren referanslar olabilir.
     Örn. 
        User içerisinde RefreshTokens listesi bulunmakta va RefreshToken nesnelerinin referanslarını göstermektedir.
        RefreshToken nesnelerin için de de User referansı göstermektedir.

        User (referanceId: 1) 
            RefreshTokens: [
                RefreshToken (referanceId: 2)
            ]
    
        RefreshToken (referanceId: 2)
            User: User (referanceId: 1)
    
        asp.net core tarafında, JSON serileştirme işlemi sırasında sonsuz döngüye girer ve hata verir.
     */
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => {
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header Bearer şeması kullanılmaktadır. Yukarıdaki input alanına 'Bearer JWT_TOKEN' formatında giriş yapınız."
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfigureCustomExceptionMiddleware();
// Statik dosyaları host edebilmemizi sağlar.
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseHangfireDashboard("/hangfire");
app.UseAuthentication();
app.UseRouting();

app.UseCors(opt => opt.WithOrigins("http://localhost:3000").WithOrigins("http://192.168.1.33:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.UseAuthorization();

app.UseEndpoints((endpoints) =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/api/chathub");
    endpoints.MapHub<NotificationHub>("/api/notificationhub");
});


app.Run();