using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BInterfaces
{
    public interface IBookService
    {
        void CreateOrUpdate(BBook book);
        BBook GetBook(int id);
        IEnumerable<BBook> GetBooks();
        IEnumerable<BBook> GetBooksSortGenre(int id);
        void DeleteBook(int id);
        void Dispose();
    }
}
