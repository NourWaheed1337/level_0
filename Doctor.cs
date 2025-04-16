public class Doctor : Person
{
    private string department;
    private float rating;

    public Doctor() { }

    public Doctor(string name, string phone, string address, string department, float rating)
        : base(name, phone, address)
    {
        this.department = department;
        this.rating = rating;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Phone: " + Phone);
        Console.WriteLine("Address: " + Address);
        Console.WriteLine("Department: " + department);
        Console.WriteLine("Rating: " + rating);
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public float Rating
    {
        get { return rating; }
        set { rating = value; }
    }
}