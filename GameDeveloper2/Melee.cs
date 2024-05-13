public class Melee : Enemy
{
    public Melee(string name, int health) : base(name, health, new List<Attack>
    {
        new Attack("Punch", 20),
        new Attack("Kick", 15),
        new Attack("Tackle", 25)
    })
    {
    }
    
    public void Rage()
    {
        Random rand = new Random();
        Attack chosenAttack = AttackList[rand.Next(AttackList.Count)];
        chosenAttack.DamageAmount += 10;
        PerformAttack(this, chosenAttack);
    }
}