using System;
using System.Collections.Generic;

namespace WorkFlowPattern.CompositeSpecificationPatern
{
    public class TestSpec
    {
        public void RunSpec()
        {
            Employee employee1 = new Employee
            {
                FirstName = "Fidel",
                Department = "Maths",
                YearOfResumption = 2017
            };
            Employee employee2 = new Employee
            {
                FirstName = "Francis",
                Department = "Software",
                YearOfResumption = 2016
            };
            Employee employee3 = new Employee
            {
                FirstName = "Ahmed",
                Department = "Maths",
                YearOfResumption = 2016
            };
            Employee employee4 = new Employee
            {
                FirstName = "Ebuka",
                Department = "Software",
                YearOfResumption = 2017
            };
            Employee[] employees = new Employee[] {
                employee1,
            employee2,
            employee3,
            employee4
            };


            Console.WriteLine("Software Department");
            List<Employee> SoftwareEmployees = GetEmployee.GetEmployeeBy(new EmployeeDepartmentSpecification("Software"), employees);
            foreach (var employee in SoftwareEmployees)
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.WriteLine("\nEmployed in 2017");
            List<Employee> EmployedIn2017 = GetEmployee.GetEmployeeBy(new EmployeeYearSpecification(2017), employees);
            foreach (var employee in EmployedIn2017)
            {
                Console.WriteLine(employee.FirstName);
            }
            AndSpecification YearAndDepartment = new AndSpecification(new EmployeeDepartmentSpecification("Software"), new EmployeeYearSpecification(2016));
            Console.WriteLine();
            Console.WriteLine("\nList of Software Staff Employed in 2016");
            List<Employee> Software2016Employees = GetEmployee.GetEmployeeBy(YearAndDepartment, employees);
            foreach (var employee in Software2016Employees)
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.WriteLine("\nList of Staff either in Software or Employed in 2016");
            OrSpecification YearOrDepartment = new OrSpecification(new EmployeeDepartmentSpecification("Software"), new EmployeeYearSpecification(2016));
            List<Employee> SoftwareOr2016Employees = GetEmployee.GetEmployeeBy(YearOrDepartment, employees);
            foreach (var employee in SoftwareOr2016Employees)
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.WriteLine("\nList of Staff neither in Software nor Employed in 2016");
            NORSpecification YearNorDepartment = new NORSpecification(new EmployeeDepartmentSpecification("Software"), new EmployeeYearSpecification(2016));
            List<Employee> SoftwareNor2016Employees = GetEmployee.GetEmployeeBy(YearNorDepartment, employees);
            foreach (var employee in SoftwareNor2016Employees)
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.WriteLine("\nList of Staff who are not in Software or not Employed in 2016 or both");
            NANDSpecification YearNandDepartment = new NANDSpecification(new EmployeeDepartmentSpecification("Software"), new EmployeeYearSpecification(2016));
            List<Employee> SoftwareNand2016Employees = GetEmployee.GetEmployeeBy(YearNandDepartment, employees);
            foreach (var employee in SoftwareNand2016Employees)
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.WriteLine("\nList of Staff who are not in Software");
            NotSpecification NotDepartment = new NotSpecification(new EmployeeDepartmentSpecification("Software"));
            List<Employee> NotSoftwareEmployees = GetEmployee.GetEmployeeBy(NotDepartment, employees);
            foreach (var employee in NotSoftwareEmployees)
            {
                Console.WriteLine(employee.FirstName);
            }
            Console.ReadKey();
        }
    }
}
