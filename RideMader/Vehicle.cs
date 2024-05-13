public class Vehicle
{
    public string Name;
    public int Numpassengers;
    public string Color;
    public bool HasEngine;
    public int Distance = 0;

    public Vehicle(string n, int np, string c, bool he)
    {
        Name = n;
        Numpassengers = np;
        Color = c;
        HasEngine = he;
    }
    public Vehicle(string n, string c)
    {
        Name = n;
        Numpassengers= 4;
        Color = c;
        HasEngine = true;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Vehicle Name: {Name}");
        Console.WriteLine($"Numpassengers: {Numpassengers}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"HasEngine: {HasEngine}");
        Console.WriteLine($"Distance: {Distance}");
    }
    public void Travel(int distance)
    {
        Distance += distance;
        Console.WriteLine($"Traveled {Distance} miles. Total distance traveled: {distance} miles");
    }
}