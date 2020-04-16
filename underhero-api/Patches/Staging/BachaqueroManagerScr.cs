using MonoMod;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::BachaqueroManagerScr")]
    public class BachaqueroManagerScr2 : BachaqueroManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "BachaqueroManagerScr-" + SceneManager.GetActiveScene().name + "/" + gameObject.name);
        }
    }
}