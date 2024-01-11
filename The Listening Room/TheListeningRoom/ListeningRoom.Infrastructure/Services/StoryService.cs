using Humanizer.Localisation;
using ListeningRoom.Infrastructure.DbContexts;
using ListeningRoom.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryBO = ListeningRoom.Infrastructure.BusinessObjects.Story;
using StoryEO = ListeningRoom.Infrastructure.Entities.Story;

namespace ListeningRoom.Infrastructure.Services
{
    public class StoryService : IStoryService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public StoryService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public void AddStory(StoryBO story)
        {
            //course.SetProperClassStartDate();

            StoryEO storyEntity = new StoryEO();
            storyEntity.Title = story.Title;
            storyEntity.Author = story.Author;
            storyEntity.AiringDate = story.AiringDate;
            storyEntity.Rating = story.Rating;
            storyEntity.Origin = story.Origin;
            storyEntity.Genre = story.Genre;
            storyEntity.Length = story.Length;

            _applicationUnitOfWork.Stories.Add(storyEntity);
            _applicationUnitOfWork.Save();
        }
        public void DeleteStory(Guid id)
        {
            _applicationUnitOfWork.Stories.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public void EditStories(StoryBO story)
        {
            var storyEO = _applicationUnitOfWork.Stories.GetById(story.Id);
            if (storyEO != null)
            {
                storyEO.Author = story.Author;
                storyEO.AiringDate = story.AiringDate;
                storyEO.Origin = story.Origin;
                storyEO.Rating = story.Rating;
                storyEO.Genre = story.Genre;
                storyEO.Length = story.Length;
                storyEO.Title = story.Title;

                _applicationUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Not found");
        }

        public (int total, int totalDisplay, IList<StoryBO> records) GetStories(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<StoryEO> data, int total, int totalDisplay) results = _applicationUnitOfWork
                .Stories.GetStories(pageIndex, pageSize, searchText, orderby);

            IList<StoryBO> stories = new List<StoryBO>();
            foreach (StoryEO storyEO in results.data)
            {
                stories.Add(new StoryBO
                {
                    Id = storyEO.Id,
                    Author = storyEO.Author,
                    AiringDate = storyEO.AiringDate,
                    Origin = storyEO.Origin,
                    Rating = storyEO.Rating,
                    Genre = storyEO.Genre,
                    Length = storyEO.Length,
                    Title = storyEO.Title
                });
            }

            return (results.total, results.totalDisplay, stories);
        }

        public StoryBO GetStories(Guid id)
        {
            var storyEO = _applicationUnitOfWork.Stories.GetById(id);

            var storyBO = new StoryBO
            {
                Author = storyEO.Author,
                AiringDate = storyEO.AiringDate,
                Origin = storyEO.Origin,
                Rating = storyEO.Rating,
                Genre = storyEO.Genre,
                Length = storyEO.Length,
                Title = storyEO.Title
            };

            return storyBO;
        }
    }
}