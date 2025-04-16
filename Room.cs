using System;

public class Room
{
    public int Id { get; set; }
    public bool Occupied { get; set; }

    public Room() { }

    public Room(int id, bool occupied)
    {
        Id = id;
        Occupied = occupied;
    }

    public void Display()
    {
        Console.WriteLine($"Room ID: {Id}");
        Console.WriteLine($"Status: {(Occupied ? "Occupied" : "Vacant")}");
    }
}
