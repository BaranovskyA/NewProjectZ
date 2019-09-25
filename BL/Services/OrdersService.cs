using BusinessLayer.Utils;
using BusinessLayer.BInterfaces;
using BusinessLayer.BModel;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrdersService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrdersService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrUpdate(BOrders order)
        {
            if (order.Id == 0)
            {

                Orders dorder = new Orders() {BooksId= order.BooksId, UserId= order.UserId, DateOrder = order.DateOrder };
                Database.Orders.Create(dorder);
            }
            else
            {
                Orders editOrder = AutoMapper<BOrders, Orders>.Map(order);
                Database.Orders.Update(editOrder);
            }
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BOrders GetOrders(int id)
        {
            if (id != 0)
            {
                BOrders bOrder =  AutoMapper<Orders, BOrders>.Map(Database.Orders.Get,(int)id);
                bOrder.AuthorId = Database.Books.Get(bOrder.BooksId).AuthorId;
                bOrder.AuthorName = Database.Authors.Get(bOrder.AuthorId).FirstName;
                bOrder.BooksName = Database.Books.Get(bOrder.BooksId).Title;
                bOrder.UserName = Database.Users.Get(bOrder.UserId).Name;
                return bOrder;
            }
            return new BOrders();
        }

        public IEnumerable<BOrders> GetOrders()
        {
            List<BOrders> bOrder = AutoMapper<IEnumerable<Orders>, List<BOrders>>.Map(Database.Orders.GetAll);
            for(int i = 0; i < bOrder.Count; i++)
            {
                bOrder[i] = GetOrders(bOrder[i].Id);
            }
            return (IEnumerable<BOrders>) bOrder;
        }

        public bool CheckUser(int id)
        {
            Orders orders = Database.Orders.Find(i => i.UserId == id && i.DateOrder <= DateTime.Now).FirstOrDefault();
            return (orders == null) ? true : false;
        }

        public void DeleteOrder(int id)
        {
            Database.Orders.Delete(id);
            Database.Save();
        }

    }
}
