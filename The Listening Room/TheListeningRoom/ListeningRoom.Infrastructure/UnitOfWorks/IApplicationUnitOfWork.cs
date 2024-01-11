using ListeningRoom.Infrastructure.Repositories;

namespace ListeningRoom.Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IStoryRepository Stories { get; }
    }
}