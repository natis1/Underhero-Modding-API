using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::GraveyardRaceManagerScr")]
    public class GraveyardRaceManagerScr2 : GraveyardRaceManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "GraveyardRaceManagerScr");
        }
    }
}