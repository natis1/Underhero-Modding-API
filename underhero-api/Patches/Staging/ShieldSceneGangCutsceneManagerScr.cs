using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ShieldSceneGangCutsceneManagerScr")]
    public class ShieldSceneGangCutsceneManagerScr2 : ShieldSceneGangCutsceneManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ShieldSceneGangCutsceneManagerScr");
        }
    }
}