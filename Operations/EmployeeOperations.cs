using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Operations
{
    public static class EmployeeOperations
    {
        // - Add Employee
        public static void AddEmployee(
            AppDbContext context,
            string firstName,
            string lastName,
            string title,
            string email,
            DateTime dob,
            int branchId)
        {
            if (!context.Branches.Any(b => b.Id == branchId))
            {
                Console.WriteLine("Branch not found, So cannot adding the employee!");
                return;
            }

            var newEmployee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Title = title,
                Email = email,
                DateOfBirth = dob,
                HiredDate = DateTime.UtcNow,
                BranchId = branchId
            };

            context.Employees.Add(newEmployee);
            context.SaveChanges();
            Console.WriteLine($"Employee {firstName} {lastName} added successfully.");
        }

        // - Get Employees
        public static void GetEmployees(AppDbContext context)
        {
            var employees = context.Employees.ToList();

            if (!employees.Any())
            {
                Console.WriteLine("Not found employees!");
                return;
            }

            Console.WriteLine("-- Employees --");
            foreach (var employee in employees)
            {
                Console.WriteLine("- " + employee);
            }
        }

        // - Get Employee
        public static void GetEmployee(AppDbContext context, int employeeId)
        {
            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                Console.WriteLine($"Not found employee, Id: {employeeId}!");
                return;
            }

            Console.WriteLine("- " + employee);
        }

        // - Update Employee
        public static void UpdateEmployee(
            AppDbContext context,
            string firstName,
            string lastName,
            string title,
            string email,
            DateTime dob,
            int employeeId)
        {
            var employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                Console.WriteLine("Not found employee!");
                return;
            }

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Title = title;
            employee.Email = email;
            employee.DateOfBirth = dob;

            context.SaveChanges();

            Console.WriteLine($"Employee {firstName} {lastName} updated successfully.");
        }

        // - Delete Employee
        public static void DeleteEmployee(AppDbContext context, int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                Console.WriteLine("Not found employee!");
                return;
            }

            context.Employees.Remove(employee);
            context.SaveChanges();
            Console.WriteLine($"Employee deleted successfully.");
        }
    }
}
