using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::YanijoNpcScr")]
    public class YanijoNpcScr2 : YanijoNpcScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "YanijoNpcScr");
        }
    }
}