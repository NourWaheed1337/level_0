using System;

public class Patient : Person
{
    private string status;
    private int roomID;

    public Patient() { }

    public Patient(string name, string phone, string address, string status, int roomID)
        : base(name, phone, address)
    {
        this.status = status;
        this.roomID = roomID;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Phone: " + Phone);
        Console.WriteLine("Address: " + Address);
        Console.WriteLine("Status: " + status);
        Console.WriteLine("Room ID: " + roomID);
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public int RoomID
    {
        get { return roomID; }
        set { roomID = value; }
    }
}
