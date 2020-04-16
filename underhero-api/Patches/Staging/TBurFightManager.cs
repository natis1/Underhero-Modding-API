using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::TBurFightManager")]
    public class TBurFightManager2 : TBurFightManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "TBurFightManager");
        }
    }
    
}