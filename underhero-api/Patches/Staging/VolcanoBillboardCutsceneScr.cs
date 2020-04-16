using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::VolcanoBillboardCutsceneScr")]
    public class VolcanoBillboardCutsceneScr2 : VolcanoBillboardCutsceneScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "VolcanoBillboardCutsceneScr");
        }
    }
}