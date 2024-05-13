public class Ranged : Enemy
{
    public int Distance { get; set; }

    public Ranged(string name, int health) : base(name, health, new List<Attack>
    {
        new Attack("Shoot an Arrow", 20),
        new Attack("Throw a Knife", 15)
    })
    {
        Distance = 5;
    }

    public void Dash()
    {
        Distance = 20;
    }

    public new void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (Distance < 10)
        {
            Console.WriteLine($"{Name} attempts to attack, but cannot reach {target.Name}!");
            return;
        }
        base.PerformAttack(target, chosenAttack);
    }
}