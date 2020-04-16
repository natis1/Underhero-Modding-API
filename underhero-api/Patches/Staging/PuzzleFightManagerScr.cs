using System;
using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::PuzzleFightManagerScr")]
    public class PuzzleFightManagerScr2 : PuzzleFightManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "PuzzleFightManagerScr");
        }
    }
}