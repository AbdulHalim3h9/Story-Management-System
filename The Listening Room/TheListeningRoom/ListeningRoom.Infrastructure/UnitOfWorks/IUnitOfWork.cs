using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListeningRoom.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
