using System;
using MonoMod;
using UnityEngine.UI;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::TheGlitchedTransitionScr")]
    public class TheGlitchedTransitionScene2 : TheGlitchedTransitionScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "TheGlitchedTransitionScr");
        }
    }
}