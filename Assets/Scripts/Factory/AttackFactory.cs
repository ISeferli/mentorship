public static class AttackFactory
{
    public static IAttack CreateAttack(AttackProfile profile, PlayableStats stats, IAttack attack)
    {
        switch(profile.elements)
        {
            case AttackElement.Fire:
                attack = new FireAttackDecorator(4, attack);
                break;
            case AttackElement.Water:
                attack = new WaterAttackDecorator(7, attack);
                break;
        }

        return attack;
    }
}