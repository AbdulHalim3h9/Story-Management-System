using Autofac;
using ListeningRoom.Infrastructure.Services;
using ListeningRoom.Web.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Formats.Asn1.AsnWriter;

namespace ListeningRoom.Web.Areas.Admin.Models
{
    public class StoryListModel : BaseModel
    {
        private IStoryService? _storyService;

        public StoryListModel(IStoryService storyService)
        {
            _storyService = storyService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _storyService = _scope.Resolve<IStoryService>();
        }

        internal object? GetPagedStories(DataTablesAjaxRequestModel model)
        {

            var data = _storyService?.GetStories(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Title", "Genre", "Author", "Origin", "Length", "Rating", "AiringDate" }));

            return new
            {
                recordsTotal = data?.total,
                recordsFiltered = data?.totalDisplay,
                data = (from record in data?.records
                        select new string[]
                        {
                                record.Title,
                                record.Genre,
                                record.Author,
                                record.Origin,
                                record.Length.ToString(),
                                record.Rating.ToString(),
                                record.AiringDate.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeleteStory(Guid id)
        {
            _storyService?.DeleteStory(id);
        }
    }
}

