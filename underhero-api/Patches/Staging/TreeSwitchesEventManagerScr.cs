using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::TreeSwitchesEventManagerScr")]
    public class TreeSwitchesEventManagerScr2 : TreeSwitchesEventManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "TreeSwitchesEventManagerScr");
        }
    }
}