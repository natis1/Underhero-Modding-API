using System;
using MonoMod;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::FourthTutorialManagerScr")]
    public class FourthTutorialManagerScr2 : FourthTutorialManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            string text = TextStorage.Instance.GetString("FourthTutorialManagerScr-" +
                                                         SceneManager.GetActiveScene().name + "/" + gameObject.name);
            TextStorage.SetDialogsFromText(Dialogs, text);
        }
    }
}