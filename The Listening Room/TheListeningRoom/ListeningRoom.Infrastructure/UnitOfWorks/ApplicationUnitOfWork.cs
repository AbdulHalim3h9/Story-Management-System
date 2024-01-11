using ListeningRoom.Infrastructure.DbContexts;
using ListeningRoom.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeningRoom.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IStoryRepository Stories { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IStoryRepository storyRepository) : base((DbContext)dbContext)
        {
            Stories = storyRepository;
        }
    }
}
