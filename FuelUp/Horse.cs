using System;

public class Horse : Vehicle, INeedFuel
{
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    public Horse(string name) : base(name, 4, false)
    {
        FuelType = "hay";
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} is galloping.");
    }
}
