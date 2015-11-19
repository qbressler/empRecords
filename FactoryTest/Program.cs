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
            int selectedEmployee = Convert.ToInt32(Console.ReadLine());


            Employee employee = Factory.Create(options[selectedEmployee]);
            employee.GetEmployeeDetails();


        }
    }

    public static class Factory
    {
        private static Dictionary<string, Employee> emp = new Dictionary<string, Employee>();

        static Factory()
        {
            emp.Add("ContractEmployee", new ContractEmployee());
            emp.Add("FulltimeEmployee", new FulltimeEmployee());

        }

        public static Employee Create(string empType)
        {
            return emp[empType];
        }
    }
}
