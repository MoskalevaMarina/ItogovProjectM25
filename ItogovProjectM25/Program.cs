using System;
using ItogovProjectM25.BLL.Service;
using ItogovProjectM25.Models;
using ItogovProjectM25.PLL.Views;
using ItogovProjectM25.Repositories;
using ItogovProjectM25.Service;

namespace ItogovProjectM25
{
    class Program
    {
        static GenreService gs;
        static BookService bs;
        static AutorService autorService;
        static UserService us;
        static LibraryCardService Ls;
        public static MainView mainView;
        public static GenreMenuView genreMenuView;
        public static AutorMenuView autorMenuView;
        public static BookMenuView bookMenuView;
        public static UserMenuView userMenuView;
        public static LibraryCardMenuView libraryCardMenuView;
        public static RequestsMenuView requestsMenu;

        static void Main()
        {
          //  GenreRepositories genreRepositories = new GenreRepositories();
            gs = new GenreService();
            autorService = new AutorService();
            bs = new BookService();
            us = new UserService();
            Ls = new LibraryCardService();

            mainView = new MainView();
            genreMenuView = new GenreMenuView(gs);
            bookMenuView = new BookMenuView(bs);
            autorMenuView = new AutorMenuView(autorService);
            userMenuView = new UserMenuView(us);
            libraryCardMenuView = new LibraryCardMenuView(Ls);
            requestsMenu = new RequestsMenuView(bs, autorService, Ls, gs);

            while (true)
            {
                mainView.Show();
            }
           
        }
    }
}




















