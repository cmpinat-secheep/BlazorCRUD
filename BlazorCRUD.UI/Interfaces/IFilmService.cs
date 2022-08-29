using BlazorCRUD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetallFilms(); 
        Task<Film> GetDetails(int id);
        Task<bool> DeleteFilm(int id);
        Task<bool> SaveFilm(Film film);
        Task<bool> InsertFilm(Film film);
    }
}
