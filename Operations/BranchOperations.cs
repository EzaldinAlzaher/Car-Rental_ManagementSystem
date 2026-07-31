using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Operations
{
    public static class BranchOperations
    {
        // - Add Branch
        public static void AddBranch(
            AppDbContext context,
            string name,
            string city,
            string address,
            string email,
            string phone)
        {
            var isFound = context.Branches.Any(b => b.City == city);

            if (isFound)
            {
                Console.WriteLine("Branch is already added.");
                return;
            }

            var newBranch = new Branch()
            {
                Name = name,
                City = city,
                Address = address,
                Email = email,
                Phone = phone
            };

            context.Branches.Add(newBranch);
            context.SaveChanges();

            Console.WriteLine($"Branch {name} added successfully.");
        }

        // - Get Branches
        public static void GetBranches(AppDbContext context)
        {
            var branches = context.Branches.ToList();

            if (!branches.Any())
            {
                Console.WriteLine("Not found branches!");
                return;
            }

            Console.WriteLine("-- Branches --");
            foreach (var branch in branches)
            {
                Console.WriteLine("- " + branch);
            }
        }

        // - Get Branch
        public static void GetBranch(AppDbContext context, int branchId)
        {
            var branch = context.Branches.FirstOrDefault(b => b.Id == branchId);

            if (branch == null)
            {
                Console.WriteLine($"Not found branch, Id: {branchId}!");
                return;
            }

            Console.WriteLine("- " + branch);
        }

        // - Update Branch
        public static void UpdateBranch(
            AppDbContext context,
            int branchId,
            string name,
            string city,
            string address,
            string email,
            string phone)
        {
            var branch = context.Branches.FirstOrDefault(b => b.Id == branchId);

            if (branch == null)
            {
                Console.WriteLine("Not found branch!");
                return;
            }

            branch.Name = name;
            branch.City = city;
            branch.Address = address;
            branch.Email = email;
            branch.Phone = phone;

            context.SaveChanges();

            Console.WriteLine($"Branch {name} updated successfully.");
        }

        // - Delete Branch
        public static void DeleteBranch(AppDbContext context, int branchId)
        {
            var branch = context.Branches.Find(branchId);

            if (branch == null)
            {
                Console.WriteLine("Not found branch!");
                return;
            }

            bool hasEmployees = context.Employees.Any(e => e.BranchId == branchId);
            bool hasVehicles = context.Vehicles.Any(v => v.BranchId == branchId);

            if (hasEmployees || hasVehicles)
            {
                Console.WriteLine("Cannot delete branch because it has related data!");
                return;
            }

            context.Branches.Remove(branch);

            context.SaveChanges();

            Console.WriteLine("Branch deleted successfully.");
        }
    }
}
