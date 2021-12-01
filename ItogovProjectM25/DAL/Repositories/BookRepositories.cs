using ItogovProjectM25.DAL.Models;
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ItogovProjectM25.DAL.Repositories
{
    class BookRepositories : IBookRepositories
    {
        /// <summary>
        /// Добавление новой книги
        /// </summary>
        /// <param name="book"> объект книга</param>
        public void Create(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="book">объект книга</param>
        public void Delete(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление названия книги по ее Id
        /// </summary>
        /// <param name="idbook">Id книги</param>
        /// <param name="name">новое название</param>
        public void UpdateNameBookById(int idbook, string name)
        {
            using (var db = new LibraryContext())
            {
                var c = db.Books.Include(c => c.Autors).Include(c => c.Genres).Where(c => c.Id == idbook).FirstOrDefault();
                c.Name = name;
                db.Books.Update(c);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление года издания книги по ее Id
        /// </summary>
        /// <param name="idbook">Id книги</param>
        /// <param name="yearnew">новый год выпуска</param>
        public void UpdateYearBookById(int idbook, int yearnew)
        {
            using (var db = new LibraryContext())
            {
                var c = db.Books.Include(c => c.Autors).Include(c => c.Genres).Where(c => c.Id == idbook).FirstOrDefault();
                c.YearOfIssue = yearnew;
                db.Books.Update(c);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получить данные о книге по ее id
        /// </summary>
        /// <param name="id">id книги</param>
        /// <returns>данные о книге в форме Book</returns>
        public Book Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Include(c => c.Autors).Include(c => c.Genres).Where(m => m.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение книги из заданного списка по id
        /// </summary>
        /// <param name="id"> id книги</param>
        /// <param name="books">список книг</param>
        /// <returns>объект книга</returns>
        public Book Get(int id, List<Book> books)
        {
            using (var db = new LibraryContext())
            {
                return books.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение списка всех книг
        /// </summary>
        /// <returns>список книг</returns>
        public List<Book> GetBooks()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Include(c => c.Autors).Include(c => c.Genres).ToList();
            }
        }

        /// <summary>
        /// Получение списка авторов по Id книги
        /// </summary>
        /// <param name="idbook">Id книги</param>
        /// <returns>список авторов</returns>
        public List<Autor> GetAutorsbyBook(int idbook)
        {
            using (var db = new LibraryContext())
            {
                var users = (from g in db.Books.Include(c => c.Autors)
                             where g.Id == idbook
                             select g.Autors).FirstOrDefault();
                return users.ToList<Autor>();
            }
        }

        /// <summary>
        /// Получение жанров по Id книги
        /// </summary>
        /// <param name="idbook"> Id книги</param>
        /// <returns> список жанров</returns>
        public List<Genre> GetGenresbyBook(int idbook)
        {
            using (var db = new LibraryContext())
            {
                var users = (from g in db.Books.Include(c => c.Genres)
                             where g.Id == idbook
                             select g.Genres).FirstOrDefault();

                return users.ToList<Genre>();
            }
        }

        /// <summary>
        /// Добавление автора к книге
        /// </summary>
        /// <param name="idbook">Id книги</param>
        /// <param name="idautor">Id автора</param>
        public void AddAutorinBook(int idbook, int idautor)
        {
            using (var db = new LibraryContext())
            {
                var k = (db.Books.Include(c => c.Autors).Where(c => c.Id == idbook)).FirstOrDefault();
                var a = db.Autors.Where(c => c.Id == idautor).FirstOrDefault();
                k.Autors.Add(a);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Добавление жанра к книге
        /// </summary>
        /// <param name="idbook"> Id книги</param>
        /// <param name="idgenre">Id автора</param>
        public void AddGenreinBook(int idbook, int idgenre)
        {
            using (var db = new LibraryContext())
            {
                var k = (db.Books.Include(c => c.Genres).Where(c => c.Id == idbook)).FirstOrDefault();
                var g = db.Genres.Where(c => c.Id == idgenre).FirstOrDefault();
                k.Genres.Add(g);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск заданного жанра в книге
        /// </summary>
        /// <param name="idbook"> Id книги</param>
        /// <param name="idgenre"> Id жанра</param>
        /// <returns>есть или нет</returns>
        public bool PoiskGenreinBook(int idbook, int idgenre)
        {
            using (var db = new LibraryContext())
            {
                var k = (db.Books.Include(c => c.Genres).Where(c => c.Id == idbook)).FirstOrDefault();

                var p = k.Genres.Where(c => c.Id == idgenre).FirstOrDefault();
                if (p != null)
                { return true; }
                else return false;
            }
        }

        /// <summary>
        /// Поиск заданного автора в книге
        /// </summary>
        /// <param name="idbook">Id книги</param>
        /// <param name="idautor">Id автора</param>
        /// <returns>сть или нет</returns>
        public bool PoiskAutorinBook(int idbook, int idautor)
        {
            using (var db = new LibraryContext())
            {
                var k = (db.Books.Include(c => c.Autors).Where(c => c.Id == idbook)).FirstOrDefault();

                var p = k.Autors.Where(c => c.Id == idautor).FirstOrDefault();
                if (p != null)
                { return true; }
                else return false;
            }
        }

        /// <summary>
        /// Получение списка книг по жанру и между годами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="year1">данне по первому году</param>
        /// <param name="year2">данные по второму году</param>
        /// <returns>список книг</returns>
        public List<Book> GetBooksbyGenre(string name, int year1, int year2)
        {
            using (var db = new LibraryContext())
            {
                var k = db.Books.Include(c => c.Autors).Include(c => c.Genres).ToList();

                var p = from l in k.ToList()
                        where l.YearOfIssue > year1
                        where l.YearOfIssue < year2
                        where l.Genres.Any(c => c.Name == name)
                        select l;
                return p.ToList();
            }
        }

        /// <summary>
        /// Получение книги по ее названию
        /// </summary>
        /// <param name="name">название книги</param>
        /// <returns>объект Книга</returns>
        public Book GetbyName(string name)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Include(c => c.Autors).Include(c => c.Genres).Where(m => m.Name == name).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение книги, вышедшей последней
        /// </summary>
        /// <returns>объект Книга</returns>
        public Book GetbyYearMax()
        {
            using (var db = new LibraryContext())
            {
               var year1= db.Books.Max(m => m.YearOfIssue);

                return db.Books.Include(c => c.Autors).Include(c => c.Genres).Where(m => m.YearOfIssue==year1).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение списка книг отсортированного по имени
        /// </summary>
        /// <returns>список книг</returns>
        public List<Book> GetBooksSortbyName()
        {
            using (var db = new LibraryContext())
            {
                var k = db.Books.Include(c => c.Autors).Include(c => c.Genres).OrderBy(c=>c.Name).ToList();

                return k;
            }
        }

        /// <summary>
        /// Получение списка книг отсортированного в порядке убывания года их выхода
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksSortbyDescedingYear()
        {
            using (var db = new LibraryContext())
            {
                var k = db.Books.Include(c => c.Autors).Include(c => c.Genres).OrderByDescending(c => c.YearOfIssue).ToList();

                return k;
            }
        }

    }
}
