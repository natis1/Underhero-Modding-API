using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ShieldRaceManagerScr")]
    public class ShieldRaceManagerScr2 : ShieldRaceManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ShieldRaceManagerScr");
        }
    }
}