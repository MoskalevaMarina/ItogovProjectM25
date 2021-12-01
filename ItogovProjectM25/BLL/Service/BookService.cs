// <copyright file="BookService.cs" company="My Company Marina">
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
    /// Класс для работы с сущностью Книга через репозиторий
    /// </summary>
    public class BookService
    {
        readonly AutorRepositories Ar = new AutorRepositories();
        readonly GenreRepositories Gr = new GenreRepositories();
        readonly BookRepositories Br = new BookRepositories();

        /// <summary>
        /// Добавление книги
        /// </summary>
        public void AddBook()
        {
            var book = new Book();
            Console.WriteLine("Введите название книги");
            string st = Console.ReadLine();

            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                book.Name = st;

                Console.WriteLine("Введите год издание книги");
                int nom1 = Convert.ToInt32(Console.ReadLine());

                book.YearOfIssue = nom1;

                Br.Create(book);
                AddAutorInBook(book.Id);
                AddGenreInBook(book.Id);


            }
        }

        /// <summary>
        /// добавление автора в книгу
        /// </summary>
        public void AddInBookAutor()
        {
            Console.WriteLine("Введите id книги, для которого хотите добавить автора *");
            int nom = Convert.ToInt32(Console.ReadLine());
            var book1 = Br.Get(nom);
            if (book1 != null)
            {
                AddAutorInBook(book1.Id);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Добавление автора в книгу
        /// </summary>
        /// <param name="idbook">id книги</param>
        public void AddAutorInBook(int idbook)
        {
            Console.WriteLine("Выберите автора из списка  (введите его id)");
            foreach (var item in Ar.GetAutors())
            {
                Console.WriteLine("Id= " + item.Id + " " + item.Name);
            }
            int nom1 = Convert.ToInt32(Console.ReadLine());
            var autor1 = Ar.GetAutorbyId(nom1);

            if (autor1 != null)
            {
                if (!Br.PoiskAutorinBook(idbook, autor1.Id))
                    Br.AddAutorinBook(idbook, autor1.Id);
                else Console.WriteLine("такой автор у книги уже есть");

            }
            else Console.WriteLine("нет такого автора");
        }

        /// <summary>
        /// Добавление жанра в книгу
        /// </summary>
        public void AddGenreBook()
        {
            Console.WriteLine("Введите id книги, для которого хотите добавить жанр");
            int nom = Convert.ToInt32(Console.ReadLine());
            var book1 = Br.Get(nom);
            if (book1 != null)
            {
                AddGenreInBook(book1.Id);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Добавить жанр книге
        /// </summary>
        /// <param name="idbook">id книги</param>
        public void AddGenreInBook(int idbook)
        {
            Console.WriteLine("Выберите жанр из списка  (введите его id)");
            foreach (var item in Gr.GetGenres())
            {
                Console.WriteLine("Id= " + item.Id + "  " + item.Name);
            }
            int nom1 = Convert.ToInt32(Console.ReadLine());
            var genre1 = Gr.Get(nom1);
            if (genre1 != null)
            {
                if (!Br.PoiskGenreinBook(idbook, genre1.Id)) Br.AddGenreinBook(idbook, genre1.Id);
                else Console.WriteLine("такой жанр у книги уже есть");
            }
            else Console.WriteLine("нет такого жанра");
        }

        /// <summary>
        /// Удаление книги
        /// </summary>
        public void DeleteBook()
        {
            Console.WriteLine("Введите id книги, которую хотите удалить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var book = Br.Get(nom);
            if (book is null) Console.WriteLine("нет такого id");
            else
                Br.Delete(book);
        }

        /// <summary>
        /// Вывод данных обо всех книгах
        /// </summary>
        public void PrintBookAll()
        {
            Console.WriteLine("Список всех книг:");
            Console.WriteLine(" ");

            foreach (var item in Br.GetBooks())
            {
                Console.WriteLine("_______________________________________________________ ");
                string st = "";
                if (item.Autors.Count != 0)
                {
                    foreach (var k in item.Autors)
                    {
                        st = st + k.Name.ToString() + " | ";
                    }
                }
                else st = "-----------";
                string st1 = "";
                if (item.Genres.Count != 0)
                {
                    foreach (var k in item.Genres)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                }
                else st1 = "-----------";
                Console.WriteLine("Id: " + item.Id + " Название:  " + item.Name + " Год выпуска: " + item.YearOfIssue);
                Console.WriteLine(" Авторы: " + st);
                Console.WriteLine("  Жанры: " + st1);
                Console.WriteLine("_______________________________________________________ ");
            }
        }

        /// <summary>
        /// Вывод данных о заданной книге
        /// </summary>
        public void GetBook()
        {
            Console.WriteLine("Введите id книги, которую хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var book = Br.Get(nom);
            if (book != null)
            {
                string st = "";
                if (book.Autors.Count != 0)
                {
                    foreach (var k in book.Autors)
                    {
                        st = st + k.Name.ToString() + " | ";
                    }
                }
                else st = "-----------";
                string st1 = "";
                if (book.Genres.Count != 0)
                {
                    foreach (var k in book.Genres)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                }
                else st1 = "-----------";

                Console.WriteLine("Id: " + book.Id + " Название:  " + book.Name + " Год выпуска: " + book.YearOfIssue);
                Console.WriteLine(" Авторы: " + st);
                Console.WriteLine("  Жанры: " + st1);
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Вывод списка авторов заданной книги
        /// </summary>
        public void GetAutorsBook()
        {
            Console.WriteLine("Введите id книги, список авторов которого хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());
            var book = Br.Get(nom);
            if (book != null)
            {
                var autor1 = Br.GetAutorsbyBook(book.Id);
                if (autor1.Count != 0)
                {
                    string st1 = "";
                    Console.WriteLine(" Список авторов: ");
                    foreach (var k in autor1)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                    Console.WriteLine(st1);
                }
                else Console.WriteLine("У данной книги нет авторов");
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Получение списка жанров заданной книги
        /// </summary>
        public void GetGenresBook()
        {
            Console.WriteLine("Введите id книги, список жанров которого хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());
            var book = Br.Get(nom);
            if (book != null)
            {
                var genre = Br.GetGenresbyBook(book.Id);
                if (genre.Count != 0)
                {
                    string st1 = "";
                    Console.WriteLine(" Список жанров: ");
                    foreach (var k in genre)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                    Console.WriteLine(st1);
                }
                else Console.WriteLine("У данной книги нет жанров");
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Обновление название книги по id
        /// </summary>
        public void UpdateBookName()
        {

            Console.WriteLine("Введите id книги, данные которой хотите изменить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var book1 = Br.Get(nom);
            if (book1 != null)
            {              
                Console.WriteLine("Введите название книги");
                string st = Console.ReadLine();

                if (String.IsNullOrEmpty(st))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    Br.UpdateNameBookById(book1.Id, st);
                }
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Обновление года издания книги по id
        /// </summary>
        public void UpdateBookYear()
        {

            Console.WriteLine("Введите id книги, данные которой хотите изменить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var book1 = Br.Get(nom);
            if (book1 != null)
            {
                Console.WriteLine("Введите год издание книги");
                int nom2 = Convert.ToInt32(Console.ReadLine());

                if (nom2 < 1400 || nom2 > 2022)
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    Br.UpdateYearBookById(book1.Id, nom2);
                }
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Поиск книг по жанру и между определенными годами
        /// </summary>
        public void PoiskBookByGenreandYear()
        {
            Console.WriteLine("Введите название жанра, список книг которого хотите получить");
            string st = Console.ReadLine();
            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                var g1 = Gr.GetByName(st);
                if (g1 != null)
                {
                    Console.WriteLine("Введите года издание книги( между которыми нужно искать)");
                    int year1 = Convert.ToInt32(Console.ReadLine());
                    int year2 = Convert.ToInt32(Console.ReadLine());

                    if (year1 > year2)
                        Console.WriteLine("Вы ввели некорректное значение");
                    else
                    {
                        var g4 = Br.GetBooksbyGenre(st, year1, year2);
                        if (g4.Count != 0)
                        {
                            foreach (var item in g4)
                            {
                                Console.WriteLine("_______________________________________________________ ");
                                string st2 = "";
                                if (item.Autors.Count != 0)
                                {
                                    foreach (var k in item.Autors)
                                    {
                                        st2 = st2 + k.Name.ToString() + " | ";
                                    }
                                }
                                else st = "-----------";
                                string st1 = "";
                                if (item.Genres.Count != 0)
                                {
                                    foreach (var k in item.Genres)
                                    {
                                        st1 = st1 + k.Name.ToString() + " | ";
                                    }
                                }
                                else st1 = "-----------";
                                Console.WriteLine("Id: " + item.Id + " Название:  " + item.Name + " Год выпуска: " + item.YearOfIssue);
                                Console.WriteLine(" Авторы: " + st);
                                Console.WriteLine("  Жанры: " + st1);
                                Console.WriteLine("_______________________________________________________ ");
                            }
                        }
                        else Console.WriteLine("Нет книг данного жанра");
                    }
                }
                else Console.WriteLine("нет такого id");

            }
        }

        /// <summary>
        /// Поиск последней вышедшей книги
        /// </summary>
        public void PoiskBookMaxYear()
        {
            Console.WriteLine("Последняя вышедшая книга");

            var book = Br.GetbyYearMax();
            if (book != null)
            {
                string st = "";
                if (book.Autors.Count != 0)
                {
                    foreach (var k in book.Autors)
                    {
                        st = st + k.Name.ToString() + " | ";
                    }
                }
                else st = "-----------";
                string st1 = "";
                if (book.Genres.Count != 0)
                {
                    foreach (var k in book.Genres)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                }
                else st1 = "-----------";

                Console.WriteLine("Id: " + book.Id + " Название:  " + book.Name + " Год выпуска: " + book.YearOfIssue);
                Console.WriteLine(" Авторы: " + st);
                Console.WriteLine("  Жанры: " + st1);
            }
            else Console.WriteLine("нет книг в библиотеке");
        }

        /// <summary>
        /// Вывод заданного списка книг
        /// </summary>
        /// <param name="books">список книг</param>
        public void PrintBooks(List<Book> books)
        {
           foreach (var item in books)
            {
                Console.WriteLine("_______________________________________________________ ");
                string st = "";
                if (item.Autors.Count != 0)
                {
                    foreach (var k in item.Autors)
                    {
                        st = st + k.Name.ToString() + " | ";
                    }
                }
                else st = "-----------";
                string st1 = "";
                if (item.Genres.Count != 0)
                {
                    foreach (var k in item.Genres)
                    {
                        st1 = st1 + k.Name.ToString() + " | ";
                    }
                }
                else st1 = "-----------";
                Console.WriteLine("Id: " + item.Id + " Название:  " + item.Name + " Год выпуска: " + item.YearOfIssue);
                Console.WriteLine(" Авторы: " + st);
                Console.WriteLine("  Жанры: " + st1);
                Console.WriteLine("_______________________________________________________ ");
            }
        }

        /// <summary>
        /// Вывод отсортированного списка книг по названию
        /// </summary>
        public void PrintSortBooksbyName()
        {
            Console.WriteLine("Cписок всех книг, отсортированных в алфавитном порядке по названию");

            var books = Br.GetBooksSortbyName();
            if (books.Count != 0)
            {
                PrintBooks(books);
            }
            else Console.WriteLine("нет книг в библиотеке");
        }

        /// <summary>
        /// Вывод списка книг отсортированного в порядке убывания года их выхода
        /// </summary>
        public void PrintSortBooksbyDescedingYear()
        {
            Console.WriteLine("Cписок всех книг, отсортированных в порядке убывания года их выхода");

            var books = Br.GetBooksSortbyDescedingYear();
            if (books.Count != 0)
            {
                PrintBooks(books);
            }
            else Console.WriteLine("нет книг в библиотеке");
        }

    }
}

