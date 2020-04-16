using System;
using MonoMod;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    // AKA the elizabeth z button class.
    [MonoModPatch("global::PlayerDialogSwitcher")]
    public class PlayerDialogSwitcher2 : PlayerDialogSwitcher
    {
        private void Start()
        {
            TextStorage.SetDialogsFromKey(Dialoggers, "PlayerDialogSwitcher-" + SceneManager.GetActiveScene().name + "/" + gameObject.name);
        }
    }
}