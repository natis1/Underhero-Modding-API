using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::AngryMobManager")]
    public class AngryMobManager2 : AngryMobManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "AngryMobManager");
        }
    }
}