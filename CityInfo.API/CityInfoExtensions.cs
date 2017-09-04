﻿using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            //Init Seed Data

            var cities = new List<City>()
             {
                new City()
                {
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest()
                         {
                             Name="Central Park",
                             Description="The most visited urban park in the United States"
                         },
                         new PointOfInterest()
                         {
                             Name="Empire State Building",
                             Description="A 102-story skyscraper located in Midtown Manhattan."
                         },
                     }
                },
                new City()
                 {
                     Name = "Paris",
                     Description = "The one  with that big tower.",
                     PointOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest()
                         {
                             Name="Eiffel Tower",
                             Description="A wrought iron lattice tower on the"
                         },
                         new PointOfInterest()
                         {
                             Name="The Louvre",
                             Description="The world largest museum"
                         }
                     }
                 }
             };

            context.Cities.AddRange(cities);
            context.SaveChanges();  
        }
    }
}





