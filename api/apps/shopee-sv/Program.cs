using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Newtonsoft.Json.Serialization;
using shopee_sv.DBContext;
using shopee_sv.Interfaces;
using shopee_sv.Repositories;
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



//------------------------DB Connection------------------------------

// 1. Read base connection string (without database)
string baseConn = builder.Configuration.GetConnectionString("MariaDb")!;


// 2. Define database name
string dbName = "ShopeeDB";

// 3. Create database if missing
using (var connection = new MySqlConnection(baseConn))
{
    connection.Open();

    using var cmd = new MySqlCommand(
        $"CREATE DATABASE IF NOT EXISTS `{dbName}` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;",
        connection);

    cmd.ExecuteNonQuery();
}

// 4. Build final connection string INCLUDING the database
string finalConn = $"{baseConn}Database={dbName};";

// 5. Register EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(finalConn, ServerVersion.AutoDetect(finalConn));
});




//-----------------------------DI-------------------------------------
builder.Services.AddScoped<IForwardRequest , ForwardRequest>();
builder.Services.AddScoped<IAuthorizeService , AuthorizeService>();
builder.Services.AddScoped<IShopRepository , ShopRepository>();
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
