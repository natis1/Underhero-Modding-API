using System;
using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ChilliNpcScr")]
    public class ChilliNpcScr2 : ChilliNpcScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "ChilliNpcScr");
        }
    }
}