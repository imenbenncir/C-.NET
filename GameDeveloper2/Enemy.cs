public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Attack> AttackList { get; set; }

    public Enemy(string name, int health, List<Attack> attackList)
    {
        Name = name;
        Health = health;
        AttackList = attackList;
    }

    public virtual void PerformAttack(Enemy target, Attack chosenAttack)
    {
        int damage = chosenAttack.DamageAmount;
        target.Health -= damage;
        Console.WriteLine($"{Name} attacks {target.Name}, dealing {damage} damage and reducing {target.Name}'s health to {target.Health}!!");
    }

    public virtual int GetMaxHealth()
    {
        return Health;
    }
}