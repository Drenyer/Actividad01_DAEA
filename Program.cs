var builder = WebApplication.CreateBuilder(args);

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar controllers
builder.Services.AddControllers();

var app = builder.Build();

// Habilitar Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear los controllers
app.MapControllers();
app.Run();