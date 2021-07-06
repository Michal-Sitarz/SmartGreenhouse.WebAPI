using System.Collections.Generic;
using SmartGreenhouse.WebAPI.Models;

namespace SmartGreenhouse.WebAPI.Services.Contracts
{
    public interface ISensorNodesDataService
    {
        IEnumerable<SensorNode> GetAllSensorNodes();

        SensorNode GetSensorNodeById(string id);

        void CreateSensorNode(SensorNode SensorNode);

        void UpdateSensorNode(SensorNode SensorNode);

        void DeleteSensorNode(SensorNode SensorNode);
    }
}
