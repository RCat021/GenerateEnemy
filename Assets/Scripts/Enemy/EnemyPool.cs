
public class EnemyPool : WarriorPool<Enemy>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public Enemy GetEnemy()
    {
        Enemy enemy = GetWarrior();
        return enemy;
    }
}
