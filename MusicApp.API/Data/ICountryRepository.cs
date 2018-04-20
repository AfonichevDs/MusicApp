using System.Collections.Generic;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface ICountryRepository: IRepository<Country>
    {
        string GetCountryNameById(int id);
    }
}