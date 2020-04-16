using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::MainLabSecondSceneManager")]
    public class MainLabSecondSceneManager2 : MainLabSecondSceneManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "MainLabSecondSceneManager");
        }
    }
}