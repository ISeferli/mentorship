using System;

public class GameEvents
{
    public event Action<int> OnShowEnemyDamage;

    public void ShowEnemyDamage(int damageTaken)
    {
        if (OnShowEnemyDamage != null)
        {
            OnShowEnemyDamage(damageTaken);            
        }
    }
}