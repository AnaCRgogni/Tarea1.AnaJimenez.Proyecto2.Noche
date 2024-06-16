using BL.DAOs;
using BL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Ac� es el punto de entrada de .NET entonces ac� configuro el servicio de pictures.
//Ac� tambi�n va la definici�n del contenedor de inyecci�n de dependencias.
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
