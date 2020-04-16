using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::BoosFirstEncounterDialog")]
    public class BoosFirstEncounterDialog2 : BoosFirstEncounterDialog
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(DialogsArray, "BoosFirstEncounterDialog");
        }
    }
}