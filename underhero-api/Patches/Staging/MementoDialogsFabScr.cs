using System;
using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::MementoDialogsFabScr")]
    public class MementoDialogsFabScr2 : MementoDialogsFabScr
    {
        private void orig_OnEnable() { }
        private void OnEnable()
        {
            orig_OnEnable();
            string text = TextStorage.Instance.GetString("MementoDialogsFabScr");
            string[] dialogs = text.Split(new[] {"<pg>"}, StringSplitOptions.None);
            TextStorage.SetDialogsFromText(FirstDialog.Dialogs, dialogs[0]);
            TextStorage.SetDialogsFromText(SecondDialog.Dialogs, dialogs[1]);
            TextStorage.SetDialogsFromText(ThirdDialog.Dialogs, dialogs[2]);
            TextStorage.SetDialogsFromText(FourthDialog.Dialogs, dialogs[3]);

        }
    }
}