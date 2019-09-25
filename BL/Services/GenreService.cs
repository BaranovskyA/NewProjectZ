using BusinessLayer.BInterfaces;
using BusinessLayer.BModel;
using BusinessLayer.Utils;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class GenreService : IGenreService
    {
        IUnitOfWork Database { get; set; }

        public GenreService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrUpdate(BGenre genre)
        {
            if (genre.Id == 0)
            {

                Genre dgenre = new Genre() { Name=genre.Name };
                Database.Genre.Create(dgenre);
            }
            else
            {
                Genre editGenre = AutoMapper<BGenre, Genre>.Map(genre);
                Database.Genre.Update(editGenre);
            }
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BGenre GetGenre(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Genre, BGenre>.Map(Database.Genre.Get, (int)id);
            }
            return new BGenre();
        }

        public IEnumerable<BGenre> GetGenres()
        {
            return AutoMapper<IEnumerable<Genre>, List<BGenre>>.Map(Database.Genre.GetAll);
        }

        public void DeleteGenre(int id)
        {
            Database.Genre.Delete(id);
            Database.Save();
        }

    }
}
