public class BaseStat {
    public enum BaseStatType{
        Constitution,
        Dexterity,
        Strength,
    }

    public BaseStatType statType { get; set; }
    public int baseValue { get; set; }
    public string statName { get; set; }

    public BaseStat(int baseValue, string statName){
        foreach (BaseStatType value in System.Enum.GetValues(typeof(BaseStatType))){
            if (value.ToString() == statName){
                statType = value;
                break;
            }
        }
        this.statType = statType;
        this.baseValue = baseValue;
        this.statName = statName;
    }

    /// <summary>
    /// Gets the total value of the specific stat of the character
    /// </summary>
    /// <returns><b>integer</b> Total value of specific stat</returns>
    public int CalculateStatValue() {
        return baseValue;
    }
}