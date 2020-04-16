using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::FactoryLightsFailScr")]
    public class FactoryLightsFailScr2 : FactoryLightsFailScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "FactoryLightsFailScr");
        }
    }
}