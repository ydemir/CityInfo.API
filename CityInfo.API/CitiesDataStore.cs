using CityInfo.API.Models;
using System.Collections.Generic;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDTO> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDTO>()
            {
                new CityDTO()
                {
                Id = 1,
                Name = "Ankara",
                Description = "Tiftik keçisi ünlüdür."
                 },
                new CityDTO()
                {
                 Id = 2,
                 Name = "Sakarya",
                 Description = "Islama köftesi meşhurdur"
                 },
                new CityDTO()
                {
                 Id = 3,
                 Name = "Antalya",
                 Description = "Deniz kenarları otelleri ünlüdür"
                }
             };
        }
    }
}
