using ItogovProjectM25.DAL.Models;
using ItogovProjectM25.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItogovProjectM25.DAL.Repositories
{
    class AutorRepositories : IAutorRepositories
    {
        /// <summary>
        /// Добавление нового автора
        /// </summary>
        /// <param name="autor">новые данные по автору</param>
        public void Create(Autor autor)
        {
            using (var db = new LibraryContext())
            {
                db.Autors.Add(autor);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Добавление книги автору
        /// </summary>
        /// <param name="idautor">Id автора</param>
        /// <param name="idbook">Id книги</param>
        public void AddBookinAutor(int idautor, int idbook)
        {
            using (var db = new LibraryContext())
            {
                var k = db.Autors.Include(c => c.Books).Where(c => c.Id == idautor).FirstOrDefault();
                var b = db.Books.Where(c => c.Id == idbook).FirstOrDefault();
                k.Books.Add(b);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение списка всех авторов
        /// </summary>
        /// <returns>список авторов</returns>
        public List<Autor> GetAutors()
        {
            using (var db = new LibraryContext())
            {
                return db.Autors.Include(c => c.Books).ToList();
            }
        }

        /// <summary>
        ///  Получение списка книг по Id автора
        /// </summary>
        /// <param name="idautor">Id автора</param>
        /// <returns>список книг</returns>
        public List<Book> GetBooksByAutor(int idautor)
        {
            using (var db = new LibraryContext())
            {
                var autor1 = db.Autors.Include(c => c.Books).Where(c => c.Id == idautor).FirstOrDefault();
                return autor1.Books.ToList();
            }
        }

        /// <summary>
        ///  Получение количества книг по имени автора 
        /// </summary>
        /// <param name="name">имя автора</param>
        /// <returns>количество книг</returns>
        public int GetCountBooksByAutor(string name)
        {
            using (var db = new LibraryContext())
            {
                var kol = db.Autors.Include(c => c.Books).Where(c => c.Name == name).FirstOrDefault();
                return kol.Books.Count();
            }
        }

        /// <summary>
        ///  Удаление автора
        /// </summary>
        /// <param name="autor"> объект Автор</param>
        public void Delete(Autor autor)
        {
            using (var db = new LibraryContext())
            {
                db.Autors.Remove(autor);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление имени автора по его Id
        /// </summary>
        /// <param name="idautor1">Id автора</param>
        /// <param name="name">новое имя</param>
        public void UpdateAutorNamebyId(int idautor1, string name)
        {
            using (var db = new LibraryContext())
            {
                var autor1 = db.Autors.Where(m => m.Id == idautor1).FirstOrDefault();
                autor1.Name = name;
                db.Autors.Update(autor1);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение данных об авторе по его Id 
        /// </summary>
        /// <param name="id">Id автора</param>
        /// <returns>данные по автору</returns>
        public Autor GetAutorbyId(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Autors.Include(c => c.Books).Where(m => m.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение данных об авторе по его имени
        /// </summary>
        /// <param name="name">имя автора</param>
        /// <returns>данные по автору</returns>
        public Autor GetAutorbyName(string name)
        {
            using (var db = new LibraryContext())
            {
                return db.Autors.Include(c => c.Books).Where(m => m.Name == name).FirstOrDefault();
            }
        }

        /// <summary>
        /// Поиск книги по автору
        /// </summary>
        /// <param name="idbook">Id книги</param>
        /// <param name="idautor">Id автора</param>
        /// <returns>есть или нет</returns>
        public bool PoiskBookbyAutor(int idbook, int idautor)
        {
            using (var db = new LibraryContext())
            {
                var k = (db.Autors.Include(c => c.Books).Where(c => c.Id == idautor)).FirstOrDefault();

                var p = k.Books.Where(c => c.Id == idbook).FirstOrDefault();
                if (p != null)
                { return true; }
                else return false;
            }
        }

        /// <summary>
        /// Определение есть ли книга данного автора и с заданным названием в библиотеке
        /// </summary>
        /// <param name="nameautor">имя автора</param>
        /// <param name="namebook">название книги</param>
        /// <returns></returns>
        public bool PoikBookByAutorAndName(string nameautor, string namebook)
        {
            using (var db = new LibraryContext())
            {
                var h = db.Autors.Include(c => c.Books).Where(c => c.Name == nameautor).FirstOrDefault();

                var t = from k in h.Books.ToList()
                        where k.Name == namebook
                        select k;
                if (t.Count() != 0) return true;
                else return false;
            }
        }
    }
}
