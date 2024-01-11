using ListeningRoom.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListeningRoom.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Story> Stories { get; set; }
    }
}