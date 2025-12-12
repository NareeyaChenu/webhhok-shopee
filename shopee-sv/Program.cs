using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using shopee_sv.Interfaces;
using shopee_sv.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ------------------------- MVC / JSON / Validation ------------------
builder.Services.AddControllers()
      // configure controller to use Newtonsoft as a default serializer
      .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                        = new DefaultContractResolver()
        );
builder.Services.AddControllersWithViews()
        .AddJsonOptions(options =>
          {
              options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
              options.JsonSerializerOptions.PropertyNamingPolicy = null;
          });


// ------------------------- CORS  ----------------------------
builder.Services.AddCors(options =>
        {
            options.AddPolicy("shopee-sv-cors", build =>
            {
                build.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

builder.Services.AddScoped<IForwardRequest , ForwardRequest>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("shopee-sv-cors");

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
