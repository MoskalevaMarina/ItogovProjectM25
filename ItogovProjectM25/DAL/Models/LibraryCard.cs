// <copyright file="LibraryCard.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.Models
{
    /// <summary>
    /// Класс регистрационная книга в библиотеке
    /// </summary>
    public class LibraryCard
    {
        public int Id { get; set; }
        public string DateOfIssue { get; set; }
        public string DateOfReturn { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
