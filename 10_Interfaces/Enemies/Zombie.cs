public class Zombie : IEnemy
{
    public int Health { get; private set; } = 20;
    public Attack Attack()
    {
        Random rng = new Random();
        if (rng.Next(0, 3) == 0)
        {
            // 1 in 3 chance
            return new Attack("Bite", 10, AttackType.Necrotic);
        }
        else
        {
            return new Attack("Slash", 5, AttackType.Slashing);
        }
    }

    public string TakeDamage(Attack attack)
    {
        if (attack.Type == AttackType.Necrotic)
        {
            Health -= (attack.Damage / 2);
        }
        else
        {
            Health -= attack.Damage;
        }
        return "Rrrrrrrrrr!";
    }
}