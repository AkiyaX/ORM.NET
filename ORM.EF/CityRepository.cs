using Microsoft.EntityFrameworkCore;
using ORM.EF.Models;
using System.Linq;

namespace ORM.EF
{
    public class CityRepository
    {
        private readonly WorldContext db;
        public CityRepository()
        {
            db = new WorldContext();
        }

        public City GetCity(int Id)
        {
            var result = db.Cities.Include(city => city.CountryCodeNavigation).Where(city => city.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
