using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Book
    {
        public int Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool In_Stock { get; set; }
        public bool Lendable { get; set; }
        public string Edition { get; set; }
        public string Cover_Type { get; set; }
    }
}
