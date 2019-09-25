using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BInterfaces
{
    public interface IOrderService
    {
        void CreateOrUpdate(BOrders order);
        BOrders GetOrders(int id);
        IEnumerable<BOrders> GetOrders();
        void DeleteOrder(int id);
        bool CheckUser(int id);
        void Dispose();
    }
}
