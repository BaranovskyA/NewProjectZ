using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using System.IO;
using System.Text;
using BusinessLayer.BInterfaces;
using AutoMapper;
using BusinessLayer.BModel;
using WebApplication1.Models;
using BusinessLayer;
using BusinessLayer.Utils;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        IOrderService orderService;
        IUserService userService;
        IBookService bookService;
        public OrdersController(IOrderService serv, IUserService serv2, IBookService serv3)
        {
            orderService = serv;
            userService = serv2;
            bookService = serv3;
        }

        public ActionResult Index()
        {
            return View(AutoMapper<IEnumerable<BOrders>,List<AuthorBook>>.Map(orderService.GetOrders));
        }

        public ActionResult CreateOrEdit(int? id=0)
        {
            ViewBag.date = DateTime.Now.ToString();
            List<BookModel> books = AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks);
            List<UserModel> users = AutoMapper<IEnumerable<BUsers>, List<UserModel>>.Map(userService.GetUsers);

            if (id == null) { 
                ViewBag.books = new SelectList(books, "Id", "Title");          
                ViewBag.users = new SelectList(users, "Id", "Name");
                return View(new AuthorBook());
            }
            else
            {
                AuthorBook orders = AutoMapper<BOrders, AuthorBook>.Map(orderService.GetOrders,(int)id);
                ViewBag.books = new SelectList(books, "Id", "Title", orders.BooksId);
                ViewBag.users = new SelectList(users, "Id", "Name", orders.UserId);
                return View(orders);
            }
        }

        [Logger]
        [HttpPost]
        public ActionResult CreateOrEdit(AuthorBook orders)
        {
            List<BookModel> books = AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks);
            List<UserModel> users = AutoMapper<IEnumerable<BUsers>, List<UserModel>>.Map(userService.GetUsers);

            if (orders.DateOrder == null || orders.DateOrder < DateTime.Now)
            {

                ViewBag.books = new SelectList(books, "Id", "Title", orders.BooksId);
                ViewBag.users = new SelectList(users, "Id", "Name", orders.UserId);
                ViewBag.error = "Дата заказа должна соответствовать реальности.";
                return View(orders);
            }

            BOrders bOrders = AutoMapper<AuthorBook,BOrders>.Map(orders);

            if (orderService.CheckUser(orders.UserId))
            {
                orderService.CreateOrUpdate(bOrders);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Данный пользователь должен книгу библиотеке!";
                ViewBag.BooksId = new SelectList(books, "Id", "Title", orders.BooksId);
                ViewBag.UserId = new SelectList(users, "Id", "Name", orders.UserId);
                return View();
            }
        }

        [Logger]
        public ActionResult Delete(int id)
        {
            orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }

        [Logger]
        public ActionResult Debtors()
        {
            List<AuthorBook> dolj = AutoMapper<IEnumerable<BOrders>, List<AuthorBook>>.Map(orderService.GetOrders).Where(i => i.DateOrder < DateTime.Now).ToList();

            StringBuilder sb = new StringBuilder();
            string header = "#\tUser\tAuthor\tBook\tReturn";
            sb.Append(header);
            sb.Append("\r\n\r\n");
            sb.Append('-',header.Length*2);
            sb.Append("\r\n\r\n");
            foreach (var item in dolj)
            {
                sb.Append((dolj.IndexOf(item) + 1) + "\t" + item.UserName + "\t" + item.AuthorName + "\t" + item.BooksName+"\t"+item.DateOrder.Date+"\r\n");
            }
            byte[] data = Encoding.ASCII.GetBytes(sb.ToString());

            string contentType = "text/plain";
            return File(data, contentType, "orders.txt");
        }

        [Logger]
        public ActionResult Link(int id)
        {
            BUsers user = userService.GetUser(id);
            MailAddress from = new MailAddress("1423demon@mail.ru", "Reader's Club");
            MailAddress to = new MailAddress(user.Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Просроченная книга";
            m.Body = string.Format("<h2>Уважаемый" + user.Name + ", Вы просрочили срок сдачи книги! Вы заведены в список должников до того момента, пока не вернете книгу.</h2>");
            m.IsBodyHtml = true;
            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new System.Net.NetworkCredential("1423demon@mail.ru", "засекречено");
            smtp.EnableSsl = true;
            smtp.Send(m);
            return RedirectToAction("Index");
        }
    }
}
