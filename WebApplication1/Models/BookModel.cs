﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookModel
    {
        [Required]
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set;}

        public byte[] Image { get; set; }

        public string Title { get; set; }

        public int? Pages { get; set; }

        public int? Price { get; set; }
    }
}