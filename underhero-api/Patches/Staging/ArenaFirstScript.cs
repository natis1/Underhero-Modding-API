using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ArenaFirstScript")]
    public class ArenaFirstScript2 : ArenaFirstScript
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ArenaFirstScript");
        }
    }
}