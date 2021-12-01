// <copyright file="Genre.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.Models
{
    /// <summary>
    /// Класс жанр
    /// </summary>
   public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
