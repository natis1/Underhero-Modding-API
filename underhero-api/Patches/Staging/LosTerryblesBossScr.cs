using System;
using MonoMod;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::LosTerryblesBossScr")]
    public class LosTerryblesBossScr2 : LosTerryblesBossScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            string text = TextStorage.Instance.GetString("LosTerryblesBossScr-" +
                                                         SceneManager.GetActiveScene().name + "/" + gameObject.name);
            if (String.IsNullOrEmpty(text))
            {
                text = TextStorage.Instance.GetString("LosTerryblesBossScr-" + SceneManager.GetActiveScene().name);
            }
            TextStorage.SetDialogsFromText(Dialogs, text);
        }
    }
}