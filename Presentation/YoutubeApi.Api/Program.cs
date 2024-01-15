var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

var app = builder.Build();

//A�a��da yer alan kod block u
//yap�land�rma ayarlar�n� y�klemek i�in kullan�lan bir konfig�rasyon yap�land�rma i�lemini tan�mlar

builder.Configuration.SetBasePath(env.ContentRootPath)
	.AddJsonFile("appsettings.json", optional:false)
	.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
