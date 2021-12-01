using ItogovProjectM25.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItogovProjectM25.Repositories
{
    public class GenreRepositories : IGenreRepositories
    {
        /// <summary>
        /// Добавление нового жанра
        /// </summary>
        /// <param name="genre">данные об новом жанре</param>
        public void Create(Genre genre)
        {
            using (var db = new LibraryContext())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение списка всех жанров
        /// </summary>
        /// <returns>список жанров</returns>
        public List<Genre> GetGenres()
        {
            using (var db = new LibraryContext())
            {
                return db.Genres.Include(c => c.Books).ToList();
            }
        }

        /// <summary>
        /// Удаление жанра
        /// </summary>
        /// <param name="genre">объект жанр</param>
        public void Delete(Genre genre)
        {
            using (var db = new LibraryContext())
            {
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление названия жанра
        /// </summary>
        /// <param name="id">id жанра</param>
        /// <param name="name">новое название жанра</param>
        public void UpdateName(int id, string name)
        {
            using (var db = new LibraryContext())
            {
                var genre1 = db.Genres.Where(m => m.Id == id).FirstOrDefault();
                genre1.Name = name;
                db.Genres.Update(genre1);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение данных жанра по его id
        /// </summary>
        /// <param name="id">id жанра</param>
        /// <returns>объект жанр</returns>
        public Genre Get(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Genres.Include(c => c.Books).Where(m => m.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение данных жанра по его названию
        /// </summary>
        /// <param name="name">название жанра</param>
        /// <returns>объект жанр</returns>
        public Genre GetByName(string name)
        {
            using (var db = new LibraryContext())
            {
                return db.Genres.Include(c => c.Books).Where(m => m.Name == name).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получить список книг по названию жанра
        /// </summary>
        /// <param name="name">название жанра</param>
        /// <returns>список книг</returns>
        public List<Book> GetBooksByNameGenre(string name)
        {
            using (var db = new LibraryContext())
            {
                var k = db.Genres.Include(c => c.Books).Where(m => m.Name == name).FirstOrDefault();
                return k.Books.ToList();
            }
        }

        /// <summary>
        /// Получить список книг по Id жанра
        /// </summary>
        /// <param name="id">Id жанра</param>
        /// <returns>список книг</returns>
        public List<Book> GetBooksByIdGenre(int id)
        {
            using (var db = new LibraryContext())
            {
                var genre1 = db.Genres.Include(c => c.Books).Where(c => c.Id == id).FirstOrDefault();
                return genre1.Books.ToList();
            }
        }

        /// <summary>
        /// Добавление книги к жанру
        /// </summary>
        /// <param name="idgenre">id жанра</param>
        /// <param name="idbook">id книги</param>
        public void AddBookinGenre(int idgenre, int idbook)
        {
            using (var db = new LibraryContext())
            {
                var genre1 = db.Genres.Include(c => c.Books).Where(c => c.Id == idgenre).FirstOrDefault();
                var book = db.Books.Where(c => c.Id == idbook).FirstOrDefault();
                genre1.Books.Add(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск книги в жанре
        /// </summary>
        /// <param name="idbook">Id книги</param>
        /// <param name="idgenre">Id жанра</param>
        /// <returns></returns>
        public bool PoiskBookinGenre(int idbook, int idgenre)
        {
            using (var db = new LibraryContext())
            {
                var k = (db.Genres.Include(c => c.Books).Where(c => c.Id == idgenre)).FirstOrDefault();
                var p = k.Books.Where(c => c.Id == idbook).FirstOrDefault();
                if (p != null)
                { return true; }
                else return false;
            }
        }

        /// <summary>
        ///  Получение количества книг по жанру
        /// </summary>
        /// <param name="name">название жанра</param>
        /// <returns>количество книг</returns>
        public int GetCountBooksByGenre(string name)
        {
            using (var db = new LibraryContext())
            {
                var kol = db.Genres.Include(c => c.Books).Where(c => c.Name == name).FirstOrDefault();
               
                return kol.Books.Count();
            }
        }

    }
}
