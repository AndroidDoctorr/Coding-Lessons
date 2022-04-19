public class Employee : Person
{
    public int EmployeeNumber { get; set; }
    public DateTime HireDate { get; set; }


    // Expression = something that resolves to a value
    // Examples:   5 + 3,    5,     "sfdgfdg",    true,     x > 5
    public int YearsWithCompany
    {
        get
        {
            double totalTime = (DateTime.Now - HireDate).TotalDays / 365.24;
            return Convert.ToInt32(Math.Floor(totalTime));
        }
    }
}

public class HourlyEmployee : Employee
{
    public decimal HourlyWage { get; set; }
    public double HoursWorked { get; set; }
}

public class SalaryEmployee : Employee
{
    public decimal Salary { get; set; }

}