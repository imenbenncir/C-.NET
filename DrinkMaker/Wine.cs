public class Wine : Drink
{
    public string  Region;
    public int  Year;
    public Wine(string name, string color, double temp, int calories, string  region, int year) : base(name, color, temp, false, calories)
    {
        Region =  region;
        Year = year;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year: {Year}");
    }
}