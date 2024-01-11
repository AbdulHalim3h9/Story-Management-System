using ListeningRoom.Infrastructure.DbContexts;
using ListeningRoom.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeningRoom.Infrastructure.Repositories
{
    public class StoryRepository : Repository<Story, Guid>, IStoryRepository
    {
        public StoryRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
        public (IList<Story> data, int total, int totalDisplay) GetStories(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<Story> data, int total, int totalDisplay) results =
                GetDynamic(x => x.Title.Contains(searchText), orderby,
                //Topics, CourseStudents
                "", pageIndex, pageSize, true);

            return results;
        }
    }
}
