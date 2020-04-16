using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SecondTutorialManagerScr")]
    public class SecondTutorialManagerScr2 : SecondTutorialManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "SecondTutorialManagerScr");
        }
    }
}