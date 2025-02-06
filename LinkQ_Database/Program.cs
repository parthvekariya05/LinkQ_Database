using LinkQ_Database;

public class Program
{
    public static void Main()
    {
        var context = new ApplicationDBContext();

        //For example, Display FirstName of all employees.
        var q1 = context.Employee.Select(x => x.FirstName);
        foreach (var employee in q1)
        {
            Console.WriteLine("\n {0}", employee);
        }

        //Display data of all Employees
        var q2 = context.Employee.ToList();

        foreach (var emp in q2)
        {
            Console.WriteLine(emp.AccountNo + ", " + emp.FirstName + ", " + emp.LastName + ", " + emp.Gender + ", " + emp.Age + ", " + emp.Email + ", " + emp.PhoneNo + ", " + emp.Salary + ", " + emp.City + ", " + emp.JoiningDate + ", " + emp.Department);
        }

        Console.WriteLine();

        // Select ActNo, FirstName, and Salary into a new class
        var selectedEmployees = context.Employee
            .Select(e => new { e.AccountNo, e.FirstName, e.Salary })
            .ToList();
        foreach (var emp in selectedEmployees)
        {
            Console.WriteLine(emp.AccountNo + " | " + emp.FirstName + " | " + emp.Salary);
        }

        Console.WriteLine();

        // Display data in format: {Anil} works in {Admin} Department.
        var formattedEmployees = context.Employee
            .Select(e => e.FirstName + " works in " + e.Department + " Department.")
            .ToList();
        foreach (var emp in formattedEmployees)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine();

        // Select Employee Full Name, Email, and Department as anonymous
        var anonymousEmployees = context.Employee
            .Select(e => new { FullName = e.FirstName + " " + e.LastName, e.Email, e.Department })
            .ToList();
        foreach (var emp in anonymousEmployees)
        {
            Console.WriteLine(emp.FullName + " | " + emp.Email + " | " + emp.Department);
        }

        Console.WriteLine();

        // Display employees with their joining date
        var employeesWithJoiningDate = context.Employee
            .Select(e => e.FirstName + " joined on " + e.JoiningDate)
            .ToList();

        foreach (var emp in employeesWithJoiningDate)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine();

        // Display employees between age 20 to 30
        var ageFilteredEmployees = context.Employee
            .Where(e => e.Age >= 20 && e.Age <= 30)
            .ToList();

        Console.WriteLine("FirstName | Age");
        foreach (var emp in ageFilteredEmployees)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.Age);
        }

        Console.WriteLine();

        // Display female employees
        var femaleEmployees = context.Employee
            .Where(e => e.Gender == "Female")
            .ToList();

        Console.WriteLine("FirstName | Gender");
        foreach (var emp in femaleEmployees)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.Gender);
        }

        Console.WriteLine();

        // Display employees with salary more than 35000
        var highSalaryEmployees = context.Employee
            .Where(e => e.Salary > 35000)
            .ToList();

        Console.WriteLine("FirstName | Salary");
        foreach (var emp in highSalaryEmployees)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.Salary);
        }

        Console.WriteLine();

        // Display employees whose account no is less than 110
        var accountFilteredEmployees = context.Employee
            .Where(e => e.AccountNo < 110)
            .ToList();

        Console.WriteLine("FirstName | AccountNo");
        foreach (var emp in accountFilteredEmployees)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.AccountNo);
        }

        Console.WriteLine();

        // Display employees who belong to either Rajkot or Morbi city
        var cityFilteredEmployees = context.Employee
            .Where(e => e.City == "Rajkot" || e.City == "Morbi")
            .ToList();

        Console.WriteLine("FirstName | City");
        foreach (var emp in cityFilteredEmployees)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.City);
        }

        Console.WriteLine();

        // Display employees whose salary is greater than 20000
        var lowSalaryEmployees = context.Employee
            .Where(e => e.Salary > 20000)
            .ToList();

        Console.WriteLine("FirstName | Salary");
        foreach (var emp in lowSalaryEmployees)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.Salary);
        }

        Console.WriteLine();

        // Display employees whose salary is between 30000 and 60000
        var midSalaryEmployees = context.Employee
            .Where(e => e.Salary >= 10000 && e.Salary <= 60000)
            .ToList();

        Console.WriteLine("FirstName | Salary");
        foreach (var emp in midSalaryEmployees)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.Salary);
        }

        Console.WriteLine();

        // Display AccountNo, FirstName, and Salary of employees from Morbi, Ahmedabad, Surat with AccountNo > 120
        var citySpecificEmployees = context.Employee
            .Where(e => (e.City == "Morbi" || e.City == "Ahmedabad" || e.City == "Surat") && e.AccountNo <= 120)
            .Select(e => new { e.AccountNo, e.FirstName, e.Salary })
            .ToList();

        Console.WriteLine("A/CNo | FirstName | Salary");
        foreach (var emp in citySpecificEmployees)
        {
            Console.WriteLine(emp.AccountNo + " | " + emp.FirstName + " | " + emp.Salary);
        }

        Console.WriteLine();

        // Find total salary
        var totalSalary = context.Employee.Sum(e => e.Salary);
        Console.WriteLine("Total Salary: " + totalSalary);

        Console.WriteLine();

        // Find total number of employees in Admin department from Rajkot
        var adminRajkotCount = context.Employee.Count(e => e.Department == "Admin" && e.City == "Rajkot");
        Console.WriteLine("Total Employees in Admin (Rajkot): " + adminRajkotCount);

        Console.WriteLine();

        // Find total salary of Distribution department
        var totalDistributionSalary = context.Employee
            .Where(e => e.Department == "Distribution")
            .Sum(e => e.Salary);
        Console.WriteLine("Total Salary of Distribution: " + totalDistributionSalary);

        Console.WriteLine();

        // Find average salary of IT department
        var avgItSalary = context.Employee
            .Where(e => e.Department == "IT")
            .Average(e => e.Salary);
        Console.WriteLine("Average Salary of IT: " + avgItSalary);

        Console.WriteLine();

        // Find minimum salary of Customer Relationship department
        var minCustomerSalary = context.Employee
            .Where(e => e.Department == "Customer Relationship")
            .Min(e => e.Salary);
        Console.WriteLine("Minimum Salary in Customer Relationship: " + minCustomerSalary);

        Console.WriteLine();

        // Find maximum salary of Distribution department in Baroda
        var maxDistributionSalaryBaroda = context.Employee
            .Where(e => e.Department == "Distribution" && e.City == "Baroda")
            .Max(e => e.Salary);
        Console.WriteLine("Max Salary in Distribution (Baroda): " + maxDistributionSalaryBaroda);

        Console.WriteLine();

        // Display employees by first name in ascending order
        var sortedByFirstName = context.Employee.OrderBy(e => e.FirstName).ToList();
        foreach (var emp in sortedByFirstName)
        {
            Console.WriteLine(emp.FirstName);
        }

        Console.WriteLine();

        // Display employees by department name in descending order
        var sortedByDepartment = context.Employee.OrderByDescending(e => e.Department).ToList();
        foreach (var emp in sortedByDepartment)
        {
            Console.WriteLine(emp.Department + " | " + emp.FirstName);
        }

        Console.WriteLine();

        // Display employees by department descending and first name ascending
        var sortedByDeptAndName = context.Employee
            .OrderByDescending(e => e.Department)
            .ThenBy(e => e.FirstName)
            .ToList();
        foreach (var emp in sortedByDeptAndName)
        {
            Console.WriteLine(emp.Department + " | " + emp.FirstName);
        }

        Console.WriteLine();

        // Display employees by first name ascending and last name descending
        var sortedByFirstLast = context.Employee
            .OrderBy(e => e.FirstName)
            .ThenByDescending(e => e.LastName)
            .ToList();
        foreach (var emp in sortedByFirstLast)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.LastName);
        }

        Console.WriteLine();

        // Display employees by joining date in reverse order
        var sortedByJoiningDate = context.Employee
        .OrderByDescending(e => e.JoiningDate)
        .ToList();

        foreach (var emp in sortedByJoiningDate)
        {
            Console.WriteLine(emp.FirstName + " | " + emp.JoiningDate);
        }

        Console.WriteLine();


        //emp group by city
        IEnumerable<IGrouping<string,Employee>> groupByCity=context.Employee.GroupBy(e => e.City);
        Console.WriteLine("Group by city");
        foreach ( IGrouping<string, Employee> group in groupByCity)
        {
            Console.WriteLine();
            Console.WriteLine("City"+" | "+"Count");
            
            Console.WriteLine(group.Key + " | " + group.Count());
            Console.WriteLine();
            foreach (var emp in group)
            {
                Console.WriteLine(emp.FirstName+" "+emp.LastName);
            }
        }       
    }
}