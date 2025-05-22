using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Domain.Types;
using EquipmentMonitoring.Domain.ValueObjects;
using EquipmentMonitoring.GrpcProtos;
using EquipmentMonitoring.Persistence.Contexts;
using EquipmentMonitoring.Persistence.Repositories.Managers;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitoring.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();

            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress(
                "http://localhost:5219",
                new GrpcChannelOptions { HttpHandler = httpHandler });

            if(channel is null)
            {
                Console.WriteLine("Cannot connect");
                return;
            }

            var client = new GrpcProtos.Unit.UnitClient(channel);

            try
            {
                client.CreateUnit(new UnitCreationDTO() { Name = "Unit1", Code = "CDF-124" });
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
