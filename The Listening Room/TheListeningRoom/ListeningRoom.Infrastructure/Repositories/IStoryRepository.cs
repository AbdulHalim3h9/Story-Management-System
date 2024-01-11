using ListeningRoom.Infrastructure.Entities;

namespace ListeningRoom.Infrastructure.Repositories
{
    public interface IStoryRepository : IRepository<Story, Guid>
    {
        (IList<Story> data, int total, int totalDisplay) GetStories(int pageIndex, int pageSize, string searchText, string orderby);
    }
}