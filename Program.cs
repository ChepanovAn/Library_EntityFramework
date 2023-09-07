using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_EntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            BookRepository bookRepository = new BookRepository();

         
            using (AppContext app = new AppContext())
            {

                app.Database.EnsureDeleted();
                app.Database.EnsureCreated();

                User user1 = new User { Name = "user1", Email = "user1@mail.com", Books = new List<Book>() };
                User user2 = new User { Name = "user2", Email = "user2@mail.com", Books = new List<Book>() };
                User user3 = new User { Name = "user3", Email = "user3@mail.com", Books = new List<Book>() };
                User user4 = new User { Name = "user4", Email = "user4@mail.com", Books = new List<Book>() };
                User user5 = new User { Name = "user5", Email = "user5@mail.com", Books = new List<Book>() };
                User user6 = new User { Name = "user6", Email = "user6@mail.com",Books = new List<Book>() };
                app.Users.AddRange(user1, user2, user3, user4, user5, user6);

                Book book1 = new Book { Name = "20000 лье под водой", Author = "Верн", Year = "1870", User = user1 };
                Book book2 = new Book { Name = "Ведьмак", Author = "Сапковский", Year = "1993", User = user5 };
                Book book3 = new Book { Name = "Горе от ума", Author = "Грибоедов", Year = "1825", User = user1 };
                Book book4 = new Book { Name = "Пикник на обочине", Author = "Стругацкие", Year = "1972", User = user5 };
                Book book5 = new Book { Name = "Метро 2033", Author = "Глуховский", Year = "2005", User = user2 };
                Book book6 = new Book { Name = "Метро 2034", Author = "Глуховский", Year = "2009", User = user2 };
                Book book7 = new Book { Name = "Метро 2035", Author = "Глуховский", Year = "2015", User = user4 };
                Book book8 = new Book { Name = "Война и мир", Author = "Толстой", Year = "1869", User = user4 };
                Book book9 = new Book { Name = "Золотой телёнок", Author = "Ильф и Петров", Year = "1931", User = user4 };
                Book book10 = new Book { Name = "Автостопом по галактике", Author = "Дуглас", Year = "1979", User = user3 };
                Book book11 = new Book { Name = "Какое-то", Author = "Кто-то", Year = "0001" };
              //  app.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11);



                app.SaveChanges();
            };
           

            BookView bookView = new BookView(bookRepository);
            UserView userView = new UserView(userRepository);
            MainView mainView = new MainView(bookView, userView);
            mainView.MainViewMethod();
        }
    }
}
