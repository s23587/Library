using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models.Domain
{
    public class Book
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public int pages { get; set; }
        public string author { get; set; }


    }
}
