using System;
using System.Collections.Generic;
using System.Linq;
using SmartGreenhouse.WebAPI.Data;
using SmartGreenhouse.WebAPI.Models;
using SmartGreenhouse.WebAPI.Services.Contracts;

namespace SmartGreenhouse.WebAPI.Services
{
    public class SensorNodesDataService : ISensorNodesDataService
    {
        private readonly AppDbContext _dbContext;

        public SensorNodesDataService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SensorNode> GetAllSensorNodes()
        {
            return _dbContext.SensorNodes.ToList();
        }

        public SensorNode GetSensorNodeById(int id)
        {
            return _dbContext.SensorNodes.FirstOrDefault(x => x.Id == id);
        }

        public void CreateSensorNode(SensorNode SensorNode)
        {
            if(SensorNode == null)
            {
                throw new ArgumentNullException(nameof(SensorNode));
            }

            _dbContext.SensorNodes.Add(SensorNode);
            _dbContext.SaveChanges();
        }
        
        public void UpdateSensorNode(SensorNode SensorNode)
        {
            // no implementation required for now
            // dbContext updated automatically during mapping on the Controller

            _dbContext.SaveChanges();
        }

        public void DeleteSensorNode(SensorNode SensorNode)
        {
            if(SensorNode == null)
            {
                throw new ArgumentNullException(nameof(SensorNode));
            }

            _dbContext.SensorNodes.Remove(SensorNode);
            _dbContext.SaveChanges();
        }

    }
}
