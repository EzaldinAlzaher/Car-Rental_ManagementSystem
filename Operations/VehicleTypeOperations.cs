using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Operations
{
    public static class VehicleTypeOperations
    {
        // - Add Vehicle Type
        public static void AddVehicleType(AppDbContext context, string typeName, int seatsCount, int dailyRate)
        {
            if (context.VehicleTypes.Any(vt => vt.TypeName == typeName))
            {
                Console.WriteLine("The VehicleType already exists.");
                return;
            }

            var newVehicleType = new VehicleType()
            {
                TypeName = typeName,
                SeatsCount = seatsCount,
                DailyRate = dailyRate
            };

            context.VehicleTypes.Add(newVehicleType);
            context.SaveChanges();
            Console.WriteLine($"The VehicleType {typeName} added successfully.");
        }

        // - Get Vehicle Types
        public static void GetVehicleTypes(AppDbContext context)
        {
            if (!context.VehicleTypes.Any())
            {
                Console.WriteLine("Not found VehicleTypes!");
                return;
            }

            var vehicleTypes = context.VehicleTypes.ToList();

            Console.WriteLine("-- VehicleTypes --");
            foreach (var vehicleType in vehicleTypes)
                Console.WriteLine("- " + vehicleType);
        }

        // - Get Vehicle Type
        public static void GetVehicleType(AppDbContext context, int vehicleTypeId)
        {
            if (!context.VehicleTypes.Any(vt => vt.Id == vehicleTypeId))
            {
                Console.WriteLine($"Not found VehicleType, Id: {vehicleTypeId}!");
                return;
            }

            var vehicleType = context.VehicleTypes.FirstOrDefault(vt => vt.Id == vehicleTypeId);

            Console.WriteLine("- " + vehicleType);
        }

        // - Update Vehicle Type
        public static void UpdateVehicleType(
            AppDbContext context,
            int dailyRate,
            int vehicleTypeId)
        {
            var vehicleType = context.VehicleTypes.FirstOrDefault(vt => vt.Id == vehicleTypeId);

            if (vehicleType == null)
            {
                Console.WriteLine("Not found vehicleType!");
                return;
            }

            vehicleType.DailyRate = dailyRate;

            context.SaveChanges();

            Console.WriteLine($"VehicleType {vehicleType.TypeName} updated successfully.");
        }

        // Delete Vehicle Type
        public static void DeleteVehicleType(AppDbContext context, int vehicleTypeId)
        {
            var vehicleType = context.VehicleTypes.Find(vehicleTypeId);

            if (vehicleType == null)
            {
                Console.WriteLine("Not found vehicleType!");
                return;
            }

            bool hasVehicles = context.Vehicles.Any(v => v.VehicleTypeId == vehicleTypeId);

            if (hasVehicles)
            {
                Console.WriteLine("Cannot delete vehicleType because it has related data!");
                return;
            }

            context.VehicleTypes.Remove(vehicleType);

            context.SaveChanges();

            Console.WriteLine("VehicleType deleted successfully.");
        }
    }
}
