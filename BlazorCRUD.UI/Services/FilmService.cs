using BlazorCRUD.Data.Dapper.Repositories;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Services
{
    public class FilmService : IFilmService
    {
        private readonly SqlConfiguration _configuration;
        private IFilmrepository _filmRepository;
        public FilmService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _filmRepository = new Filmrepository(configuration.ConnectionString);

        }
        public Task<bool> DeleteFilm(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Film>> GetallFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        public Task<Film> GetDetails(int id)
        {
            return _filmRepository.GetFilmDetails(id);
        }

        public Task<bool> InsertFilm(Film film)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveFilm(Film film)
        {
            if (film.id == 0)
                return _filmRepository.InsertFilm(film);
            else
                return _filmRepository.UpdateFilm(film);
        }
    }
}