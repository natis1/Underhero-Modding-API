using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::TheChattersBossScr")]
    public class TheChattersBossScr2 : TheChattersBossScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "TheChattersBossScr");
        }
    }
}