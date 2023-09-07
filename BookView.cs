using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EntityFramework
{
    public class BookView
    {
        public BookRepository _BookRepository;
        public BookView(BookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }
        public void WorkWithBooks()
        {
            string choice = string.Empty;
            do
            {
                Console.WriteLine("Чё надо?" +
                    "\n'show': показать все данные;" +
                    "\n'add': добавить книгу;" +
                    "\n'update': изменить название;" +
                    "\n'sba': показать книги по автору;" +
                    "\n'fyi': поиск по интервалу годов выпуска" +
                    "\n'ioh': книги \"на руках\"" +
                    "\n'sort': вывести отсортированные по названию книги;" +
                    "\n'delete': удалить по Id;" +
                    "\n'exit': выход\n");
                Console.Write("Что выполнить?\nВведите команду: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case nameof(Choice.show):
                        _BookRepository.SelectAllBooks();
                        break;
                    case nameof(Choice.delete):
                        Console.Write("Введите Id книги для удаления: ");
                        _BookRepository.DeleteBookById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.update):
                        Console.Write("Введите Id книги для редактирования: ");
                        _BookRepository.BookDataChangeById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.add):
                        _BookRepository.AddBook();
                        break;
                    case nameof(Choice.sort):
                        _BookRepository.SortBooksByName();
                        break;
                    case nameof(Choice.sba):
                        _BookRepository.ShowBooksFromAuthor();
                        break;
                    case nameof(Choice.fyi):
                        _BookRepository.BooksFromYearInterval();
                        break;
                    case nameof(Choice.ioh):
                        _BookRepository.IsOnHandsByUser();
                        break;
                }
            } while (choice != nameof(Choice.exit));
        }
    }
}
