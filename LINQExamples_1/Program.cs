﻿using System.Collections.Generic;
using System.Linq;

namespace LINQExamples_1;

class Program
{
static void Main(string[] args)
{
    List<Employee> employeeList = Data.GetEmployees();
    List<Department> departmentList = Data.GetDepartments();

    //Select and Where Operators - Method Syntax
    // var results = employeeList.Select(e => new
    // {
    //     FullName = e.FirstName + " " + e.LastName,
    //     AnnualSalary = e.AnnualSalary,
    // }).Where(e=>e.AnnualSalary > 50000).OrderBy(e=>e.FullName);

    //Select and Where Operators - Query Syntax - Deferred Execution
    // var results = from emp in employeeList
    //               where emp.AnnualSalary > 50000
    //               join d in departmentList on emp.DepartmentId equals d.Id
    //               select new
    //               {
    //                   FullName = emp.FirstName + " " + emp.LastName,
    //                   AnnualSalary = emp.AnnualSalary,
    //                   Department = d.LongName
    //               };

    // employeeList.Add(new Employee
    //     {
    //        Id = 5,
    //        FirstName = "Sam",
    //        LastName = "Davis",
    //        AnnualSalary = 100000.20m,
    //        IsManager = true,
    //        DepartmentId = 2
    //     });

    //Deferred Execution Example
    // var results = from emp in employeeList.GetHighSalariedEmployees()
    //                 select new
    //                 {
    //                     FullName = emp.FirstName + " " + emp.LastName,
    //                     AnnualSalary = emp.AnnualSalary
    //              };

    //Immediate Execution Example
    // var results = (from emp in employeeList.GetHighSalariedEmployees()
    //                 select new
    //                 {
    //                     FullName = emp.FirstName + " " + emp.LastName,
    //                     AnnualSalary = emp.AnnualSalary
    //                 }).ToList();

    // employeeList.Add(new Employee
    // {
    //     Id = 5,
    //     FirstName = "Sam",
    //     LastName = "Davis",
    //     AnnualSalary = 100000.20m,
    //     IsManager = true,
    //     DepartmentId = 2

    // });

    // foreach (var item in results)
    // {
    //     Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
    // }

    //Join Operator - method syntax
    // var results = departmentList.Join(employeeList,
    //                                 employee => employee.Id,
    //                                 department => department.DepartmentId,
    //                                 (department, employee) => new
    //                                 {
    //                                     FullName = employee.FirstName + " " + employee.LastName,
    //                                     AnnualSalary = employee.AnnualSalary,
    //                                     DepartmentName = department.LongName
    //                                 });

    // // Join Operation Example - Query Syntax
    // var results = from dept in departmentList
    //         join emp in employeeList
    //         on dept.Id equals emp.DepartmentId
    //         select new
    //         {
    //             FullName = emp.FirstName + " " + emp.LastName,
    //             AnnualSalary = emp.AnnualSalary,
    //             DepartmentName = dept.LongName

    //         };

    // foreach (var item in results)
    // {
    //     Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
    // }

    // //GroupJoin Operator Example - Method Syntax - (lef join)
    // var results = departmentList.GroupJoin(employeeList,
    //         dept => dept.Id,
    //         emp => emp.DepartmentId,
    //         (dept,employeesGroup) => new {
    //             Employees = employeesGroup,
    //             DepartmentName = dept.LongName
    //         }
    //     );

    // foreach (var item in results)
    // {
    //     Console.WriteLine($"Department Name: {item.DepartmentName}");
    //     foreach (var emp in item.Employees)
    //         Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
    // }


    //GroupJoin Operator Example - Query Syntax
    var results = from dept in departmentList
                    join emp in employeeList
                    on dept.Id equals emp.DepartmentId
                    into employeeGroup
                    select new
                    {
                        Employees = employeeGroup,
                        DepartmentName = dept.LongName
                    };
    // evaluate the query (deferred execution)
    foreach (var item in results)
    {
        Console.WriteLine($"Department Name: {item.DepartmentName}");
        foreach (var emp in item.Employees)
            Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");

    }

    Console.ReadLine();
}
}

public static class EnumerableCollectionExtensionMethods
{
public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
{
    foreach (Employee emp in employees)
    {

        Console.WriteLine($"Accessing employee: {emp.FirstName + " " + emp.LastName}");

        if (emp.AnnualSalary >= 50000)
            yield return emp;
    }
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

