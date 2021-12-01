// <copyright file="Book.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.Models
{
    /// <summary>
    /// Класс Книга
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public List<Autor> Autors { get; set; } = new List<Autor>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

    }

}

