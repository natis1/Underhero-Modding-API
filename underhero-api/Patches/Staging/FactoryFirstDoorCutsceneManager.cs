using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::FactoryFirstDoorCutsceneManager")]
    public class FactoryFirstDoorCutsceneManager2 : FactoryFirstDoorCutsceneManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "FactoryFirstDoorCutsceneManager");
        }
    }
}