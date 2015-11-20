using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual void GetEmployeeDetails()
        {
            Console.WriteLine("Base Employee Details");
        }
    }

    public class ContractEmployee : Employee
    {
        public decimal HourlyRate { get; set; }

        public override void GetEmployeeDetails()
        {
            Console.WriteLine("Contract Employee Details");
        }
    }

    public class FulltimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public override void GetEmployeeDetails()
        {
            Console.WriteLine("Fulltime Employee Details");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            options.Add(1, "ContractEmployee");
            options.Add(2, "FulltimeEmployee");

            Console.WriteLine("Please enter an employee type:");
            Console.WriteLine("1 = Contract Employee");
            Console.WriteLine("2 = Fulltime Employee");
            Console.WriteLine("-----------------------");
            int selectedEmployee;
            if (Int32.TryParse(Console.ReadLine(), out selectedEmployee))
            {


                Employee employee = Factory.Create(options[selectedEmployee]);
                employee.GetEmployeeDetails();
            }
            else
                Console.WriteLine("Exiting...\n");

            Console.ReadLine();
        }
    }

    public static class Factory
    {
        private static Dictionary<string, Employee> emp = new Dictionary<string, Employee>();

        public static Employee Create(string empType)
        {
            // lazy load objects
            if(emp.Count == 0)
            {
                emp.Add("ContractEmployee", new ContractEmployee());
                emp.Add("FulltimeEmployee", new FulltimeEmployee());
            }
            return emp[empType];
        }
    }
}
