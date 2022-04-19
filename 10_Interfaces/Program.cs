Zombie zombie = new Zombie();
Attack attack = zombie.Attack();

Console.WriteLine($"{zombie.GetType().Name} attacks for {attack.Damage} {attack.Type} damage!");

CrabMonster monster = new CrabMonster();
Attack attack1 = new Attack("Club strike", 20, AttackType.Bludgeoning);

Console.WriteLine($"{monster.GetType().Name} is at {monster.Health} health");
Console.WriteLine($"You attack for {attack1.Damage} {attack1.Type} damage");
Console.WriteLine(monster.TakeDamage(attack1));
Console.WriteLine($"{monster.GetType().Name} is now at {monster.Health} health");