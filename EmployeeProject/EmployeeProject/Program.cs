using System;
using System.Collections;

namespace EmployeeProject
{
    class Employee
    {
        public string firstname;
        public string lastname;
        public string designation;
        public int salary;

        public Employee(string firstname, string lastname, string designation)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.designation = designation;
        }

        public Employee(string firstname, string lastname, string designation,int salary)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.designation = designation;
            this.salary = salary;
        }
        public string Firstname
        {
            get { return this.firstname; }
        }
        public string Designation
        {
            get { return this.Designation; }
        }
        public string Lastname
        {
            get { return this.Lastname; }
        }
        public string Salary
        {
            get { return this.Salary; }
        }
    }

    class EmployeeArray
    {
        public ArrayList employees;

        public EmployeeArray()
        {
            employees = new ArrayList();
        }
        public void Add(Employee emp)
        {
            employees.Add(emp);
        }
        public bool Contains(Employee emp)  
        {
            foreach (Employee e in employees)    
                if ((emp.Firstname.ToLower() == e.Firstname.ToLower()) && (emp.Lastname.ToLower() == e.Lastname.ToLower()) && (emp.Designation == e.Designation)&&(emp.Salary == e.Salary))
                    return true;

            return false;
        }
        public void Remove(Employee emp)   
        {
            foreach (Employee e in employees)    
                if ((emp.Firstname.ToLower() == e.Firstname.ToLower()) && (emp.Lastname.ToLower() == e.Lastname.ToLower()) && (emp.Designation == e.Designation) && (emp.Salary == e.Salary))
                {
                    employees.Remove(e);            
                }
        }
        public void PrintEmp()                      
        {
            Console.WriteLine("First Name\tLast Name\tDesignation\tSalary");
            foreach (Employee e in employees)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", e.Firstname.PadRight(11), e.Lastname.PadRight(10), e.Designation, e.Salary.PadRight(11));
            }
            Console.WriteLine();
        }
    }
    class mainprogram
    {
        public static Employee Createworker()
        {
            Console.Write("Enter first name of employee: ");
            var firstname = Console.ReadLine();
            Console.Write("Enter last name of employee: ");
            var lastname = Console.ReadLine();
            Console.Write("Enter designation of employee: ");
            var designation = Console.ReadLine();
            Console.Write("Enter salary of the employee: ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Employee emp;
            emp = new Employee(firstname, lastname, designation,salary);
            return emp;
        }

        static void DeleteEmployee(EmployeeArray employees)
        {
            Employee emp = GetEmployeeInfo();
            if (employees.Contains(emp))
            {
                Console.WriteLine("Deleting employee");
                employees.Remove(emp);
            }
            else
                Console.WriteLine("There is no such employee");
        }

        static Employee GetEmployeeInfo()
        {
            Console.WriteLine("Enter first name of the employee");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter last name of the employee");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter designation of the employee");
            string designation = Console.ReadLine();
            Employee emp = new Employee(firstname, lastname, designation);
            return emp;
        }
        
        static void Main(string[] args)
        {
            EmployeeArray empArray = new EmployeeArray();
            int proceed = 1;

            while (proceed != 0)
            {
                Console.WriteLine("\n\n* * MENU DRIVEN * *\n\n1.Insert Information\n2.Delete Information\n3.Display Information\n press any other number to exit\n");
                Console.Write("Enter Choice:\t");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        Employee emp = Createworker();
                        empArray.Add(emp);
                        break;
                    case 2:
                        DeleteEmployee(empArray);
                        break;
                    case 3:
                        foreach(Employee e in empArray)
                        {
                            Console.WriteLine(e);
                        }
                        empArray.PrintEmp();
                        break;
                    default:
                        Console.Write("Invalid Choice");
                        break;
                }
                Console.WriteLine("press 0 to exit else anyother number to continue : ");
                proceed = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
