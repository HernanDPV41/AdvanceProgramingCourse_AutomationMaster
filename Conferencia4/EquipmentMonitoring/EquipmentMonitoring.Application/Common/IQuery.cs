using FluentResults;
using MediatR;

namespace EquipmentMonitoring.Application.Common
{
    public interface IQuery<T>
        : IRequest<Result<T>>
    {

    }
}
