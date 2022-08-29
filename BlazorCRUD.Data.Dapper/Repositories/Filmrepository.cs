using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public class Filmrepository : IFilmrepository
    {
        private string ConnectionString;

        public Filmrepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection() { return new SqlConnection(ConnectionString); }

        public Task<bool> DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Film>> GetAllFilms()
        {
            var db=dbConnection();
            var sql = @"SELECT Id, Title, Director, ReleaseDate 
                       FROM [BlazorCRUD].[dbo].[Films]";
            return await db.QueryAsync<Film>(sql.ToString(), new { });
        }

        public async Task<Film> GetFilmDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT Id, Title, Director, ReleaseDate 
                       FROM [BlazorCRUD].[dbo].[Films]
                       WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Film>(sql.ToString(), new {Id = id});
        }

        public async Task<bool> InsertFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"
                        insert into Films(Title, Director, ReleaseDate)
                        values (@Title, @Director, @ReleaseDate)";

            var result = await db.ExecuteAsync(sql.ToString(),
                new { film.Title, film.Director, film.ReleaseDate });
            return result > 0;
        }

        public async Task<bool> UpdateFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Films SET Title = @Title, Director = @Director, ReleaseDate = @ReleaseDate 
                        WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql.ToString(),
                new { film.Title, film.Director, film.ReleaseDate });
            return result > 0;
        }
    }
}
