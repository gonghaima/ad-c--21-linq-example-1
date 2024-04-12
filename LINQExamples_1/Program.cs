using System.Collections.Generic;
using System.Linq;

namespace LINQExamples_1;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employeeList = Data.GetEmployees();
        List<Department> departmentList = Data.GetDepartments();

        var results = employeeList.Select(e => new
        {
            FullName = e.FirstName + " " + e.LastName,
            AnnualSalary = e.AnnualSalary,
        });

        foreach (var item in results)
        {
            Console.WriteLine($"{item.FullName, -20}  {item.AnnualSalary, 10}");
        }
        Console.ReadLine();
    }
}

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }
}

public static class Data
{
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "Bob",
            LastName = "Jones",
            AnnualSalary = 60000.3m,
            IsManager = true,
            DepartmentId = 1
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 2,
            FirstName = "Sarah",
            LastName = "Jameson",
            AnnualSalary = 80000.1m,
            IsManager = true,
            DepartmentId = 2
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 40000.2m,
            IsManager = false,
            DepartmentId = 2
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 4,
            FirstName = "Jane",
            LastName = "Stevens",
            AnnualSalary = 30000.2m,
            IsManager = false,
            DepartmentId = 2
        };
        employees.Add(employee);

        return employees;
    }

    public static List<Department> GetDepartments()
    {
        List<Department> departments = new List<Department>();

        Department department = new Department
        {
            Id = 1,
            ShortName = "HR",
            LongName = "Human Resources"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 2,
            ShortName = "FN",
            LongName = "Finance"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 3,
            ShortName = "TE",
            LongName = "Technology"
        };
        departments.Add(department);

        return departments;
    }

}

