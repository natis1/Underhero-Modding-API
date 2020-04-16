using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::MainLabFirstSceneManager")]
    public class MainLabFirstSceneManager2 : MainLabFirstSceneManager
    {
        private void orig_OnEnable() { }
        private void OnEnable()
        {
            orig_OnEnable();
            TextStorage.SetDialogsFromKey(Dialogs, "MainLabFirstSceneManager");
        }
    }
}