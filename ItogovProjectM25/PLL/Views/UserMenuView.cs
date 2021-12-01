using ItogovProjectM25.BLL.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.PLL.Views
{
    /// <summary>
    /// Представление для работы с пользователем
    /// </summary>
   public class UserMenuView
    {
        readonly UserService Us;
        public UserMenuView(UserService userService)
        {
            this.Us = userService;
        }

        /// <summary>
        /// Метод для тображения меню
        /// </summary>
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("________________________________________________________");


                Console.WriteLine("Просмотреть информацию о всех пользователях (нажмите 1)");
                Console.WriteLine("Добавить нового пользователя (нажмите 2)");
                Console.WriteLine("Редактировать имя пользователя (нажмите 3)");
                Console.WriteLine("Удалить пользователя (нажмите 4)");
                Console.WriteLine("Просмотреть данные о пользователе по id (нажмите 5)");
                Console.WriteLine("Выйти  (нажмите 6)");
                Console.WriteLine("________________________________________________________");

                string keyValue = Console.ReadLine();

                if (String.IsNullOrEmpty(keyValue))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    if (keyValue == "6") break;

                    switch (keyValue)
                    {
                        case "1":
                            {
                                Us.PrintUserAll();
                                break;
                            }
                        case "2":
                            {
                                Us.AddUser();
                                break;
                            }
                        case "3":
                            {
                                Us.UpdateUser();
                                break;
                            }
                        case "4":
                            {
                                Us.DeleteUser();
                                break;
                            }

                        case "5":
                            {
                               Us.GetUser();
                                break;
                            }                        
                    }
                }

            }
        }
    }
}
