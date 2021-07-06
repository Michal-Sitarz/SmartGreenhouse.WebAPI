using System;
using System.Collections.Generic;
using System.Linq;
using SmartGreenhouse.WebAPI.Data;
using SmartGreenhouse.WebAPI.Models;
using SmartGreenhouse.WebAPI.Services.Contracts;

namespace SmartGreenhouse.WebAPI.Services
{
    public class PlantsDataService : IPlantsDataService
    {
        private readonly AppDbContext _dbContext;

        public PlantsDataService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Plant> GetAllPlants()
        {
            return _dbContext.Plants.ToList();
        }

        public Plant GetPlantById(int id)
        {
            return _dbContext.Plants.FirstOrDefault(x => x.Id == id);
        }

        public void CreatePlant(Plant plant)
        {
            if(plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            _dbContext.Plants.Add(plant);
            _dbContext.SaveChanges();
        }
        
        public void UpdatePlant(Plant plant)
        {
            // no implementation required for now
            // dbContext updated automatically during mapping on the Controller

            _dbContext.SaveChanges();
        }

        public void DeletePlant(Plant plant)
        {
            if(plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            _dbContext.Plants.Remove(plant);
            _dbContext.SaveChanges();
        }

    }
}
