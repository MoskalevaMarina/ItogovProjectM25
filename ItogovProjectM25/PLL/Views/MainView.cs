using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.PLL.Views
{
    /// <summary>
    ///  Представление для работы с главным меню
    /// </summary>
    public class MainView
    {
        /// <summary>
        /// Метод для тображения меню
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Работа с таблицей Жанры (нажмите 1)");
            Console.WriteLine("Работа с таблицей Авторы (нажмите 2)");
            Console.WriteLine("Работа с таблицей Книги (нажмите 3)");
            Console.WriteLine("Работа с таблицей Пользователи (нажмите 4)");
            Console.WriteLine("Работа с таблицей Выдача книг (нажмите 5)");
            Console.WriteLine("Запросы (нажмите 6)");
         
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.genreMenuView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.autorMenuView.Show();
                        break;
                    }
                case "3":
                    {
                        Program.bookMenuView.Show();
                        break;
                    }
                case "4":
                    {
                        Program.userMenuView.Show();
                        break;
                    }
                case "5":
                    {
                        Program.libraryCardMenuView.Show();
                        break;
                    }
                case "6":
                    {
                        Program.requestsMenu.Show();
                        break;
                    }
                case "7":
                    {
                        break;
                    }
            }
        }

    }
}
