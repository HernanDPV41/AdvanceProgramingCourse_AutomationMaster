using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Errors;
using FluentResults;

namespace EquipmentMonitoring.Domain.Rules
{
    public record IPAddressMustHaveFourSeparators(
        string IPAddress)
        : IBusinessRule
    {
        public Result CheckRule()
        {
            if (IPAddress.Split('.').Count() != 4)
                return Result.Fail(NetworkAddressErrors.InvalidIPAddressFormat);
            return Result.Ok();
        }
    }

    public record IPAddressMustHaveValidValues(
        string IPAddress)
        : IBusinessRule
    {
        public Result CheckRule()
        {
            var ipValues = IPAddress.Split(".");
            foreach (var value in ipValues)
            {
                if (!int.TryParse(value, out int numericValue))
                    return Result.Fail(NetworkAddressErrors.InvalidIPAddressFormat);
                if (numericValue < 0 || numericValue > 255)
                    return Result.Fail(NetworkAddressErrors.InvalidIPAddressFormat);
            }
            return Result.Ok();
        }
    }

    public record PortMustBeInAValidRange(
        int Port)
       : IBusinessRule
    {
        public Result CheckRule()
        {
            if (Port < 1023 || Port > 65.535)
                return Result.Fail(NetworkAddressErrors.InvalidPort);
            return Result.Ok();
        }
    }
}
