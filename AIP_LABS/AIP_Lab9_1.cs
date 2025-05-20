struct Book
{
    public string AuthorName {  get;}
    public string BookName { get;}
    public string RelDate { get;}
    public string Publisher { get;}
    public List<Record> Records { get;}
    public Book(string authorName, string bookName, string relDate, string publisher,List<Record> records)
    {
        AuthorName = authorName;
        BookName = bookName;
        RelDate = relDate;
        Publisher = publisher;
        Records = new List<Record>(records);
    }
}
class Record
{
    public string IssueDate { get; set; }
    public string LeaseDate { get; set;}
    public Record(string issueDate, string leaseDate)
    {
        IssueDate = issueDate;
        LeaseDate = leaseDate;
    }
}
class Program
{
   
    static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book("Джордж Оруэлл","1984","1949","АСТ", new List<Record> {new Record("12.01.2000","15.03.2000"),new Record("04.05.2004","09.06.2004")}),
            new Book("Дж. Р. Р. Толкин","Властелин Колец","1954-1955","АСТ", new List<Record>{new Record("22.07.2014",null)}),
            new Book("Агата Кристи","Убийство в Восточном Экспрессе","1934","Эксмо",new List<Record>{new Record(null,null)}),
            new Book("Том Харрис","Молчание ягнят","1988","АСТ", new List<Record>{new Record("03.02.2004","05.04.2004"),new Record("07.07.2006",null)})
        };
        Console.WriteLine("Книги которые не выдавались\n");
        foreach (Book book in books)
        {
            foreach(Record record in book.Records)
            {
                if (record.IssueDate == null && record.LeaseDate == null)
                {                    
                    Console.WriteLine($"Название книги: {book.BookName}\nАвтор: {book.AuthorName}\nДата выхода книги: {book.RelDate}\nИздательство: {book.Publisher}\n");
                }
            }
        }
        Console.WriteLine("Книги которые не были сданы\n");
        foreach(Book book in books)
        {
            foreach (Record record in book.Records)
            {
                if(record.IssueDate != null && record.LeaseDate == null)
                {
                    Console.WriteLine($"Название книги: {book.BookName}\nАвтор: {book.AuthorName}\nДата выхода книги: {book.RelDate}\nИздательство: {book.Publisher}\n");
                }
            }
        }
        
    }
}