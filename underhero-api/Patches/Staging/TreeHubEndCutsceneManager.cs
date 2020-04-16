using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::TreeHubEndCutsceneManager")]
    public class TreeHubEndCutsceneManager2 : TreeHubEndCutsceneManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "TreeHubEndCutsceneManager");
        }
    }
}