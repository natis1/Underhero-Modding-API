using MonoMod;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ItormonHelperScr")]
    public class ItormonHelperScr2 : ItormonHelperScr
    {
        private void orig_DialogsFillingM() { }
        
        private void DialogsFillingM()
        {
            orig_DialogsFillingM();
            TextStorage.SetDialogsFromKey(NormalDialogs, SceneManager.GetActiveScene().name + " " + gameObject.name);
            TextStorage.SetDialogsFromKey(DrownedDialogs, "ItormonDrowned");
        }
        
    }
}