using System;
using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SideChilliNpcSCr")]
    public class SideChilliNpcSCr2 : SideChilliNpcSCr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "SideChilliNpcSCr");
        }
    }
}