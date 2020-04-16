using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ThirdTutorialManagerScr")]
    public class ThirdTutorialManagerScr2 : ThirdTutorialManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ThirdTutorialManagerScr");
        }
    }
}