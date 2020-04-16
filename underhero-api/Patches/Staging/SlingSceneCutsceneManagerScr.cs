using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SlingSceneCutsceneManagerScr")]
    public class SlingSceneCutsceneManagerScr2 : SlingSceneCutsceneManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "SlingSceneCutsceneManagerScr");
        }
    }}