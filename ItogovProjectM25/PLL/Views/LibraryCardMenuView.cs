using ItogovProjectM25.BLL.Service;
using ItogovProjectM25.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.PLL.Views
{
    /// <summary>
    ///  Представление для работы с книгой регистрации выдачи книг
    /// </summary>
    public class LibraryCardMenuView
    {
        readonly LibraryCardService Ls;
        public LibraryCardMenuView(LibraryCardService libraryCardService)
        {
            this.Ls = libraryCardService;
        }

        /// <summary>
        /// Метод для тображения меню
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("________________________________________________________");


                Console.WriteLine("Просмотреть информацию о выдаче книг (нажмите 1)");
                Console.WriteLine("Выдать книгу (нажмите 2)");
                Console.WriteLine("Вернуть книгу (нажмите 3)");
                Console.WriteLine("Удалить запись о выдаче книги (нажмите 4)");
                Console.WriteLine("Просмотреть данные о выдаче книги по id записи (нажмите 5)");
               // Console.WriteLine("Просмотреть список авторов по id книги (нажмите 7)");
              //  Console.WriteLine("Просмотреть список жаров по id книги (нажмите 8)");
              //  Console.WriteLine("Добавить  в книгу автора (нажмите 9)");
             //   Console.WriteLine("Добавить в книгу жанр (нажмите 10)");
                Console.WriteLine("Выйти  (нажмите 6)");
                Console.WriteLine("________________________________________________________");

                string keyValue = Console.ReadLine();

                if (keyValue == "6") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Ls.PrintAll();
                            break;
                        }
                    case "2":
                        {
                            Ls.Add();
                            break;
                        }
                    case "3":
                        {
                            Ls.VvodDateOfReturn();
                            break;
                        }
                    case "4":
                        {
                            Ls.DeleteLibraryCard();
                            break;
                        }
                    case "5":
                        {
                            Ls.GetLibraryCard();
                            break;
                        }                 
                }

            }
        }
    }
}
