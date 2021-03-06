﻿using BusinessLayer.BInterfaces;
using BusinessLayer.BModel;
using BusinessLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BooksAPIController : Controller
    {
        public class BookApiController : ApiController
        {
            IBookService bookService;
            public BookApiController(IBookService serv)
            {
                bookService = serv;
            }
            public IEnumerable<BookModel> Get()
            {
                return AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks);
            }

            public BookModel Get(int id)
            {
                return AutoMapper<BBook, BookModel>.Map(bookService.GetBook(id));
            }

            public void Post(BookModel value)
            {
                BBook newBook = AutoMapper<BookModel, BBook>.Map(value);
                bookService.CreateOrUpdate(newBook);
            }

            public void Put(int id, BookModel value)
            {
                bookService.CreateOrUpdate(AutoMapper<BookModel, BBook>.Map(value));
            }

            public void Delete(int id)
            {
                bookService.DeleteBook(id);
            }
        }
    }
}