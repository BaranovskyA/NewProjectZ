using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class OrdersRepository : IRepository<Orders>
    {

        private Model1 db;

        public OrdersRepository(Model1 context)
        {
            this.db = context;
        }

        public void Create(Orders item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders != null)
                db.Orders.Remove(orders);
        }

        public Orders Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Orders> GetAll()
        {
            return db.Orders;
        }

        public IEnumerable<Orders> Find(Func<Orders, Boolean> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public void Update(Orders item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
