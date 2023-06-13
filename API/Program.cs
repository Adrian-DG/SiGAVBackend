using API.Services;
using Microsoft.OpenApi.Models;

string _customPolicy = "CustomPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
	.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.GetApplicationServices(builder.Configuration, builder.Environment);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(opt => opt.AddPolicy(_customPolicy, b =>
{
	b.AllowAnyOrigin();
	b.AllowAnyMethod();
	b.AllowAnyHeader();
	// Allows to send back exports filename 
	b.WithExposedHeaders("content-disposition");
}));
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => {
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
		c.RoutePrefix = string.Empty;
	});
}
else
{
	app.UseSwagger();
	app.UseSwaggerUI(c => {
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
		c.RoutePrefix = string.Empty;
	});
}

app.UseHttpsRedirection();

app.UseCors(_customPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
