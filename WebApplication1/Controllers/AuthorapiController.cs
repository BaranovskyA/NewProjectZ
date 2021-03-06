﻿using BusinessLayer.BInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Utils;
using BusinessLayer.BModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuthorAPIController : ApiController
    {
        IAuthorService authorService;
        public AuthorAPIController(IAuthorService serv)
        {
            authorService = serv;
        }
        public IEnumerable<AuthorModel> Get()
        {
            return AutoMapper<IEnumerable<BAuthor>, List<AuthorModel>>.Map(authorService.GetAuthors);
        }

        public AuthorModel Get(int id)
        {
            return AutoMapper<BAuthor, AuthorModel>.Map(authorService.GetAuthor(id));
        }

        public AuthorModel Post(AuthorModel author)
        {
            BAuthor newAuthor = AutoMapper<AuthorModel, BAuthor>.Map(author);
            authorService.CreateOrUpdate(newAuthor);
            return AutoMapper<BAuthor, AuthorModel>.Map(authorService.GetForName(author.FirstName));
        }

        public void Delete(int id)
        {
            authorService.DeleteAuthor(id);
        }
    }
}
