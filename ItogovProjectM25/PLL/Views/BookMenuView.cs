using ItogovProjectM25.BLL.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.PLL.Views
{
    /// <summary>
    ///  Представление для работы с книгами
    /// </summary>
    public class BookMenuView
    {
        
        readonly BookService bookService;
        public BookMenuView(BookService bookService)
        {
            this.bookService = bookService;
        }

        /// <summary>
        /// Метод для тображения меню
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("________________________________________________________");


                Console.WriteLine("Просмотреть информацию о книге (нажмите 1)");
                Console.WriteLine("Добавить новую книгу (нажмите 2)");
                Console.WriteLine("Обновить название книги по id (нажмите 3)");
                Console.WriteLine("Обновить год издания книги по id (нажмите 4)");
                Console.WriteLine("Удалить книгу (нажмите 5)");
                Console.WriteLine("Просмотреть данные о книге по id (нажмите 6)");
                Console.WriteLine("Просмотреть список авторов по id книги (нажмите 7)");
                Console.WriteLine("Просмотреть список жаров по id книги (нажмите 8)");
                Console.WriteLine("Добавить  в книгу автора (нажмите 9)");
                Console.WriteLine("Добавить в книгу жанр (нажмите 10)");
                Console.WriteLine("Выйти  (нажмите 11)");
                Console.WriteLine("________________________________________________________");

                string keyValue = Console.ReadLine();

                if (keyValue == "11") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            bookService.PrintBookAll();
                            break;
                        }
                    case "2":
                        {
                            bookService.AddBook();
                            break;
                        }
                    case "3":
                        {
                            bookService.UpdateBookName();
                            break;
                        }
                    case "4":
                        {
                            bookService.UpdateBookYear();
                            break;
                        }
                    case "5":
                        {
                            bookService.DeleteBook();
                            break;
                        }
                    case "6":
                        {
                            bookService.GetBook();
                            break;
                        }
                    case "7":
                        {

                            bookService.GetAutorsBook();
                            break;
                        }
                    case "8":
                        {
                            bookService.GetGenresBook();
                            break;
                        }
                    case "9":
                        {
                            bookService.AddInBookAutor();
                            break;
                        }
                    case "10":
                        {
                            bookService.AddGenreBook();
                            break;
                        }
                }

            }
        }
    
}
}
