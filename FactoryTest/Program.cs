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
            Console.WriteLine("Hourly Rate: 75.00");
        }
    }

    public class FulltimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public override void GetEmployeeDetails()
        {
            Console.WriteLine("Fulltime Employee Details");
            Console.WriteLine("Salary: 110,000.00");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            for(int x = 0; x < 10; x++)
            {
                Console.WriteLine();
                for(int i = 1; i< x;i++)
                {
                    Console.Write("*");
                }
            }
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
                // just for fun...
                char c = ' ';
                for(int i = 0; i <= 50; i++)
                {
                    switch(i%4)
                    {
                        case 0: c = '/'; break;
                        case 1: c = '-'; break;
                        case 2: c = '\\'; break;
                        case 3: c = '|';break;
                         
                    }
                    System.Threading.Thread.Sleep(40);
                    double percent = (i * 100) / 50;

                    Console.Write(String.Format("\r [{0}]% {1}", percent,c));
                }
                Console.Write("\n");
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
