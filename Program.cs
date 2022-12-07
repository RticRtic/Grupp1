
using Grupp1.Models;
using Grupp1.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MovieDBService>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSwaggerGen(options => {
        options.SwaggerDoc("v1", new OpenApiInfo {
            Version = "v1",
            Title = "Movie API",
            Description = "An ASP.NET Core Web API for managing Movies",
            TermsOfService = new Uri("https://ecample.com/terms"),
            Contact = new OpenApiContact {
                Name = "Janne Janneson",
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
