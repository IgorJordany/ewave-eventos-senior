namespace Eventos.Infrastructure.Abstractions
{
    public interface IUow
    {
        void Commit();
    }
}