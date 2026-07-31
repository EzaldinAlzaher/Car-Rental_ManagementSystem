using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Operations
{
    public static class CustomerOperations
    {
        // - Add Customer
        public static void AddCustomer(
              AppDbContext context,
              string firstName,
              string lastName,
              int licenseNumber,
              string email,
              string phone,
              DateTime dob)
        {
            if (context.Customers.Any(c => c.LicenseNumber == licenseNumber))
            {
                Console.WriteLine("Customer already exists.");
                return;
            }

            var newCustomer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                LicenseNumber = licenseNumber,
                Email = email,
                DateOfBirth = dob,
                Phone = phone,
            };

            context.Customers.Add(newCustomer);
            context.SaveChanges();
            Console.WriteLine($"Customer {firstName} {lastName} added successfully.");
        }

        // - Get Customers
        public static void GetCustomers(AppDbContext context)
        {
            var customers = context.Customers.ToList();

            if (!customers.Any())
            {
                Console.WriteLine("Not found customers!");
                return;
            }

            Console.WriteLine("-- Customers --");
            foreach (var customer in customers)
            {
                Console.WriteLine("- " + customer);
            }
        }

        // - Get Customer
        public static void GetCustomer(AppDbContext context, int customerId)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine($"Not found customer, Id: {customerId}!");
                return;
            }

            Console.WriteLine("- " + customer);
        }

        // - Update Customer
        public static void UpdateCustomer(
             AppDbContext context,
             string firstName,
             string lastName,
             int licenseNumber,
             string email,
             string phone,
             DateTime dob,
             int customerId)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine("Not found customer!");
                return;
            }

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Email = email;
            customer.Phone = phone;
            customer.DateOfBirth = dob;
            customer.LicenseNumber = licenseNumber;

            context.SaveChanges();

            Console.WriteLine($"Customer {firstName} {lastName} updated successfully.");
        }

        // - Delete Customer
        public static void DeleteCustomer(AppDbContext context, int customerId)
        {
            var customer = context.Customers.Find(customerId);

            if (customer == null)
            {
                Console.WriteLine("Not found customer!");
                return;
            }

            if (context.Rentals.Any(r => r.CustomerId == customerId))
            {
                Console.WriteLine($"Cannot delete customer because related to data!");
                return;
            }

            context.Customers.Remove(customer);
            context.SaveChanges();
            Console.WriteLine($"Customer deleted successfully.");
        }
    }
}
