using System.Collections.Generic;
using SmartGreenhouse.WebAPI.Models;

namespace SmartGreenhouse.WebAPI.Services.Contracts
{
    public interface IConditionsReadingsDataService
    {
        IEnumerable<ConditionsReading> GetAllConditionsReadings();

        ConditionsReading GetConditionsReadingById(int id);

        void CreateConditionsReading(ConditionsReading ConditionsReading);

        void UpdateConditionsReading(ConditionsReading ConditionsReading);

        void DeleteConditionsReading(ConditionsReading ConditionsReading);
    }
}
