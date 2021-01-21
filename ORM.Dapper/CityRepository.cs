using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Dapper
{
    public class CityRepository
    {
        private readonly IDbConnection _conn;
        const string _connString = "Data Source=127.0.0.1;port=3306;Initial Catalog=world;User Id=test;Password=test@123;pooling=false;CharSet=utf8;";
        public CityRepository()
        {
            _conn = new MySqlConnection(_connString);
        }

        public City GetCity(int Id)
        {
            var sql = "SELECT city.Name,c.Name as Country,District, city.Population FROM city JOIN country c on c.Code = city.CountryCode WHERE city.ID = @Id";
            var result = _conn.QueryFirst<City>(sql, new { Id });
            return result;
        }
    }
}
