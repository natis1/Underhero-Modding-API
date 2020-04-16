using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::NightFightManagerScr")]
    public class NightFightManagerScr2 : NightFightManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "NightFightManagerScr");
        }
    }
}