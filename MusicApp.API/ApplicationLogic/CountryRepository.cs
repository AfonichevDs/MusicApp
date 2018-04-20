using Microsoft.EntityFrameworkCore;
using MusicApp.API.Data;
using MusicApp.API.Models;

namespace MusicApp.API.ApplicationLogic
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context): base(context) {}

        public string GetCountryNameById(int id)
        {
            return context.Set<Country>().Find(id).Name;
        }
    }
}