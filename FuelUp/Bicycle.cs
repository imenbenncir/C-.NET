using System;

public class Bicycle : Vehicle
{
    public Bicycle(string name) : base(name, 2, false)
    {
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} is pedaling.");
    }
}
