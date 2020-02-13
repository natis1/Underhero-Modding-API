using MonoMod;

namespace Modding.Patches
{
    [MonoModPatch("global::EnemyHealthPointsScript")]
    public class EnemyHealthPointsScript2 : EnemyHealthPointsScript
    {
        [MonoModIgnore]
        private int CompareHP;

        private void orig_InCombatMethod() { }
        private void InCombatMethod()
        {
            if (CompareHP > HP)
            {
                HP = CompareHP - ModHooks.Instance.OnEnemyDamage(CompareHP - HP);
                if (HP < 0)
                {
                    CompareHP -= HP;
                    HP = 0;
                }
            }
            orig_InCombatMethod();
        }
    }
}