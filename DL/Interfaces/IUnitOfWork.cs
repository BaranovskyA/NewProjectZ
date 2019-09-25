using DataLayer.Entities;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> Users { get; }
        IRepository<Orders> Orders { get; }
        IRepository<Authors> Authors { get; }
        IRepository<Books> Books { get; }
        IRepository<Genre> Genre { get; }
        IRepository<LogDetail> LogDetails { get; }
        void Save();
    }
}
