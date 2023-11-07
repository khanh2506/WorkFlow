using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlow.Models
{
    public class Ghichu
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public DateTime DateTime { get; set; }
    }
}