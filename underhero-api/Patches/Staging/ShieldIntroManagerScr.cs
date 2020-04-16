using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ShieldIntroManagerScr")]
    public class ShieldIntroManagerScr2 : ShieldIntroManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ShieldIntroManagerScr");
        }
    }
}