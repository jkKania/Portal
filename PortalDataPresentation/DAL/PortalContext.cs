using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PortalData.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using PortalDataPresentation.ViewModels;

namespace PortalDataPresentation.DAL
{
    public class PortalContext : DbContext
    {
        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
        }
        public DbSet<PortalData.Models.DataType> DataTypes { get; set; }
        public DbSet<PortalData.Models.Location> Locations { get; set; }
        public DbSet<MeasurementData> MeasurementDatas { get; set; }
        public DbSet<ArtisticInstalation> ArtisticInstalations { get; set; }

        public DbSet<ReceivedMeasurement> ReceivedMeasurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortalData.Models.DataType>().ToTable("DataType");
            modelBuilder.Entity<PortalData.Models.Location>().ToTable("Location");
            modelBuilder.Entity<MeasurementData>().ToTable("MeasurementData");
            modelBuilder.Entity<ArtisticInstalation>().ToTable("ArtisticInstalation");
            modelBuilder.Entity<ReceivedMeasurement>().ToTable("ReceivedMeasurement");
        }

        public DbSet<PortalDataPresentation.ViewModels.MeasurementDataViewModel> MeasurementDataViewModel { get; set; }

        public DbSet<PortalDataPresentation.ViewModels.PostMeasurementsVM> PostMeasurementsVM { get; set; }

    }
}