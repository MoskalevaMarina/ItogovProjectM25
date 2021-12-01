// <copyright file="UserService.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Repositories;
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.BLL.Service
{
    /// <summary>
    /// Класс для работы с сущностью Пользователь через репозиторий
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// переменная репозитория
        /// </summary>
       readonly UserRepositories Ur = new UserRepositories();

        /// <summary>
        /// добавление пользователя
        /// </summary>
        public void AddUser()
        {
            var user1 = new User();
            Console.WriteLine("Введите имя пользователя");
            string st = Console.ReadLine();

            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                user1.Name = st;
                Console.WriteLine("Введите email пользователя");
                 st = Console.ReadLine();

                if (String.IsNullOrEmpty(st))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    user1.Email = st;
                    Ur.Create(user1);
                }
            }
        }


        /// <summary>
        /// Удаление пользователя
        /// </summary>
        public void DeleteUser()
        {
            Console.WriteLine("Введите id пользователя, которого хотите удалить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var user1 = Ur.GetUserbyId(nom);
            if (user1 is null)
            {
                Console.WriteLine("нет такого id");
            }
            else
            {
                Ur.Delete(user1);
            }
        }

        /// <summary>
        /// Вывод  всех данных о пользователях
        /// </summary>
        public void PrintUserAll()
        {
            Console.WriteLine("Список всех пользователей:");
            Console.WriteLine(" ");
            foreach (var item in Ur.GetUsers())
            {
                Console.WriteLine("| Id=  " + item.Id + " Имя :  " + item.Name + "  Email:  " + item.Email);
            }
            Console.WriteLine("_______________________________________________________ ");
        }

        /// <summary>
        /// Получение данных о пользователе
        /// </summary>
        public void GetUser()
        {
            Console.WriteLine("Введите id пользователя, которого хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var user1 = Ur.GetUserbyId(nom);
            if (user1 != null)
            {
                Console.WriteLine("| Id=  " + user1.Id + " Имя:  " + user1.Name + " Email:  " + user1.Email);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Обновление имени пользователя
        /// </summary>
        public void UpdateUser()
        {
            Console.WriteLine("Введите id пользователя, данные которого хотите изменить");
            int nom = Convert.ToInt32(Console.ReadLine());
            var user1 = Ur.GetUserbyId(nom);
            if (user1 != null)
            {
                Console.WriteLine("Введите новое имя пользователя");
                string st = Console.ReadLine();
                if (String.IsNullOrEmpty(st))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    Ur.UpdateNamebyId(user1.Id, st);
                }
            }
            else Console.WriteLine("нет такого id");
        }


    }
}
