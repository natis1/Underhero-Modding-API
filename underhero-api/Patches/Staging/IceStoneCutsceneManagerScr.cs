using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::IceStoneCutsceneManagerScr")]
    public class IceStoneCutsceneManagerScr2 : IceStoneCutsceneManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "IceStoneCutsceneManagerScr-" + gameObject.name);
        }
    }
}