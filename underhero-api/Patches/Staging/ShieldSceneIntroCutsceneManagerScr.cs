using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ShieldSceneIntroCutsceneManagerScr")]
    public class ShieldSceneIntroCutsceneManagerScr2 : ShieldSceneIntroCutsceneManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ShieldSceneIntroCutsceneManagerScr");
        }
    }
}