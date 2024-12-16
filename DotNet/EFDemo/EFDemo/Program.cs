using EFDemo.DB;
using EFDemo.DB.Model;

namespace EFDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = MysqlDbContentFactory.DbContent)
            {
                var book = new Book()
                {
                    Title = "1",
                    Labels = new List<Label>()
                    {
                        new Label(){ Title="1"},
                        new Label(){ Title="2"},
                    }
                };
                db.Books.Add(book);
                db.SaveChanges();

                var bookList = db.Books.ToList();

            }


            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
    }
}
