using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::FifthTutorialManagerScr")]
    public class FifthTutorialManagerScr2 : FifthTutorialManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "FifthTutorialManagerScr");
        }
    }
}