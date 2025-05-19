public class HeroPool : WarriorPool<Hero>
{
    public Hero GetHero()
    {
        Hero hero = GetWarrior();
        return hero;
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
