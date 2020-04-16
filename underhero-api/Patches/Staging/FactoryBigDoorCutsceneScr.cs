using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::FactoryBigDoorCutsceneScr")]
    public class FactoryBigDoorCutsceneScr2 : FactoryBigDoorCutsceneScr
    {
        private void orig_OnEnable() { }
        private void OnEnable()
        {
            orig_OnEnable();
            TextStorage.SetDialogsFromKey(Dialogs, "FactoryBigDoorCutsceneScr");
        }
    }
}