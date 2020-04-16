using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::NightCutscenemanagerScr")]
    public class NightCutscenemanagerScr2 : NightCutscenemanagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "NightCutscenemanagerScr");
        }
    }
}