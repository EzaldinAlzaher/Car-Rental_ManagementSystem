using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Operations
{
    public static class RentalOperations
    {
        // - Add Rental
        public static void AddRental(
             AppDbContext context,
             DateTime startDate,
             DateTime endDate,
             int customerId,
             int vehicleId)
        {

            if (!context.Customers.Any(c => c.Id == customerId))
            {
                Console.WriteLine("The customer is not found!");
                return;
            }

            if (!context.Vehicles.Any(v => v.Id == vehicleId))
            {
                Console.WriteLine("The vehicle is not found!");
                return;
            }

            if (endDate <= startDate)
            {
                Console.WriteLine("Invalid rental date.");
                return;
            }

            var vehicle = context.Vehicles
                .Include(v => v.VehicleType)
                .FirstOrDefault(v => v.Id == vehicleId);

            if (vehicle.Status != Status.Available)
            {
                Console.WriteLine($"The Vehicle {vehicle.PlateNumber} is not Available!");
                return;
            }

            var newRental = new Rental()
            {
                StartDate = startDate,
                EndDate = endDate,
                CustomerId = customerId,
                VehicleId = vehicleId
            };

            var numOfDays = (endDate - startDate).Days;
            newRental.TotalPrice = vehicle.VehicleType.DailyRate * numOfDays;

            // Change status vehicle to rented
            vehicle.Status = Status.Rented;

            context.Rentals.Add(newRental);
            context.SaveChanges();
            Console.WriteLine($"The Rental with Customer {customerId} is Done.");
        }

        // - Get Rentals
        public static void GetRentals(AppDbContext context, int customerId)
        {
            if (!context.Rentals.Any(r => r.CustomerId == customerId))
            {
                Console.WriteLine($"Not found Rentals to customer {customerId}!");
                return;
            }

            var customer = context.Customers
                .Include(c => c.Rentals)
                .FirstOrDefault(c => c.Id == customerId);

            Console.WriteLine($"-- Rentals for Customer {customer.FirstName} {customer.LastName} --");
            foreach (var rental in customer.Rentals)
                Console.WriteLine("- " + rental);
        }
    }
}
