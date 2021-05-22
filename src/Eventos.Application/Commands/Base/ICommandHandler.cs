using System.Threading.Tasks;

namespace Eventos.Application.Commands.Base
{
    public interface ICommandHandler<TCommand, TResponse>
        : ICommandoHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
    }
    public interface ICommandoHandler<in TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        Task<TResponse> Handler(TRequest command);
    }
}