using CarRentalManagementSystem.Operations;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarRentalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Made with Love - By: Ezaldin Alzaher

            using var context = new AppDbContext();

            //BranchOperations.AddBranch(
            //context,
            //"Alfurat",
            //"Albukamal",
            //"Center mall",
            //"info@alfurat.company",
            //"0998345654");

            BranchOperations.GetBranches(context);

            // --------------
            //EmployeeOperations.AddEmployee(
            //context,
            //"Ezaldin",
            //"Alzaher",
            //"Developer",
            //"ezi@alfurat.company",
            //new DateTime(2005, 10, 18), 3);

            EmployeeOperations.GetEmployees(context);

            // --------------
            //VehicleTypeOperations.AddVehicleType(context, "Hundai", 5, 50);
            VehicleTypeOperations.GetVehicleTypes(context);

            //VehicleOperations.AddVehicle(context, 20260731, "Santafe", 2010, Status.Available, 1, 3);
            VehicleOperations.GetVehicles(context);

            // --------------
            //CustomerOperations.AddCustomer(
            //context,
            //"Orwa",
            //"Atef",
            //22043,
            //"orwa@gmail.com",
            //"0987623643",
            //new DateTime(2002, 9, 1));

            CustomerOperations.GetCustomers(context);

            //RentalOperations.AddRental(context, new DateTime(2026, 8, 2), new DateTime(2026, 8, 5), 1, 1);
            RentalOperations.GetRentals(context, 1);

            //PaymentOperations.AddPayment(context, 75, 1);
            PaymentOperations.GetPayments(context, 1);

        }

    }
}
