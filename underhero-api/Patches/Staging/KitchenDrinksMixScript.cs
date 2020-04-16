using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::KitchenDrinksMixScript")]
    public class KitchenDrinksMixScript2 : KitchenDrinksMixScript
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "KitchenDrinksMixScript");
        }
    }
}