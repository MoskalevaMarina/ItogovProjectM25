// <copyright file="LibraryCardService.cs" company="My Company Marina">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
using ItogovProjectM25.DAL.Repositories;
using ItogovProjectM25.Models;
using ItogovProjectM25.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItogovProjectM25.BLL.Service
{
    /// <summary>
    /// Класс для работы с сущностью Книга регистрации выдачи книг через репозиторий
    /// </summary>
    public class LibraryCardService
    {       
        readonly BookRepositories Br = new BookRepositories();
        readonly UserRepositories Ur = new UserRepositories();
        readonly LibraryCardRepositories Lr = new LibraryCardRepositories();

        /// <summary>
        /// Добавление записи в книгу выдачи
        /// </summary>
        public void Add()
        {
            var libraryCard = new LibraryCard();
            libraryCard.UserId = VvodUser();
            libraryCard.BookId = VvodBook();

            Console.WriteLine("Введите дату выдачи книги");
            string st = Console.ReadLine();

            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                libraryCard.DateOfIssue = st;
                libraryCard.DateOfReturn = null;


                Lr.Create(libraryCard);
            }
        }

        /// <summary>
        /// Выбор книги
        /// </summary>
        /// <returns>id выбрнной книги</returns>
        public int VvodBook()
        {
            int nom1;
            while (true)
            {
                Console.WriteLine("Выберите книгу из списка  (введите id)");
                foreach (var item in Lr.PoiskBookinLibrary())
                {
                    Console.WriteLine("Id= " + item.Id + " " + item.Name);
                }
                nom1 = Convert.ToInt32(Console.ReadLine());
                var book1 = Br.Get(nom1);

                if (book1 == null)
                {
                    Console.WriteLine("нет такой книги, попробуйте еще раз");
                }
                else break;
            }
            return nom1;
        }

        /// <summary>
        /// Выбор книги из заданного списка
        /// </summary>
        /// <param name="books">список книг</param>
        /// <returns>id книги</returns>
        public int VvodBook(List<Book> books)
        {
            int nom1;
            while (true)
            {
                Console.WriteLine("Выберите книгу из списка  (введите id)");
                foreach (var item in books)
                {
                    Console.WriteLine("Id= " + item.Id + " " + item.Name);
                }
                nom1 = Convert.ToInt32(Console.ReadLine());
                var book1 = Br.Get(nom1, books);

                if (book1 == null)
                {
                    Console.WriteLine("нет такой книги, попробуйте еще раз");
                }
                else break;
            }
            return nom1;
        }

        /// <summary>
        /// Выбор пользователя
        /// </summary>
        /// <returns>id пользователя</returns>
        public int VvodUser()
        {
            int nom1;
            while (true)
            {
                Console.WriteLine("Выберите пользователя из списка  (введите id)");
                foreach (var item in Ur.GetUsers())
                {
                    Console.WriteLine("Id= " + item.Id + " " + item.Name);
                }
                nom1 = Convert.ToInt32(Console.ReadLine());
                var user1 = Ur.GetUserbyId(nom1);
                if (user1 == null)
                {
                    Console.WriteLine("нет такого пользователя, попробуте еще раз");
                }
                else break;
            }
            return nom1;
        }

        /// <summary>
        /// Поиск пользователя из книги регистрации
        /// </summary>
        /// <returns> id пользователя</returns>
        public int VvodUserLibrary()
        {
            int nom1;
            while (true)
            {
                Console.WriteLine("Выберите пользователя из списка  (введите id)");
                foreach (var item in Lr.PoiskUserinLibrary())
                {
                    Console.WriteLine("Id= " + item.Id + " " + item.Name);
                }
                nom1 = Convert.ToInt32(Console.ReadLine());
                var user1 = Ur.GetUserbyId(nom1);
                if (user1 == null)
                {
                    Console.WriteLine("нет такого пользователя, попробуте еще раз");
                }
                else break;
            }
            return nom1;
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        public void DeleteLibraryCard()
        {
            Console.WriteLine("Введите id записи, которую хотите удалить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var library = Lr.GetbyId(nom);
            if (library is null) Console.WriteLine("нет такого id");
            else
                Lr.Delete(library);
        }

        /// <summary>
        /// Вывод данных обо всех записях в книге регистрации
        /// </summary>
        public void PrintAll()
        {
            Console.WriteLine("Книга регистрации:");
            Console.WriteLine(" ");

            foreach (var item in Lr.GetLibraryCard())
            {
                Console.WriteLine("_______________________________________________________ ");
                Console.WriteLine("Id: " + item.Id + " Дата выдачи:  " + item.DateOfIssue + " Дата возврата: " + item.DateOfReturn);
                Console.WriteLine($" Пользователь: Id= {item.UserId}  Имя: {item.User.Name} ");
                Console.WriteLine($" Книга:  Id= {item.BookId}  Название: {item.Book.Name}");
                Console.WriteLine("_______________________________________________________ ");
            }
        }

        /// <summary>
        /// Вывод данных о заданной записи
        /// </summary>
        public void GetLibraryCard()
        {
            Console.WriteLine("Введите id записи, которую хотите получить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var library = Lr.GetbyId(nom);
            if (library != null)
            {
                Console.WriteLine("Id: " + library.Id + " Дата выдачи:  " + library.DateOfIssue + " Дата возврата: " + library.DateOfReturn);
                Console.WriteLine($" Пользователь: Id= {library.UserId}  Имя: {library.User.Name} ");
                Console.WriteLine($" Книга:  Id= {library.BookId}  Название: {library.Book.Name}");
            }
            else Console.WriteLine("нет такого id");
        }


        /// <summary>
        /// Фиксация возврата книги по id записи
        /// </summary>
        public void UpdateDateOfReturn()
        {
            Console.WriteLine("Введите id записи, данные которой хотите изменить");
            int nom = Convert.ToInt32(Console.ReadLine());

            var library1 = Lr.GetbyId(nom);
            if (library1 != null)
            {
                Console.WriteLine("Введите дату возврата  книги");
                string st = Console.ReadLine();

                if (String.IsNullOrEmpty(st))
                    Console.WriteLine("Вы ввели некорректное значение");
                else
                {
                    Lr.UpdatebyId(library1.Id, st);
                }
            }
            else Console.WriteLine("нет такого id");
        }

        /// <summary>
        /// Фиксация возврата книги по id книги и id пользователя
        /// </summary>
        public void VvodDateOfReturn()
        {
            int iduser = VvodUserLibrary();

            var k = Lr.PoiskBookbyUser(iduser);
            int idbook = VvodBook(k);


            Console.WriteLine("Введите дату возврата книги");
            string st = Console.ReadLine();

            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                Lr.UpdatebyIdId(iduser, idbook, st);
            }
        }

        /// <summary>
        /// Поиск книг на руках у пользователя
        /// </summary>
        public void PoiskBookbyNameinUser()
        {
            Console.WriteLine("Введите название книги ");
            string st = Console.ReadLine();
            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                var book = Br.GetbyName(st);
                if (book != null)
                {
                    if (Lr.PoiskBookbyNameinUser(st))
                    {
                        Console.WriteLine(" Данная книга на руках у пользователя");
                    }
                    else Console.WriteLine(" Книга в библиотеке");
                }
                else Console.WriteLine("нет такой книги в библиотеке ");
            }
        }

        /// <summary>
        /// Поиск количества книг на руках у пользователя
        /// </summary>
        public void PoiskCountBookinUser()
        { 
            Console.WriteLine("Введите имя пользователя ");
            string st = Console.ReadLine();
            if (String.IsNullOrEmpty(st))
                Console.WriteLine("Вы ввели некорректное значение");
            else
            {
                var user = Ur.GetUserbyName(st);
                if (user != null)
                {
                    var kol = Lr.PoiskCountBooksinUsers(st);
                    if (kol!=0)
                    {
                        Console.WriteLine(" Количество книг на руках у пользователя  "+kol);
                    }
                    else Console.WriteLine(" У данного пользователя нет книг на руках");
                }
                else Console.WriteLine("нет такого пользователя ");
            }
        }
    }
    }
