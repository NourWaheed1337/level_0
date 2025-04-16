using System;

public class Nurse : Person
{
    private string department;

    public Nurse() { }

    public Nurse(string name, string phone, string address, string department)
        : base(name, phone, address)
    {
        this.department = department;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Phone: " + Phone);
        Console.WriteLine("Address: " + Address);
        Console.WriteLine("Department: " + department);
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }
}
