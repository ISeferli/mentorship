public class EnemyStats : PlayableStats
{
    protected override void InitializeStats()
    {
        BaseStat strength = new BaseStat(5, "Strength");
        AddStat(strength);
        BaseStat dexterity = new BaseStat(5, "Dexterity");
        AddStat(dexterity);
        BaseStat constitution = new BaseStat(10, "Constitution");
        AddStat(constitution);
    }
}
