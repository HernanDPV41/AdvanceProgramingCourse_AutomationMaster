using EquipmentMonitoring.API.Services;
using EquipmentMonitoring.Contracts.Repositories.Managers;
using EquipmentMonitoring.Persistence.Contexts;
using EquipmentMonitoring.Persistence.Repositories.Managers;

namespace EquipmentMonitoring.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          
            builder.Services.AddGrpc();

            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(Application.AssemblyReference).Assembly));

            var app = builder.Build();

            // Registrando servicios gRPC.
            app.MapGrpcService<UnitService>();

            // Registrando repositorios en la inyección de dependencias.
            builder.Services.AddSingleton("User ID =postgres;Password=qwerty;Server=localhost;Port=5432;Database=EquipmentMonitoringDB;Include Error Detail=true;");
            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddScoped<IAppRepositoryManager, AppRepositoryManager>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}