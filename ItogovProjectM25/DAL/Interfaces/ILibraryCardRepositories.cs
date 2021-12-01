// <copyright file="ILibraryCardRepositories.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.DAL.Repositories
{
  public interface ILibraryCardRepositories
    {
        /// <summary>
        /// Добавление записи в библиотечную нигу по выдаче книги
        /// </summary>
        /// <param name="libraryCard"> объект записи</param>
        void Create(LibraryCard libraryCard);

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="libraryCard"> объект записи</param>
        void Delete(LibraryCard libraryCard);

        /// <summary>
        /// Получение данных  по id
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns>данные о записи</returns>
        LibraryCard GetbyId(int id);

        /// <summary>
        /// Получение данных о всех записях
        /// </summary>
        /// <returns>список пользователей</returns>
        List<LibraryCard> GetLibraryCard();

        /// <summary>
        /// Фиксация возврата книги по id
        /// </summary>
        /// <param name="id">id записи</param>
        /// <param name="yearreturn">дата возврата книги</param>
        void UpdatebyId(int id, string yearreturn);
    }
}
