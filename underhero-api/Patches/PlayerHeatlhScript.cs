using MonoMod;

namespace Modding.Patches
{
    
    [MonoModPatch("global::PlayerHeatlhScript")]
    public class PlayerHeatlhScript2 : PlayerHeatlhScript
    {
        private void orig_Update() { }
        private void Update()
        {
            if (CurrentHealth < CompareHealth)
            {
                CurrentHealth = CompareHealth - ModHooks.Instance.OnPlayerHurt(CompareHealth - CurrentHealth);
            }
            orig_Update();
        }

    }
}