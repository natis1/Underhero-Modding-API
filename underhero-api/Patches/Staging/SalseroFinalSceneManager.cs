using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SalseroFinalSceneManager")]
    public class SalseroFinalSceneManager2 : SalseroFinalSceneManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "SalseroFinalSceneManager");
        }
    }
}