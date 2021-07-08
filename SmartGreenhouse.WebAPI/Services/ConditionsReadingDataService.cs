using System;
using System.Collections.Generic;
using System.Linq;
using SmartGreenhouse.WebAPI.Data;
using SmartGreenhouse.WebAPI.Models;
using SmartGreenhouse.WebAPI.Services.Contracts;

namespace SmartGreenhouse.WebAPI.Services
{
    public class ConditionsReadingsDataService : IConditionsReadingsDataService
    {
        private readonly AppDbContext _dbContext;

        public ConditionsReadingsDataService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ConditionsReading> GetAllConditionsReadings()
        {
            return _dbContext.ConditionsReadings.ToList();
        }

        public ConditionsReading GetConditionsReadingById(int id)
        {
            return _dbContext.ConditionsReadings.FirstOrDefault(x => x.Id == id);
        }

        public void CreateConditionsReading(ConditionsReading ConditionsReading)
        {
            if(ConditionsReading == null)
            {
                throw new ArgumentNullException(nameof(ConditionsReading));
            }

            _dbContext.ConditionsReadings.Add(ConditionsReading);
            _dbContext.SaveChanges();
        }
        
        public void UpdateConditionsReading(ConditionsReading ConditionsReading)
        {
            // no implementation required for now
            // dbContext updated automatically during mapping on the Controller

            _dbContext.SaveChanges();
        }

        public void DeleteConditionsReading(ConditionsReading ConditionsReading)
        {
            if(ConditionsReading == null)
            {
                throw new ArgumentNullException(nameof(ConditionsReading));
            }

            _dbContext.ConditionsReadings.Remove(ConditionsReading);
            _dbContext.SaveChanges();
        }

    }
}
