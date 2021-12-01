using ItogovProjectM25.DAL.Models;
using ItogovProjectM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItogovProjectM25.DAL.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="user">новые данные по пользователю</param>
        public void Create(User user)
        {
            using (var db = new LibraryContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns>список пользователей</returns>
        public List<User> GetUsers()
        {
            using (var db = new LibraryContext())
            {
                return db.Users.ToList();
            }
        }

        /// <summary>
        ///  Удаление пользователя
        /// </summary>
        /// <param name="user"> объект Пользователь</param>
        public void Delete(User user)
        {
            using (var db = new LibraryContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление имени пользователя по его Id
        /// </summary>
        /// <param name="iduser">Id пользователя</param>
        /// <param name="name">новое имя</param>
        public void UpdateNamebyId(int iduser, string name)
        {
            using (var db = new LibraryContext())
            {
                var user1 = db.Users.Where(m => m.Id == iduser).FirstOrDefault();
                user1.Name = name;
                db.Users.Update(user1);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение данных о пользователе по его Id 
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns>данные по пользователю</returns>
        public User GetUserbyId(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Users.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение пользователя по имени
        /// </summary>
        /// <param name="name">имя пользователя</param>
        /// <returns>объект пользователь</returns>
        public User GetUserbyName(string name)
        {
            using (var db = new LibraryContext())
            {
                return db.Users.Where(m => m.Name == name).FirstOrDefault();
            }
        }
    }
}
