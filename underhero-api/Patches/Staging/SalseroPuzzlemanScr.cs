using System;
using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SalseroPuzzlemanScr")]
    public class SalseroPuzzlemanScr2 : SalseroPuzzlemanScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "SalseroPuzzlemanScr");
        }
    }
}