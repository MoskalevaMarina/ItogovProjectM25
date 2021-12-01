// <copyright file="IAutorRepositories.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Models;
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.DAL.Repositories
{
    public interface IAutorRepositories
    {
        void Create(Autor autor);
        void Delete(Autor autor);
        Autor GetAutorbyId(int id);
        Autor GetAutorbyName(string name);
        List<Autor> GetAutors();
        List<Book> GetBooksByAutor(int idavtora1);
        void AddBookinAutor(int idavtora1, int idbook);
        void UpdateAutorNamebyId(int idavtora1, string name);
        bool PoiskBookbyAutor(int idbook, int idautor);

    }
}
