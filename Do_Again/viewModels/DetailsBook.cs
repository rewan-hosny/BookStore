using Do_Again.Models;
using System.Collections.Generic;

namespace Do_Again.viewModels
{
    public class DetailsBook
    {
        public Book Book { get; set; }
        public string Title { get; set; }
        public int bookId { get; set; }
        public int TypeOfBookid { get; set; }
        public TypeOfBook categorys { get; set; }

    }
}
