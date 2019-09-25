using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BInterfaces
{
    public interface IAuthorService
    {
        void CreateOrUpdate(BAuthor author);
        BAuthor GetAuthor(int id);
        IEnumerable<BAuthor> GetAuthors();
        void DeleteAuthor(int id);
        BAuthor GetForName(string name);
        void Dispose();
    }
}
