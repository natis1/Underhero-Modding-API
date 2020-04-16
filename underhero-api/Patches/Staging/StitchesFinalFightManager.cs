using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::StitchesFinalFightManager")]
    public class StitchesFinalFightManager2 : StitchesFinalFightManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "StitchesFinalFightManager");
        }
    }
}