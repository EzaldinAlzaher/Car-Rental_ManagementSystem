using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Operations
{
    public static class PaymentOperations
    {
        // - Add Payment
        public static void AddPayment(
             AppDbContext context,
             double amount,
             int rentalId)
        {

            if (!context.Rentals.Any(r => r.Id == rentalId))
            {
                Console.WriteLine("The rental not found!");
                return;
            }

            var newPayment = new Payment()
            {
                Amount = amount,
                CreatedDate = DateTime.UtcNow,
                RentalId = rentalId
            };


            context.Payments.Add(newPayment);
            context.SaveChanges();
            Console.WriteLine("Payment added successfully.");
        }

        // - Get Payments
        public static void GetPayments(AppDbContext context, int rentalId)
        {
            var rental = context.Rentals
                .Include(r => r.Payments)
                .FirstOrDefault(r => r.Id == rentalId);

            if (rental == null)
            {
                Console.WriteLine("Rental not found!");
                return;
            }

            if (!rental.Payments.Any())
            {
                Console.WriteLine("No payments found.");
                return;
            }

            Console.WriteLine($"-- Paymnets for Rental {rentalId} --");
            foreach (var payment in rental.Payments)
                Console.WriteLine("- " + payment);
        }
    }
}
