using ItogovProjectM25.BLL.Service;
using ItogovProjectM25.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.PLL.Views
{
    /// <summary>
    ///  Представление для работы с запросами
    /// </summary>
    public class RequestsMenuView
    {
        readonly BookService bs;
        readonly AutorService autorService;
        readonly LibraryCardService Ls;
        readonly GenreService Gs;

        public RequestsMenuView(BookService bs, AutorService As, LibraryCardService Ls, GenreService Gs)
        {
            this.autorService = As;
            this.bs = bs;
            this.Ls = Ls;
            this.Gs = Gs;
        }

        /// <summary>
        /// Метод для тображения меню
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("________________________________________________________");
                Console.WriteLine("1. Получать список книг определенного жанра и вышедших между определенными годами");
                Console.WriteLine("2. Получать количество книг определенного автора в библиотеке");
                Console.WriteLine("3. Получать количество книг определенного жанра в библиотеке");
                Console.WriteLine("4. Определить есть ли книга определенного автора и с определенным названием в библиотеке ");
                Console.WriteLine("5. Определить есть ли определенная книга на руках у пользователя");
                Console.WriteLine("6. Получать количество книг на руках у пользователя");
                Console.WriteLine("7. Получение последней вышедшей книги");
                Console.WriteLine("8. Получение списка всех книг, отсортированного в алфавитном порядке по названию");
                Console.WriteLine("9. Получение списка всех книг, отсортированного в порядке убывания года их выхода");
                Console.WriteLine(" Выйти  (нажмите 10)");
                Console.WriteLine("________________________________________________________");

                string keyValue = Console.ReadLine();

                if (keyValue == "10") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            bs.PoiskBookByGenreandYear();
                            break;
                        }
                    case "2":
                        {
                            autorService.GetCountBooksbyAutor();
                            break;
                        }
                    case "3":
                        {
                            Gs.GetCountBooksbyAutor();
                            break;
                        }
                    case "4":
                        {
                            autorService.PoiskBooksbyAutorAndNamebook();
                            break;
                        }
                    case "5":
                        {
                            Ls.PoiskBookbyNameinUser();
                            break;
                        }
                    case "6":
                        {
                            Ls.PoiskCountBookinUser();
                            break;
                        }
                    case "7":
                        {
                            bs.PoiskBookMaxYear();
                            break;
                        }
                    case "8":
                        {
                            bs.PrintSortBooksbyName();
                            break;
                        }
                    case "9":
                        {
                            bs.PrintSortBooksbyDescedingYear();
                            break;
                        }
                }
            }
        }
    }
}
