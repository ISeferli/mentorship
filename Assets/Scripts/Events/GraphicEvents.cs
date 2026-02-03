using System;

public class GraphicEvents
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