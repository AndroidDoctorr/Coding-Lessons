public class CrabMonster : IEnemy
{
    public int Health { get; private set; } = 60;
    public Attack Attack()
    {
        Random rng = new Random();
        if (rng.Next(0, 3) == 0)
        {
            // 1 in 3 chance
            return new Attack("Chomp", 20, AttackType.Bludgeoning);
        }
        else
        {
            return new Attack("Poke", 10, AttackType.Piercing);
        }
    }

    public string TakeDamage(Attack attack)
    {
        if (attack.Type == AttackType.Bludgeoning)
        {
            Health -= (int)Math.Round((double)attack.Damage * 0.75);
        }
        else
        {
            Health -= attack.Damage;
        }
        return "RROOOOOAAAAARRRRRRRR!";
    }
}