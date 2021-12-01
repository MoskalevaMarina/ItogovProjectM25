using ItogovProjectM25.BLL.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.PLL.Views
{
    /// <summary>
    ///  Представление для работы с авторами
    /// </summary>
    public class AutorMenuView
    {
        readonly AutorService autorService;

        public AutorMenuView(AutorService autorService)
        {
            this.autorService = autorService;
        }

        /// <summary>
        /// Метод для тображения меню
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("________________________________________________________");


                Console.WriteLine("Просмотреть информацию об авторах (нажмите 1)");
                Console.WriteLine("Добавить нового автора (нажмите 2)");
                Console.WriteLine("Редактировать данные об авторе (нажмите 3)");
                Console.WriteLine("Удалить автора (нажмите 4)");
                Console.WriteLine("Просмотреть данные об авторе по id (нажмите 5)");
                Console.WriteLine("Просмотреть список книг по id автора (нажмите 6)");
                Console.WriteLine("Просмотреть список книг по имени автора (нажмите 7)");
                Console.WriteLine("Добавить книгу автору (нажмите 8)");
                Console.WriteLine("Выйти  (нажмите 9)");
                Console.WriteLine("________________________________________________________");

                string keyValue = Console.ReadLine();

                if (String.IsNullOrEmpty(keyValue))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    if (keyValue == "9") break;

                    switch (keyValue)
                    {
                        case "1":
                            {
                                autorService.PrintAutorAll();
                                break;
                            }
                        case "2":
                            {
                                autorService.AddAutor();
                                break;
                            }
                        case "3":
                            {
                                autorService.UpdateAutor();
                                break;
                            }
                        case "4":
                            {
                                autorService.DeleteAutor();
                                break;
                            }

                        case "5":
                            {
                                autorService.GetAutor();
                                break;
                            }
                        case "6":
                            {
                                autorService.GetBooksAutor();
                                break;
                            }
                        case "7":
                            {
                                autorService.GetBooksByNameAutor();
                                break;
                            }
                        case "8":
                            {
                                autorService.AddBookinAutor();
                                break;
                            }
                    }
                }

            }
        }
    }
}
