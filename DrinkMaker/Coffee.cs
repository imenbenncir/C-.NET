public class Coffee : Drink
{
    public string Roast;
    public string Beans;

    public Coffee(string name, string color, double temp, int calories, string roast, string beans) : base(name, color, temp, false, calories)

    {
        Roast = roast;
        Beans = beans;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Roast: {Roast}");
        Console.WriteLine($"Beans: {Beans}");
    }
}