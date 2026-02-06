using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        db.Database.OpenConnection();
        db.Database.CloseConnection();
        Console.WriteLine("✅ Conexão com o PostgreSQL funcionando!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Erro ao conectar no banco:");
        Console.WriteLine(ex.Message);
    }
}

app.Run();
