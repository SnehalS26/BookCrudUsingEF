namespace CrudUsingEF.Models
{
    public class BookCrud
    {
        ApplicationDbContext context;
        public BookCrud(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            return context.books.Where(x=> x.IsActive == 1).ToList();

        }
        public Book GetBookById(int id)
        {
            var book = context.books.Where(x=> x.Id == id).FirstOrDefault();
            return book;
        }
        public int AddBook(Book book)
        {
            book.IsActive = 1;
            int result = 0;
            context.books.Add(book); //add new record in to the Dbset
            result = context.SaveChanges(); //update the change from Dbset to Db
            return result;
        }
        public int UpdateBook(Book book)
        {            
            int result = 0;
            var b = context.books.Where(x=> x.Id == book.Id).FirstOrDefault();
            if(b!= null)
            {
                b.Name = book.Name; //  b object contains old data book obj contains new data
                b.Author = book.Author;
                b.Price = book.Price;
                b.IsActive = 1;
                result = context.SaveChanges(); //update the change from Dbset to Db
            }
           
            return result;
        }
        public int DeleteBook(int id)
        {

            int result = 0;
            //search from Dbset
            var b = context.books.Where(x => x.Id == id).FirstOrDefault();
            if (b != null)
            {
               
                b.IsActive =0;
                result = context.SaveChanges(); //update the change from Dbset to Db
            }

            return result;
        }
    }
}
