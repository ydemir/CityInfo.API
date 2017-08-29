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
                Description = "Tiftik keçisi ünlüdür.",
                 PointOfInterest=new List<PointOfInterestDTO>()
                 {
                     new PointOfInterestDTO()
                     {
                         Id=1,
                         Name="Kızılcahamam Hamamı",
                         Description="Kızılcahamamda yer alan hamam"
                     },
                     new PointOfInterestDTO()
                     {
                         Id=2,
                         Name="Ankara Kalesi",
                         Description="Ankaranın simgesidir."
                     }
                 }
                 },
                new CityDTO()
                {
                 Id = 2,
                 Name = "Sakarya",
                 Description = "Islama köftesi meşhurdur",
                 PointOfInterest=new List<PointOfInterestDTO>()
                    {
                     new PointOfInterestDTO()
                     {
                         Id=3,
                         Name="Akyazı Hamamı",
                         Description="Kuzulukta yer alan hamam"
                     },
                     new PointOfInterestDTO()
                     {
                         Id=4,
                         Name="Kefken sahili",
                         Description="Sakaryanın kuzeyinde izmite dahil olan bir sahil"
                     }
                    }
                 },

                new CityDTO()
                {
                 Id = 3,
                 Name = "Antalya",
                 Description = "Deniz kenarları otelleri ünlüdür",
                 PointOfInterest=new List<PointOfInterestDTO>()
                 {
                     new PointOfInterestDTO()
                     {
                         Id=5,
                         Name="Olimpus",
                         Description="Antalyada kemerde bulunan olimpus dağındaki yer"
                     },
                     new PointOfInterestDTO()
                     {
                         Id=6,
                         Name="Manavgat Şelalesi",
                         Description="Antalyada yer alan şelale"
                     }
                 }
                }
             };
        }
    }
}
