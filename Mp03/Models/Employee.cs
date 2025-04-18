using System.Security.Cryptography;
using System.Text;

namespace Mp03.Models;

public class Employee : Person
{
    public Employee(int id, string name, string surname, string pesel, string email, string phone, DateTime dateOfBirth) : base(id, name, surname, pesel, email, phone)
    {
        EmploymentDate = DateTime.Now;
        DateOfBirth = dateOfBirth;
        EmployeeNumber = $"{Id}{Name![0]}{Surname![0]}{RandomNumberGenerator.GetHexString(10)}";
    }

    public string EmployeeNumber { get; }
    
    public DateTime DateOfBirth { get; }
    
    public DateTime EmploymentDate { get; }

  

    public int CalculateYearsOfExperience()
    {
        return DateTime.Now.Year - EmploymentDate.Year;
    }
    
    public override string GetInfo()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"Employee: {EmployeeNumber}");
        sb.AppendLine($"Employment Date: {EmploymentDate}");
        sb.AppendLine($"Date of birth: {DateOfBirth}");
        sb.AppendLine(base.ToString());
        
        return sb.ToString();
    }
}