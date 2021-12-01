// <copyright file="IBookRepositories.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Models;
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.DAL.Repositories
{
    public interface IBookRepositories
    {
        void Create(Book book);
        void Delete(Book book);
        void UpdateNameBookById(int idbook, string name);
        void UpdateYearBookById(int idbook, int yearnew);
        Book Get(int id);
        List<Book> GetBooks();
        List<Autor> GetAutorsbyBook(int idbook);
        List<Genre> GetGenresbyBook(int idbook);
        void AddAutorinBook(int idbook, int idautor);
        void AddGenreinBook(int idbook, int idgenre);
        bool PoiskAutorinBook(int idbook, int idautor);
        bool PoiskGenreinBook(int idbook, int idgenre);


    }
}
