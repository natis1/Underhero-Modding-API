using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ArenaCageManager")]
    public class ArenaCageManager2 : ArenaCageManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ArenaCageManager");
        }
    }
}