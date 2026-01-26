public class CharacterStats : PlayableStats
{
    protected override void InitializeStats()
    {
        BaseStat strength = new BaseStat(15, "Strength");
        AddStat(strength);
        BaseStat dexterity = new BaseStat(10, "Dexterity");
        AddStat(dexterity);
        BaseStat constitution = new BaseStat(20, "Constitution");
        AddStat(constitution);
    }
}
