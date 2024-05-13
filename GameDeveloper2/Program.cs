List<Enemy> enemies = new List<Enemy>
        {
            new Melee("Melee Fighter", 120),
            new Ranged("Ranged Fighter", 120),
            new Magic("Magic Caster", 80)
        };

        Melee meleeEnemy = (Melee)enemies[0];
        Ranged rangedEnemy = (Ranged)enemies[1];
        Magic magicEnemy = (Magic)enemies[2];

        rangedEnemy.Dash();
        meleeEnemy.PerformAttack(rangedEnemy, meleeEnemy.AttackList[1]);
        meleeEnemy.Rage();
        magicEnemy.PerformAttack(magicEnemy, magicEnemy.AttackList[1]);
        magicEnemy.Heal(rangedEnemy);
        magicEnemy.Heal(magicEnemy);