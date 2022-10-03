using Do_Again.Models;

namespace Do_Again.viewModels
{
    public class CreateOrder
    {
        public Book Book { get; set; }
        public string Title { get; set; }
        public int bookId { get; set; }
        public int userid { get; set; }

    }
}
