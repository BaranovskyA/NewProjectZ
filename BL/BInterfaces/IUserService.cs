using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUserService
    {
        void CreateOrUpdate(BUsers user);
        BUsers GetUser(int id);
        IEnumerable<BUsers> GetUsers();
        List<BOrders> GetReturnBooks(int id);
        void DeleteUser(int id);
        void Dispose();
    }
}
