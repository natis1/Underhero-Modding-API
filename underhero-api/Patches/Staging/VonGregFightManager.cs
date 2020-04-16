using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::VonGregFightManager")]
    public class VonGregFightManager2 : VonGregFightManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            // There are two very similar dialog keys for this. I am not sure if key 1 or 2 is correct.
            // If this breaks stuff please switch it to 2.
            // TODO: Verify the proper key.
            TextStorage.SetDialogsFromKey(Dialogs, "VonGregFightManager-1");
        }
    }
}