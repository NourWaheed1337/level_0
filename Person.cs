using System;

public abstract class Person
{
    protected string Name { get; set; }
    protected string Phone { get; set; }
    protected string Address { get; set; }

    protected Person() { }

    protected Person(string name, string phone, string address)
    {
        Name = name;
        Phone = phone;
        Address = address;
    }

    public abstract void Display();

    public void SetName(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }

    public void SetPhone(string phone)
    {
        Phone = phone;
    }

    public string GetPhone()
    {
        return Phone;
    }

    public void SetAddress(string address)
    {
        Address = address;
    }

    public string GetAddress()
    {
        return Address;
    }
}
