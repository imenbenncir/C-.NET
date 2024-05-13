

    Enemy enemy = new Enemy("Bandit");

        Attack fireball = new Attack("Fireball", 20);
        Attack punch = new Attack("Punch", 10);
        Attack kick = new Attack("Kick", 15);

        enemy.AddAttack(fireball);
        enemy.AddAttack(punch);
        enemy.AddAttack(kick);

        enemy.RandomAttack();
        enemy.RandomAttack();
        enemy.RandomAttack();
    