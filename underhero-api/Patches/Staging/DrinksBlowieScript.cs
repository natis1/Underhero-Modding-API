using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::DrinksBlowieScript")]
    public class DrinksBlowieScript2 : DrinksBlowieScript
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "DrinksBlowieScript-1");
            TextStorage.SetDialogsFromKey(Dialogs2, "DrinksBlowieScript-2");
        }
    }
}