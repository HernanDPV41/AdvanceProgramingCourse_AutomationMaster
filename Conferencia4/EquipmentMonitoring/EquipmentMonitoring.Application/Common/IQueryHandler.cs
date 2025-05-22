using FluentResults;
using MediatR;

namespace EquipmentMonitoring.Application.Common
{
    public interface IQueryHandler<TRequest, TResponse>
        : IRequestHandler<TRequest, Result<TResponse>>
        where TRequest : IQuery<TResponse>
    {

    }
}
