
public class EnemyPool : WarriorPool<Enemy>
{
    public Enemy GetEnemy()
    {
        return GetWarrior();
    }
}
