using MonoMod;

namespace Modding.Patches
{
    [MonoModPatch("global::BossHealthPointsScript")]
    public class BossHealthPointsScript2 : BossHealthPointsScript
    {
        private void orig_Update() { }
        private void Update()
        {
            if (CompareHp > CurrentHp)
            {
                CurrentHp = CompareHp - ModHooks.Instance.OnEnemyDamage(CompareHp - CurrentHp);
                if (CurrentHp < 0)
                {
                    CompareHp -= CurrentHp;
                    CurrentHp = 0;
                }
            }
            orig_Update();
        }
        
    }
}