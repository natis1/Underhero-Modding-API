using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SixthTutorialManagerScr")]
    public class SixthTutorialManagerScr2 : SixthTutorialManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "SixthTutorialManagerScr");
        }
    }
}