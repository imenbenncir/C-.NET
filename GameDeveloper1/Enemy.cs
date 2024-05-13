public class Enemy
{
    public string Name;
    private int Health;
    private List<Attack> AttackList;

    public Enemy(string name)
    {
        Name = name;
        Health = 100;
        AttackList = new List<Attack>();
    }
    public int GetHealth()
    {
        return Health;
    }

    public void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
    }

    public void RandomAttack()
    {
        Random random = new Random();
        int index = random.Next(AttackList.Count);
        Attack attack = AttackList[index];
        Console.WriteLine($"{Name} performs {attack.Name} causing {attack.DamageAmount} damage.");
    }
}
    