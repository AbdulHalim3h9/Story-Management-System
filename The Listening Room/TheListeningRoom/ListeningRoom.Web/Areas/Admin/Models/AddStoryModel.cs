using Autofac;
using ListeningRoom.Infrastructure.BusinessObjects;
using ListeningRoom.Infrastructure.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ListeningRoom.Web.Areas.Admin.Models
{
    public class AddStoryModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Origin { get; set; }
        public TimeSpan Length { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Rating Must be between 1 to 10")]
        public float Rating { get; set; }
        public DateTime AiringDate { get; set; }

        private IStoryService _storyService;
        private ILifetimeScope _scope;
        public AddStoryModel()
        {

        }

        public AddStoryModel(IStoryService storyService)
        {
            _storyService = storyService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _storyService = _scope.Resolve<IStoryService>();
        }

        internal async Task AddStory()
        {
            Story story = new()
            {
                Title = Title,
                Author = Author,
                Origin = Origin,
                Rating = Rating,
                Genre = Genre,
                AiringDate = AiringDate,
                Length = Length
            };

            _storyService.AddStory(story);
        }
    }
}
