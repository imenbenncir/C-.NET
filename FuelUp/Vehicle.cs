public abstract class Vehicle
{
    public string Name { get; set; }
    public int Wheels { get; set; }
    public bool HasEngine { get; set; }

    public abstract void Move();

    protected Vehicle(string name, int wheels, bool hasEngine)
    {
        Name = name;
        Wheels = wheels;
        HasEngine = hasEngine;
    }
    foreach (var vehicle in vehicles)
    {
    if (vehicle is INeedFuel fuelVehicle)
    {
        vehiclesWithFuel.Add(fuelVehicle);
    }
}
}