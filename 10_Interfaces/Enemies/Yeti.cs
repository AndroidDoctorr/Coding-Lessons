public class Yeti : IEnemy
{
    public int Health { get; private set; } = 40;
    public Attack Attack()
    {
        Random rng = new Random();
        if (rng.Next(0, 3) == 0)
        {
            // 1 in 3 chance
            return new Attack("Claw Attack", 15, AttackType.Slashing);
        }
        else
        {
            return new Attack("Snowball", 5, AttackType.Freezing);
        }
    }

    public string TakeDamage(Attack attack)
    {
        if (attack.Type == AttackType.Freezing)
        {
            Health -= (attack.Damage / 2);
        }
        else if (attack.Type == AttackType.Burning)
        {
            Health -= (int)Math.Round((double)attack.Damage * 1.25);
        }
        else
        {
            Health -= attack.Damage;
        }
        return "RROOOOOAAAAARRRRRRRR!";
    }
}