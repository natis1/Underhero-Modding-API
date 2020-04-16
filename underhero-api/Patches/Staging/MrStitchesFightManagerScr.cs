using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::MrStitchesFightManagerScr")]
    public class MrStitchesFightManagerScr2 : MrStitchesFightManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "MrStitchesFightManagerScr");
        }
    }
}