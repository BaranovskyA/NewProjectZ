using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoggerModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 6)]
        public string Message { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string StackTrace { get; set; }
        public DateTime Date { get; set; }
    }
}