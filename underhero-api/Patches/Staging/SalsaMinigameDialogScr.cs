using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SalsaMinigameDialogScr")]
    public class SalsaMinigameDialogScr2 : SalsaMinigameDialogScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(DialogsArray, "SalsaMinigameDialogScr");
        }
    }
}