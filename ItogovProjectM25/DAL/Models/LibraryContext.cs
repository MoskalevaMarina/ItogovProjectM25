// <copyright file="LibraryContext.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.Models
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    public class LibraryContext: DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }

        public LibraryContext()
        {
          // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=library1;Trusted_Connection=True;");
        }
    }
}
