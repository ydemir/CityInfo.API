using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;
        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }
        [HttpGet()]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);

            var cityEntities = _cityInfoRepository.GetCities();

            var result = new List<CityWithoutPointsOfInterestDTO>();

            foreach (var cityEntity in cityEntities)
            {
                result.Add(new CityWithoutPointsOfInterestDTO
                {
                    Id=cityEntity.Id,
                    Name=cityEntity.Name,
                    Description=cityEntity.Description
                });
            }

            return Ok(result);
          
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest=false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city==null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = new CityDTO()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                };

                foreach (var poi in city.PointOfInterest)
                {
                    cityResult.PointOfInterest.Add(
                        new PointOfInterestDTO()
                        {
                            Id=poi.Id,
                            Name=poi.Name,
                            Description=poi.Description
                        });
                }
                return Ok(cityResult);
            }

            var cityWithoutPoinstOfInterestResult =
                new CityWithoutPointsOfInterestDTO()
                {
                    Id = city.Id,
                    Description = city.Description,
                    Name = city.Name
                };
            return Ok(cityWithoutPoinstOfInterestResult);


            ////find city
            //var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            //if (cityToReturn==null)
            //{
            //    return NotFound();
            //}
            //return Ok(cityToReturn);
        }

    }


}
