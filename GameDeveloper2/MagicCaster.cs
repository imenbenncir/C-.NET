public class Magic : Enemy
{
    public Magic(string name, int health) : base(name, health, new List<Attack>
    {
        new Attack("Fireball", 25),
        new Attack("Lightning Bolt", 20),
        new Attack("Staff Strike", 10)
    })
    {
    }

    public void Heal(Enemy target)
    {
        Attack heal = new Attack("Heal", 40);
        target.Health = Math.Min(target.Health + heal.DamageAmount, target.GetMaxHealth());
        Console.WriteLine($"{Name} casts a spell to heal {target.Name} for {heal.DamageAmount} health, raising {target.Name}'s health to {target.Health}!");
    }

    public new void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (target.Health <= 0)
        {
            Console.WriteLine($"{Name} attempts to attack {target.Name}, but {target.Name} has no health!");
            return;
        }
        base.PerformAttack(target, chosenAttack);
    }
}