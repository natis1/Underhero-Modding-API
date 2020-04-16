using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::BroBlowieManagerScr")]
    public class BroBlowieManagerScr2 : BroBlowieManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "BroBlowieManagerScr");
        }
    }
}