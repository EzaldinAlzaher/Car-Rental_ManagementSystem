using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Operations
{
    public static class VehicleOperations
    {
        // - Add Vehicle
        public static void AddVehicle(
            AppDbContext context,
            int plateNumber,
            string model,
            int manufactureYear,
            Status status,
            int vehicleTypeId,
            int branchId)
        {
            if (context.Vehicles.Any(v => v.PlateNumber == plateNumber))
            {
                Console.WriteLine("The Vehicle already exists.");
                return;
            }

            if (!context.Branches.Any(b => b.Id == branchId))
            {
                Console.WriteLine("The branch is not found!");
                return;
            }

            if (!context.VehicleTypes.Any(v => v.Id == vehicleTypeId))
            {
                Console.WriteLine("The vehicleType is not found!");
                return;
            }

            var newVehicle = new Vehicle()
            {
                PlateNumber = plateNumber,
                Model = model,
                ManufactureYear = manufactureYear,
                Status = status,
                VehicleTypeId = vehicleTypeId,
                BranchId = branchId
            };

            context.Vehicles.Add(newVehicle);
            context.SaveChanges();
            Console.WriteLine($"The Vehicle {plateNumber} added successfully.");
        }

        // - Get Vehicles
        public static void GetVehicles(AppDbContext context)
        {
            if (!context.Vehicles.Any())
            {
                Console.WriteLine("Not found Vehicles!");
                return;
            }

            var vehicles = context.Vehicles.ToList();

            Console.WriteLine("-- Vehicles --");
            foreach (var vehicle in vehicles)
                Console.WriteLine("- " + vehicle);
        }

        // - Get Vehicle
        public static void GetVehicle(AppDbContext context, int vehicleId)
        {
            if (!context.Vehicles.Any(v => v.Id == vehicleId))
            {
                Console.WriteLine($"Not found Vehicle, Id: {vehicleId}!");
                return;
            }

            var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

            Console.WriteLine("- " + vehicle);
        }

        // - Update Vehicle
        public static void UpdateVehicle(
            AppDbContext context,
            Status status,
            int vehicleId)
        {
            var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle == null)
            {
                Console.WriteLine("Not found vehicle!");
                return;
            }

            vehicle.Status = status;

            context.SaveChanges();

            Console.WriteLine($"Vehicle {vehicleId} updated successfully.");
        }

        // - Delete Vehicle
        public static void DeleteVehicle(AppDbContext context, int vehicleId)
        {
            var vehicle = context.Vehicles.Find(vehicleId);

            if (vehicle == null)
            {
                Console.WriteLine("Not found vehicle!");
                return;
            }

            if (context.Rentals.Any(r => r.VehicleId == vehicleId))
            {
                Console.WriteLine("Cannot delete vehicle because related data.");
                return;
            }

            context.Vehicles.Remove(vehicle);
            context.SaveChanges();
            Console.WriteLine($"Vehicle deleted successfully.");
        }
    }
}
