namespace Mp03.Models;

public abstract class Person
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Person(int id, string name, string surname, string pesel, string email, string phone)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Pesel = pesel;
        Email = email;
        Phone = phone;
    }
    
    public abstract string GetInfo();

    public override string ToString()
    {
        return $"Name: {Name}, Surname: {Surname}, Pesel: {Pesel}, Email: {Email}, Phone: {Phone}";
    }
}