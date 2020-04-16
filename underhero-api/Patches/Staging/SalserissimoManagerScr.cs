using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SalserissimoManagerScr")]
    public class SalserissimoManagerScr2 : SalserissimoManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "SalserissimoManagerScr");
        }
    }
}