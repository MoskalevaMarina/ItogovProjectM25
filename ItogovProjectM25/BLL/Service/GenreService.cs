// <copyright file="GenreService.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Repositories;
using ItogovProjectM25.Models;
using ItogovProjectM25.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.Service
{
    /// <summary>
    /// Класс для работы с сущностью Жанр через репозиторий
    /// </summary>
    public class GenreService
    {
        readonly GenreRepositories genreRepositories = new GenreRepositories();
        readonly BookRepositories Br = new BookRepositories();

        /// <summary>
        /// Добавление жанра
        /// </summary>
        public void AddGenre()
        {
            var g1 = new Genre();
            Console.WriteLine("Введите название жанра");
            string st = Console.ReadLine();

            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                g1.Name = st;
                genreRepositories.Create(g1);
            }
        }

        /// <summary>
        /// Удаление жанра
        /// </summary>
        public void DeleteGenre()
        {
            Console.WriteLine("Введите id жанра, который хотите удалить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var g4 = genreRepositories.Get(nom);
            if (g4 is null) Console.WriteLine("нет такого id");
            else
                genreRepositories.Delete(g4);
        }

        /// <summary>
        /// Вывод всех жанров
        /// </summary>
        public void PrintGenreAll()
        {
            Console.WriteLine("Список всех жанров:");
            Console.WriteLine("_______________________________________________________ ");
            foreach (var item in genreRepositories.GetGenres())
            {
                string st1 = "";
                if (item.Books.Count != 0)
                {
                    foreach (var k in item.Books)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                }
                else st1 = "-----------";

                Console.WriteLine("| Id=  " + item.Id + "  " + item.Name);
                Console.WriteLine("  Список книг:  " + st1);
            }
            Console.WriteLine("_______________________________________________________ ");
        }

        /// <summary>
        /// Получить данне о жанре
        /// </summary>
        public void GetGenre()
        {
            Console.WriteLine("Введите id жанра, который хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var g4 = genreRepositories.Get(nom);
            if (g4 != null)
            {
                string st1 = "";
                if (g4.Books.Count != 0)
                {
                    foreach (var k in g4.Books)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                }
                else st1 = "-----------";

                Console.WriteLine("| Id=  " + g4.Id + " Наименование:  " + g4.Name);
                Console.WriteLine("  Список книг:  " + st1);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Получение спписка книг по id жанра
        /// </summary>
        public void GetBooksGenreById()
        {
            Console.WriteLine("Введите id жанра, список книг которого хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());
            var g1 = genreRepositories.Get(nom);
            if (g1 != null)
            {
                var g4 = genreRepositories.GetBooksByIdGenre(nom);
                string st1 = "";
                if (g4.Count != 0)
                {
                    foreach (var k in g4)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                    Console.WriteLine(" Список книг: " + st1);
                }
                else Console.WriteLine("Нет книг данного жанра");
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Получение списка книг по названию жанра
        /// </summary>
        public void GetBooksGenreByName()
        {
            Console.WriteLine("Введите название жанра, список книг которого хотите получить");

            string st = Console.ReadLine();
            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                var g1 = genreRepositories.GetByName(st);
                if (g1 != null)
                {
                    var g4 = genreRepositories.GetBooksByNameGenre(st);
                    string st1 = "";
                    if (g4.Count != 0)
                    {
                        foreach (var k in g4)
                        {
                            st1 = st1 + k.Name.ToString() + " | ";
                        }
                        Console.WriteLine(" Список книг: " + st1);
                    }
                    else Console.WriteLine("Нет книг данного жанра");
                }
                else Console.WriteLine("нет такого жанра");
            }
        }

        /// <summary>
        /// Обновление данных о жанре
        /// </summary>
        public void UpdateGenre()
        {
            Console.WriteLine("Введите id жанра, который хотите изменить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var g4 = genreRepositories.Get(nom);
            if (g4 != null)
            {
                Console.WriteLine("Введите название жанра");
                string st = Console.ReadLine();
                if (String.IsNullOrEmpty(st))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    genreRepositories.UpdateName(nom, st);
                }
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Добавление книги к жанру
        /// </summary>
        public void AddBookInGenre()
        {
            Console.WriteLine("Введите id жанра, для которого хотите добавить книгу *");
            int nom = Convert.ToInt32(Console.ReadLine());
            var genre1 = genreRepositories.Get(nom);
            if (genre1 != null)
            {
                AddBookInGenre(genre1.Id);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Добавление книги к жанру
        /// </summary>
        /// <param name="idgenre">id жанра</param>
        public void AddBookInGenre(int idgenre)
        {
            Console.WriteLine("Выберите из списка книгу (введите ее id)");
            foreach (var item in Br.GetBooks())
            {
                Console.WriteLine("Id= " + item.Id + "  " + item.Name);
            }
            int nom1 = Convert.ToInt32(Console.ReadLine());
            var book1 = Br.Get(nom1);
            if (book1 != null)
            {
                if (!genreRepositories.PoiskBookinGenre(book1.Id, idgenre))
                    genreRepositories.AddBookinGenre(idgenre, book1.Id);
                else Console.WriteLine("такая книга уже есть");
            }
            else Console.WriteLine("нет такой книги");
        }

        /// <summary>
        /// Получени количества книг заданного жанра
        /// </summary>
        public void GetCountBooksbyAutor()
        {
            Console.WriteLine("Введите название жанра, количество книг которого хотите получить");
            string st = Console.ReadLine();
            var autor = genreRepositories.GetByName(st);
            if (autor != null)
            {
                int kol = genreRepositories.GetCountBooksByGenre(st);

                if (kol != 0)
                {
                    Console.WriteLine(" Количество книг: " + kol);
                }
                else Console.WriteLine("Данного жанра книг нет");
            }
            else Console.WriteLine("нет такого id");
        }

    }
}
