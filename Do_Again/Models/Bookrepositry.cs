using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Do_Again.Models
{
    public class Bookrepositry : IBookrepositry
    {
        private ourAppContext context;
        public Bookrepositry(ourAppContext context)
        {
            this.context = context;

        }
        public Book Add(Book book)
        {
            context.Book.Add(book); 
            context.SaveChanges();
            return book;    
        }

        public Book Delete(int id)
        {
            Book book = context.Book.Find(id);
            if (book != null)
            {
                var r = context.Book.Include(e => e.ShoppingCartItems).Include(a=>a.orders).Where(e=>e.Id==id).First();
                context.Remove(r);
                context.SaveChanges();  
                
            }
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Book;
        }

      

        public Book GetBook(int Id)
        {
            return context.Book.Find(Id);
        }

        public IQueryable<Book> GetbookByCategory(int categoryid)
        {
            return context.Book.Where(i => i.TypeofbookId == categoryid);
        }

        public TypeOfBook GetCategory(int id)
        {
           return context.TypeOfBooks.Find(id);
        }

        public List<Book> Search(string term)
        {
            return context.Book.Where(i=>i.Name.Contains(term)).ToList();
        }

        public Book Update(Book bookchanges)
        {
            var book = context.Book.Attach(bookchanges);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookchanges;
        }

        List<TypeOfBook> IBookrepositry.GetAllCategory()
        {
            return context.TypeOfBooks.ToList();
        }
    }
}
