using System;
using System.Collections.Generic;
using System.Linq;
using PortalData.Models;

namespace PortalDataPresentation.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(PortalContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.MeasurementDatas.Any())
            {
                return;
            }
            context.SaveChanges();
            List<Location> locations = new List<Location>();
            List<ArtisticInstalation> instalations = new List<ArtisticInstalation>();
            List<DataType> dataTypes = new List<DataType>();
            List<MeasurementData> measurementDatas = new List<MeasurementData>();

            locations.Add(new Location{Name = "Uczelnia",Address = "Bielsko Biala ul.Willowa 3",Latitude = 12.98,InstalationID = null,Longitude = 36.5,RecordCreateTime = DateTime.UtcNow});
            // foreach (var location in locations)
            //    context.Locations.Add(location);
            locations.ForEach(l => context.Locations.Add(l));

            context.SaveChanges();

            instalations.Add(new ArtisticInstalation{Name = "PortalWillowa",Description = "Uczelniany portal",CurentLocationId = locations.First().ID,RecordCreateTime = DateTime.UtcNow});
            instalations.ForEach(i => context.ArtisticInstalations.Add(i));
            // instalations[0].LocationHistory.Add(locations[0]);


            dataTypes.Add(new DataType { Name = "powerLevel", Description = "Poziom mocy", KeyName = "PL", RecordCreateTime = DateTime.UtcNow });
            dataTypes.Add(new DataType { Name = "diagnosticData", Description = "Dane diagnostyczne", KeyName = "DD", RecordCreateTime = DateTime.UtcNow });
            dataTypes.Add(new DataType { Name = "generatedPower", Description = "Wygenerowana moc", KeyName = "GP", RecordCreateTime = DateTime.UtcNow });

            dataTypes.Add(new DataType { Name = "Temperature", Description = "Temperatura otoczenia", KeyName = "Temperature", RecordCreateTime = DateTime.UtcNow });
            dataTypes.Add(new DataType { Name = "Humidity", Description = "Wilgotnosc powietrza", KeyName = "Humidity", RecordCreateTime = DateTime.UtcNow });
            dataTypes.Add(new DataType { Name = "Photoresistor", Description = "Wygenerowana moc", KeyName = "Photoresistor", RecordCreateTime = DateTime.UtcNow });

            dataTypes.ForEach(d => context.DataTypes.Add(d));
            context.SaveChanges();


            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 49.78 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 75.5 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 24.1 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 18.38 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 83.8 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 29.90 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 47.1 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 24.12 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 12.78 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 40.5 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 60.1 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 10.38 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 8.8 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 3.90 });
            measurementDatas.Add(new MeasurementData { DataTypeID = dataTypes.Skip(1).First().ID, InstalationID = instalations.First().ID, LocationID = locations.First().ID, MeasurmentDate = DateTime.UtcNow, Value = 90.1 });
            measurementDatas.ForEach(m => context.MeasurementDatas.Add(m));

            context.SaveChanges();
        }
    }
}