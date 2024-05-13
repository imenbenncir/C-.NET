public class Car : Vehicle, INeedFuel
{
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    public Car(string name) : base(name, 4, true)
    {
        FuelType = "gas";
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} is driving.");
    }
}