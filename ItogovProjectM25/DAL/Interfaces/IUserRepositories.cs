// <copyright file="IUserRepositories.cs " company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.DAL.Repositories
{
  public interface IUserRepositories
    {
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user"> объект User</param>
        void Create(User user);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user"> объект User</param>
        void Delete(User user);

        /// <summary>
        /// Получение данных о пользователе по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns>данные о пользователе</returns>
        User GetUserbyId(int id);

        /// <summary>
        /// Получение данных о всех пользователях
        /// </summary>
        /// <returns>список пользователей</returns>
        List<User> GetUsers();

        /// <summary>
        /// Обновление имени пользователя по id
        /// </summary>
        /// <param name="iduser">id пользователя</param>
        /// <param name="name">новое имя</param>
        void UpdateNamebyId(int iduser, string name);
     }
}
