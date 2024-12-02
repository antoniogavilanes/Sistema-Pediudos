var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de servicios
builder.Services.AddControllers(); // Añadir soporte para controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger para documentar la API

// Configuración de DbContext (Base de Datos)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Construir la aplicación
var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();    // Swagger para documentación de API
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirección HTTPS
app.UseAuthorization();    // Manejo de autorizaciones

app.MapControllers();      // Mapeo de controladores

app.Run(); // Iniciar la aplicación
