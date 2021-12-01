// <copyright file="IGenreRepositories.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.Repositories
{
   public interface IGenreRepositories
    {
        void Create(Genre genre);
        void Delete(Genre genre);
        Genre Get(int id);
        Genre GetByName(string name);
        List<Genre> GetGenres();
        void UpdateName(int id, string name);
        List<Book> GetBooksByNameGenre(string name);
        List<Book> GetBooksByIdGenre(int id);
        void AddBookinGenre(int idgenre, int idbook);
        bool PoiskBookinGenre(int idbook, int idgenre);

    }
}
