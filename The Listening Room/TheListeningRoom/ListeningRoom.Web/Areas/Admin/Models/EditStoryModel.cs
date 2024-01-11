using Autofac;
using ListeningRoom.Infrastructure.BusinessObjects;
using ListeningRoom.Infrastructure.Services;
using ListeningRoom.Web.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace ListeningRoom.Web.Areas.Admin.Models
{
    public class EditStoryModel : BaseModel
    {
        private IStoryService _storyService;

        public Guid Id { get; set; }
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

        public EditStoryModel() : base()
        {

        }

        public EditStoryModel(IStoryService storyService)
        {
            _storyService = storyService;
        }

        internal void LoadData(Guid id)
        {
            var story = _storyService.GetStories(id);
            if(story != null)
            {
                Id = story.Id;
                Title = story.Title;
                Author = story.Author;
                AiringDate = story.AiringDate;
                Length = story.Length;
                Genre = story.Genre;
                Origin = story.Origin;
                Rating = story.Rating;
            }
        }

        internal void EditCourse()
        {
            Story story = new()
            {
                Id = Id,
                Title = Title,
                Author = Author,
                AiringDate = AiringDate,
                Length = Length,
                Genre = Genre,
                Origin = Origin,
                Rating = Rating
            };
            _storyService.EditStories(story);
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _storyService = _scope.Resolve<IStoryService>();
        }
    }
}
