using ItogovProjectM25.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItogovProjectM25.DAL.Repositories
{
   public class LibraryCardRepositories:ILibraryCardRepositories
    {
        /// <summary>
        /// Добавление записи в библиотечную нигу по выдаче книги
        /// </summary>
        /// <param name="libraryCard"> объект записи</param>
        public void Create(LibraryCard libraryCard)
        {
            using (var db = new LibraryContext())
            {
                db.LibraryCards.Add(libraryCard);
                db.SaveChanges();
            }

        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="libraryCard"> объект записи</param>
        public void Delete(LibraryCard libraryCard)
        {
            using (var db = new LibraryContext())
            {
                db.LibraryCards.Remove(libraryCard);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение данных  по id
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns>данные о записи</returns>
       public LibraryCard GetbyId(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.LibraryCards.Include(c => c.Book).Include(c => c.User).Where(m => m.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение данных о всех записях
        /// </summary>
        /// <returns>список пользователей</returns>
       public List<LibraryCard> GetLibraryCard()
        {
            using (var db = new LibraryContext())
            {
                return db.LibraryCards.Include(c=>c.Book).Include(c=>c.User).ToList();
            }
        }

        /// <summary>
        /// Фиксация возврата книги по id
        /// </summary>
        /// <param name="id">id записи</param>
        /// <param name="yearreturn">дата возврата книги</param>
       public void UpdatebyId(int id, string yearreturn)
        {
            using (var db = new LibraryContext())
            {
                var c = db.LibraryCards.Where(c => c.Id == id).FirstOrDefault();
                c.DateOfReturn = yearreturn;
                db.LibraryCards.Update(c);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Фиксация даты возврата книги по id пользователя и id книги
        /// </summary>
        /// <param name="iduser">id пользователя</param>
        /// <param name="idbook">id книги</param>
        /// <param name="yearreturn">дата возврата книги</param>
        public void UpdatebyIdId(int iduser,int idbook, string yearreturn)
        {
            using (var db = new LibraryContext())
            {
                var c = db.LibraryCards.Where(c => c.UserId == iduser).Where(c => c.BookId == idbook).Where(c => c.DateOfReturn == null).FirstOrDefault(); 
                c.DateOfReturn = yearreturn;
                db.LibraryCards.Update(c);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск списка книг, которые на руках у Пользователя
        /// </summary>
        /// <param name="iduser">id пользователя</param>
        /// <returns>список книг</returns>
        public List<Book> PoiskBookbyUser(int iduser)
        {
            using (var db = new LibraryContext())
            {
                var c = db.LibraryCards.Include(c=>c.Book).Where(c => c.UserId == iduser).Where(c => c.DateOfReturn == null).ToList() ;
                var k = from u in c.ToList()
                        select u.Book;
                return k.ToList();
                        
            }
        }

        /// <summary>
        /// Поиск списка пользователей, у которых книги на руках
        /// </summary>
        /// <returns>список пользователей</returns>
        public List<User> PoiskUserinLibrary()
        {
            using (var db = new LibraryContext())
            {
                var c = db.LibraryCards.Include(c => c.User).Where(c => c.DateOfReturn == null).ToList();
                var k = from u in c.ToList()
                        select u.User;
                return k.Distinct().ToList();

            }
        }

        /// <summary>
        /// Поик даты выдачи книги по id книги и id пользователя
        /// </summary>
        /// <param name="idbook">id книги</param>
        /// <param name="iduser">id пользователя</param>
        /// <returns>дата выдачи книги</returns>
        public string PoiskDataIssueinLibrary(int idbook, int iduser)
        {
            using (var db = new LibraryContext())
            {
                var c = db.LibraryCards.Where(m =>m.UserId==iduser).Where(m=>m.BookId==idbook).Where(c => c.DateOfReturn == null).FirstOrDefault();
                
                return c.DateOfIssue.ToString();

            }
        }

        /// <summary>
        /// Определение есть ли книга на руках у пользователя
        /// </summary>
        /// <param name="name">назваие книги</param>
        /// <returns>есть или нет</returns>
       public bool PoiskBookbyNameinUser(string name)
        {
            using (var db = new LibraryContext())
            {
                var c = db.Books.Where(c => c.Name == name).FirstOrDefault();

                var p = from l in db.LibraryCards.ToList()
                         where l.DateOfReturn == null 
                         where l.Book.Id==c.Id
                         select l;
                if (p.Count() != 0) return true;
                else return false;
            }
        }

        /// <summary>
        /// Поиск списка книг, находящихся в библиотеке
        /// </summary>
        /// <returns>список книг</returns>
        public List<Book> PoiskBookinLibrary()
        {
            using (var db = new LibraryContext())
            {
                var k = db.LibraryCards.Where(c => c.DateOfReturn == null).ToList();
                var rezult1 = from u in k.ToList()
                              select u.Book;
                var rezult2 = db.Books.Include(c => c.Autors).Include(m => m.Genres).ToList();

                return rezult2.Except(rezult1).ToList();
            }
        }

        /// <summary>
        /// Поиск списка книг у Пользователя на руках
        /// </summary>
        /// <returns>список книг</returns>
        public List<Book> PoiskBookinUsers()
        {
            using (var db = new LibraryContext())
            {
                var k = db.LibraryCards.Where(c => c.DateOfReturn == null).ToList();
                var rezult1 = from u in k.ToList()
                        select u.Book;

                var rezult2 = db.Books.Include(c => c.Autors).Include(m => m.Genres).ToList();

                return rezult2.Intersect(rezult1).ToList();
            }
        }

        /// <summary>
        /// Нахождение количества книг у пользователя
        /// </summary>
        /// <param name="name">имя пользователя/param>
        /// <returns>количество книг</returns>
       public int PoiskCountBooksinUsers(string name)
        {
            using (var db = new LibraryContext())
            {
                var k = db.LibraryCards.Where(c => c.DateOfReturn == null).Where(c=>c.User.Name==name).ToList();

                return k.Count();
            }
        }


    }
}
