using BusinessLayer.BInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using BusinessLayer.Utils;
using BusinessLayer.BModel;

namespace WebApplication1.Controllers
{
    public class OrdersAPIController : ApiController
    {
        IOrderService orderService;

        public OrdersAPIController(IOrderService serv)
        {
            orderService = serv;
        }
        public IEnumerable<AuthorBook> Get()
        {
            return AutoMapper<IEnumerable<BOrders>, List<AuthorBook>>.Map(orderService.GetOrders);
        }

        public AuthorBook Get(int id)
        {
            return AutoMapper<BOrders, AuthorBook>.Map(orderService.GetOrders, id);
        }

        public void Post(AuthorBook value)
        {
            orderService.CreateOrUpdate(AutoMapper<AuthorBook, BOrders>.Map(value));
        }

        public void Put(int id, AuthorBook value)
        {
            value.Id = id;
            orderService.DeleteOrder(id);
            orderService.CreateOrUpdate(AutoMapper<AuthorBook, BOrders>.Map(value));
        }

        public void Delete(int id)
        {
            orderService.DeleteOrder(id);
        }
    }
}
