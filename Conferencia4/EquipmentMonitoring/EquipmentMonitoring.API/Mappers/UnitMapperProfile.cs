using EquipmentMonitoring.GrpcProtos;

namespace EquipmentMonitoring.API.Mappers
{
    public static class UnitMapperProfile
    {
        // Conversión de Unit a UnitDTO
        public static UnitDTO Map(this Domain.Entities.Unit unit) 
        {
            return new UnitDTO()
            {
                Id = unit.Id.ToString(),
                Name = unit.Name,
                Code = unit.Code.Value,
                Sate = (EquipmentStateDTO)unit.State,
                ActiveOperationId = unit.ActiveOperationId.ToString(),
            };
        }

        public static UnitsDTO Map(this IEnumerable<Domain.Entities.Unit> list)
        {
            var dto = new UnitsDTO();
            dto.Items.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}
