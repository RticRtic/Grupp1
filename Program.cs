
using Grupp1.Models;
using Grupp1.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDBSettingsMovie>(builder.Configuration.GetSection("SampleMflixDb"));
builder.Services.AddSingleton<MovieDBService>();

builder.Services.Configure<MongoDBSettingsRestaurant>(builder.Configuration.GetSection("SampleRestaurants"));
builder.Services.AddSingleton<RestaurantDBService>();

builder.Services.Configure<SuppliesDBSettings>(builder.Configuration.GetSection("SuppliesDB"));
builder.Services.AddSingleton<TransactionMongoDBService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options => {
        options.SwaggerDoc("v1", new OpenApiInfo {
            Version = "v1",
            Title = "Grupp 1 API",
            Description = "An ASP.NET Core Web API for managing Movies, Restaurant and sales",
            TermsOfService = new Uri("https://ecample.com/terms"),
            Contact = new OpenApiContact {
                Name = "Grupp1",
                Url = new Uri("https://example.com/contact"),

            },
            License = new OpenApiLicense {
                Name = "Example License",
                Url = new Uri("https://example.com/license")
            }
        });

        // Use Reflection to build XML-filename matching of the web API project.
        var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
       
    });

  


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => {
        options.SerializeAsV2 = true;

    });
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
 
    });
    
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

