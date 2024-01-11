using ListeningRoom.Infrastructure.BusinessObjects;

namespace ListeningRoom.Infrastructure.Services
{
    public interface IStoryService
    {
        void AddStory(Story story);
        (int total, int totalDisplay, IList<Story> records) GetStories(int pageIndex, int pageSize, string searchText, string orderby);
        void DeleteStory(Guid id);
        Story GetStories(Guid id);
        void EditStories(Story story);
    }
}