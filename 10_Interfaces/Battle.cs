public class Battle
{
    private readonly List<IEnemy> _enemies { get; }

    public Battle(List<IEnemy> enemies)
    {
        _enemies = enemies;
    }

    public void RunBattle()
    {
        // loop
    }

    public void SelectEnemy()
    {

    }

    public void AttackEnemy()
    {
        IEnemy enemy = new Zombie();
        _enemies.Add(enemy);

        Attack playerAttack = new Attack("Sword strike", 15, AttackType.Slashing);


        enemy.TakeDamage(playerAttack);

        if (enemy.Health <= 0)
        {
            _enemies.Remove(enemy);
        }

        if (_enemies.Count == 0)
        {
        }

    }
}