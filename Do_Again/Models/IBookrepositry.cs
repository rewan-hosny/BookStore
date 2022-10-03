using System.Collections.Generic;
using System.Linq;

namespace Do_Again.Models
{
    public interface IBookrepositry
    {

        Book GetBook(int Id);
        IEnumerable<Book> GetAllBooks();
        Book Add(Book book);
        Book Update(Book bookchanges);
        Book Delete(int id);
        List<TypeOfBook> GetAllCategory();
        TypeOfBook GetCategory(int id);
        IQueryable<Book> GetbookByCategory(int categoryid);
        List<Book> Search(string term);
    }
}
