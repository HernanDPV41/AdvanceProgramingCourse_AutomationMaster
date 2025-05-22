using FluentResults;
using MediatR;

namespace EquipmentMonitoring.Application.Common
{
    public interface ICommand
        : IRequest<Result>
    {

    }

    public interface ICommand<T>
        : IRequest<Result<T>>
    {

    }
}
