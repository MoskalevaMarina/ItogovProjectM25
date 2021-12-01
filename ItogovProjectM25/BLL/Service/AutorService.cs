// <copyright file="AutorService.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Models;
using ItogovProjectM25.DAL.Repositories;
using ItogovProjectM25.Models;
using ItogovProjectM25.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.BLL.Service
{
    /// <summary>
    /// Класс для работы с сущностью Автор через репозиторий
    /// </summary>
    public class AutorService
    {
        readonly AutorRepositories Ar = new AutorRepositories();
        readonly BookRepositories Br = new BookRepositories();

        /// <summary>
        /// добавление автора
        /// </summary>
        public void AddAutor()
        {
            var autor1 = new Autor();
            Console.WriteLine("Введите имя автора");
            string st = Console.ReadLine();

            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                autor1.Name = st;
                Ar.Create(autor1);
            }
        }

        /// <summary>
        /// добавление книги  автору
        /// </summary>
        public void AddBookinAutor()
        {
            Console.WriteLine("Введите id автора, для которого хотите добавить книгу *");
            int nom = Convert.ToInt32(Console.ReadLine());
            var autor1 = Ar.GetAutorbyId(nom);
            if (autor1 != null)
            {
                AddBookinAutor(autor1.Id);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// добавление книги  автору
        /// </summary>
        /// <param name="autor">Id автора</param>
        public void AddBookinAutor(int idautor)
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
                if (!Ar.PoiskBookbyAutor(book1.Id, idautor))
                    Ar.AddBookinAutor(idautor, book1.Id);
                else Console.WriteLine("такая книга уже есть");
            }
            else Console.WriteLine("нет такой книги");
        }

        /// <summary>
        /// Удаление автора
        /// </summary>
        public void DeleteAutor()
        {

            Console.WriteLine("Введите id автора, которого хотите удалить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var autor1 = Ar.GetAutorbyId(nom);
            if (autor1 is null) Console.WriteLine("нет такого id");
            else
                Ar.Delete(autor1);
        }

        /// <summary>
        /// Вывод  всех данных об авторах
        /// </summary>
        public void PrintAutorAll()
        {
            Console.WriteLine("Список всех авторов:");
            Console.WriteLine(" ");

            foreach (var item in Ar.GetAutors())
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

                Console.WriteLine("| Id=  " + item.Id + " Имя :  " + item.Name);
                Console.WriteLine("   Список книг:  " + st1);
            }
            Console.WriteLine("_______________________________________________________ ");
        }

        /// <summary>
        /// Получение данных об авторе
        /// </summary>
        public void GetAutor()
        {
            Console.WriteLine("Введите id автора, которого хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var autor1 = Ar.GetAutorbyId(nom);
            if (autor1 != null)
            {
                string st1 = "";
                if (autor1.Books.Count != 0)
                {
                    foreach (var k in autor1.Books)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                }
                else st1 = "-----------";

                Console.WriteLine("| Id=  " + autor1.Id + " Наименование:  " + autor1.Name);
                Console.WriteLine("  Список книг:  " + st1);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Получени списка книг заданного автора
        /// </summary>
        public void GetBooksAutor()
        {
            Console.WriteLine("Введите id автора, список книг которого хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());
            var autor = Ar.GetAutorbyId(nom);
            if (autor != null)
            {
                var books1 = Ar.GetBooksByAutor(autor.Id);
                string st1 = "";
                if (books1.Count != 0)
                {
                    foreach (var k in books1)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                    Console.WriteLine(" Список книг: " + st1);
                }
                else Console.WriteLine("У данного автора нет книг");
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Обновление имени автора
        /// </summary>
        public void UpdateAutor()
        {
            Console.WriteLine("Введите id автора, данные которого хотите изменить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var autor1 = Ar.GetAutorbyId(nom);
           if (autor1 != null)
            {
                Console.WriteLine("Введите имя автора");
                string st = Console.ReadLine();
                if (String.IsNullOrEmpty(st))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    Ar.UpdateAutorNamebyId(autor1.Id, st);
                }
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Получение списка книг по имени автора
        /// </summary>
        public void GetBooksByNameAutor()
        {
            Console.WriteLine("Введите имя автора, список книг которого хотите получить");

            string st = Console.ReadLine();
            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                var g1 = Ar.GetAutorbyName(st);
                if (g1 != null)
                {
                    var g4 = Ar.GetBooksByAutor(g1.Id);
                    string st1 = "";
                    if (g4.Count != 0)
                    {
                        foreach (var k in g4)
                        {
                            st1 = st1 + k.Name.ToString() + " | ";
                        }
                        Console.WriteLine(" Список книг: " + st1);
                    }
                    else Console.WriteLine("Нет книг у данного автора");
                }
                else Console.WriteLine("нет такого автора");

            }
        }

        /// <summary>
        /// Получение количества книг заданного автора
        /// </summary>
        public void GetCountBooksbyAutor()
        {
            Console.WriteLine("Введите имя автора, количество книг которого хотите получить");
            string st = Console.ReadLine();
            var autor = Ar.GetAutorbyName(st);
            if (autor != null)
            {
                int kol = Ar.GetCountBooksByAutor(st);

                if (kol != 0)
                {
                    Console.WriteLine(" Количество книг: " + kol);
                }
                else Console.WriteLine("У данного автора нет книг");
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Поиск книги в библиотеке по названию и автору
        /// </summary>
        public void PoiskBooksbyAutorAndNamebook()
        {
            Console.WriteLine("Введите имя автора");
            string st = Console.ReadLine();
            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                var autor = Ar.GetAutorbyName(st);
                if (autor != null)
                {
                    Console.WriteLine("Введите название книги");
                    string st1 = Console.ReadLine();
                    if (String.IsNullOrEmpty(st1))
                        Console.WriteLine("Вы ввели некорректное значение");
                    else
                    {
                        if (Ar.PoikBookByAutorAndName(st, st1))
                        {
                            Console.WriteLine(" Данная книга есть в библиотеке");
                        }
                        else Console.WriteLine(" Такой книги нет в библиотеке");
                    }
                }
                else Console.WriteLine("нет такого id");
            }
        }
    }
}
