using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::HandyMirrorCutSceneManager")]
    public class HandyMirrorCutSceneManager2 : HandyMirrorCutSceneManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "HandyMirrorCutSceneManager");
        }
    }
}