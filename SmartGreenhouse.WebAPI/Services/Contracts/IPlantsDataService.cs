using System.Collections.Generic;
using SmartGreenhouse.WebAPI.Models;

namespace SmartGreenhouse.WebAPI.Services.Contracts
{
    public interface IPlantsDataService
    {
        IEnumerable<Plant> GetAllPlants();

        Plant GetPlantById(int id);

        void CreatePlant(Plant plant);

        void UpdatePlant(Plant plant);

        void DeletePlant(Plant plant);
    }
}
