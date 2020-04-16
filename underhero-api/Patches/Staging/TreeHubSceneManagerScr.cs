using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::TreeHubSceneManagerScr")]
    public class TreeHubSceneManagerScr2 : TreeHubSceneManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "TreeHubSceneManagerScr");
        }
    }
}