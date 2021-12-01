using ItogovProjectM25.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.PLL.Views
{
    /// <summary>
    ///  Представление для работы с жанрами
    /// </summary>
    public class GenreMenuView
    {
        readonly  GenreService genreService;
        public GenreMenuView(GenreService gs)
        {
            this.genreService = gs;
        }

        /// <summary>
        /// Метод для тображения меню
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("________________________________________________________");


                Console.WriteLine("Просмотреть информацию о жанрах (нажмите 1)");
                Console.WriteLine("Добавить новй жанр (нажмите 2)");
                Console.WriteLine("Редактировать жанр (нажмите 3)");
                Console.WriteLine("Удалить жанр (нажмите 4)");
                Console.WriteLine("Просмотреть жанр по id (нажмите 5)");
                Console.WriteLine("Просмотреть список книг по id жанра (нажмите 6)");
                Console.WriteLine("Просмотреть список книг по названию жанра (нажмите 7)");
                Console.WriteLine("Добавить книгу жанру (нажмите 8)");
                Console.WriteLine("Выйти  (нажмите 9)");
                Console.WriteLine("________________________________________________________");

                string keyValue = Console.ReadLine();

                if (keyValue == "9") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            genreService.PrintGenreAll();
                            break;
                        }
                    case "2":
                        {
                            genreService.AddGenre();
                            break;
                        }
                    case "3":
                        {
                            genreService.UpdateGenre();
                            break;
                        }
                    case "4":
                        {
                            genreService.DeleteGenre();
                            break;
                        }

                    case "5":
                        {
                            genreService.GetGenre();
                            break;
                        }
                    case "6":
                        {
                            genreService.GetBooksGenreById();
                            break;
                        }
                    case "7":
                        {
                            genreService.GetBooksGenreByName();
                            break;
                        }
                    case "8":
                        {
                            genreService.AddBookInGenre();
                            break;
                        }
                }

            }
        }
    }
}
