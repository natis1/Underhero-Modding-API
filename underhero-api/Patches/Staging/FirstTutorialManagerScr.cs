using MonoMod;

namespace Modding.Patches.Staging
{
    
    [MonoModPatch("global::FirstTutorialManagerScr")]
    public class FirstTutorialManagerScr2 : FirstTutorialManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "FirstTutorialManagerScr");
        }
    }
}