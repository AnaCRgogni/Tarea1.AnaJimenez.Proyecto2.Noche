using BL.DAOs;
using BL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Acá es el punto de entrada de .NET entonces acá configuro el servicio de pictures.
//Acá también va la definición del contenedor de inyección de dependencias.
builder.Services.AddHttpClient();
builder.Services.AddScoped<PictureDao>();
builder.Services.AddScoped<PictureService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
