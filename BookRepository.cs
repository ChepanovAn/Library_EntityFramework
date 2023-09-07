using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EntityFramework
{
    public class BookRepository
    {
        public void SelectAllBooks()
        {
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.ToList();
                foreach (var item in books)
                {
                    string a = item.Author != null ? item.Author : "не задано";
                    Console.WriteLine($"Название книги: {item.Name}\tАвтор: {a}\tГод издания: {item.Year}\tId читателя: {item.UserId}");
                }
            }
        }

        public void AddBook()
        {
            Book book = new Book();
            Console.WriteLine("Введите Название новой книги: ");
            book.Name = Console.ReadLine();

            Console.WriteLine("Введите Фамилию автора новой книги: ");
            book.Author = Console.ReadLine();

            Console.WriteLine("Введите Год издания книги: ");
            book.Year = Console.ReadLine();

            using (AppContext app = new AppContext())
            {
                Book newBook = app.Books.FirstOrDefault();
                app.Books.Add(book);
                app.SaveChanges();
            }
        }

        public void DeleteBookById(int id)
        {
            using (AppContext app = new AppContext())
            {
                Book? book = app.Books.Where(x => x.Id == id).FirstOrDefault();
                app.Books.Remove(book);
                app.SaveChanges();
            }
        }
        public void BookDataChangeById(int Id)
        {
            using (AppContext app = new AppContext())
            {
                Book bookData = app.Books.Where(i => i.Id == Id).FirstOrDefault();
                Console.Write("Введите отредактированный Год издания: ");
                bookData.Year = Console.ReadLine();
                app.Books.Update(bookData);
                app.SaveChanges();
            }
        }
        public void SortBooksByName()
        {
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.ToList();
                var sort =
                    from book in books
                    orderby book.Name.ToUpper()
                    select new { n = book.Name, a = book.Author };
                foreach (var item in sort)
                {
                    Console.WriteLine($"Название: {item.n}\tАвтор: {item.a}");
                }
            }
        }

        public void ShowBooksFromAuthor()
        {
            Console.Write("Введите автора: ");
            string surname = Console.ReadLine();
            using (AppContext app = new AppContext())
            {
                List<Book> books = app.Books.Where(a => a.Author.ToUpper() == surname).ToList();
                foreach (var item in books)
                {
                    Console.WriteLine(item.Name + " " + item.Author);
                }
            }

        }

        public void BooksFromYearInterval()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Поиск по временному интервалу");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите временной интервал (годОт - годДо): ");
            string yearInteval = Console.ReadLine();

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n', '-' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = yearInteval.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int[] years = new int[words.Length];
            for (int i = 0; i < years.Length; i++)
            {
                years[i] = Convert.ToInt32(words[i]);
            }

        }

        public void IsOnHandsByUser()
        {
            Console.Write("Введите userId: ");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ввведите bookId: ");
            int bookid = Convert.ToInt32(Console.ReadLine());
            using (AppContext app = new AppContext())
            {
                var search = app.Users.Where(uid => uid.Id == userid && uid.Books.Contains(app.Books.Where(b => b.Id == bookid).First()));
                Console.WriteLine($"Id книги: {search.Any()} Id пользователя: {userid}");
            }
        }
    }
}
