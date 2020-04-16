using System;
using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::TheEndsFightManagerScr")]
    public class TheEndsFightManagerScr2 : TheEndsFightManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "TheEndsFightManagerScr");
        }
    }
}