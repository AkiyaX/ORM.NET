using System;
using System.Diagnostics;

namespace Main
{
    class Program
    {
        static void DapperRun()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var repository = new ORM.Dapper.CityRepository();
            var city = repository.GetCity(1);
            Console.WriteLine($"City name: {city.Name}, country name: {city.Country}.");

            stopwatch.Stop();
            Console.WriteLine($"Dapper runtime: {stopwatch.ElapsedMilliseconds} ms.");
        }

        static void EFCoreRun()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var repository = new ORM.EF.CityRepository();
            var city = repository.GetCity(2);
            Console.WriteLine($"City name: {city.Name}, country name: {city.CountryCodeNavigation.Name}");

            stopwatch.Stop();
            Console.WriteLine($"EFCore runtime: {stopwatch.ElapsedMilliseconds} ms.");
        }

        static void Main(string[] args)
        {
            DapperRun();
            EFCoreRun();
        }
    }
}
