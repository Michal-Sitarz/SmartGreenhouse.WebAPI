using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartGreenhouse.WebAPI.Models;
using System;
using System.Linq;

namespace SmartGreenhouse.WebAPI.Data
{
    public static class AppDbPrep
    {
        public static void Populate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        public static void SeedData(AppDbContext dbContext)
        {
            Console.WriteLine("Applying Migrations...");
            dbContext.Database.Migrate();
            
            if (!dbContext.SensorNodes.Any() && !dbContext.Plants.Any())
            {
                Console.WriteLine("Adding data - seeding...");

                dbContext.SensorNodes.AddRange(
                    new SensorNode()
                    {
                        Id = "arduino1",
                        DeviceType = "Arduino Nano 33 IoT",
                        Label = "Sensor 1",
                        Location = "workshop"
                    }
                );

                dbContext.ConditionsReadings.AddRange(
                    new ConditionsReading()
                    {
                        AirHumidity = 60,
                        AirTemperature = 19,
                        TimeStamp = DateTime.Now,
                        SensorNodeId = "arduino1"
                    },
                    new ConditionsReading()
                    {
                        AirHumidity = 65,
                        AirTemperature = 25,
                        TimeStamp = DateTime.Now,
                        SensorNodeId = "arduino1"
                    }
                );

                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding.");
            }
            

        }
    }
}
