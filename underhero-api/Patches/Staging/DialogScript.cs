using System;
using System.Collections.Generic;
using MonoMod;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::DialogScript")]
    public class DialogScript2 : DialogScript
    {
        // Serialized by Unity, Ideally. Otherwise autodetect is always an option. Please switch this to a regular
        // variable instead of the weird field I have. This field was only used because of a bug with unity and monomod.
        // It will not occur when you copy this code into your thing.
        private string _DialogKey = "";

        public string DialogKey
        {
            get { return _DialogKey; }
            private set { _DialogKey = value; }
        }


        private void orig_OnEnable() { }
        private void OnEnable()
        {
            if (DialogKey != null)
                SetDialogTextFromKey(DialogKey);
            else 
                SetDialogTextFromKey();
            orig_OnEnable();
        }
        
        // Sets it from a key, if left blank will try to automatically detect key based on scene
        public void SetDialogTextFromKey(string InputKey = "")
        {
            string inputText = "";
            if (InputKey == "")
            {
                // First see if there's a key set for this specific gameobject and scene combo.
                inputText = TextStorage.Instance.GetString(SceneManager.GetActiveScene().name + "/" + name);
                if (inputText == "")
                {
                    // Then check if there's a key set for this specific gameobject name.
                    inputText = TextStorage.Instance.GetString(name);
                }
            }
            else
            {
                inputText = TextStorage.Instance.GetString(InputKey);
            }

            if (inputText == String.Empty)
            {
                return;
            }

            inputText = inputText.Replace("<hero>", PlayerName);
            string[] splitDialogs = inputText.Split(new string[] {"<nl>"}, StringSplitOptions.None);
            for (int i = 0; i < Math.Min(Dialogs.Count, splitDialogs.Length); i++)
            {
                string[] dialogComponents = splitDialogs[i].Split(new string[] {"<br>"}, StringSplitOptions.None);

                if (dialogComponents.Length != 4)
                {
                    Debug.Log("Invalid dialog string " + dialogComponents[i] + "\nShould have 4 components separated by <br>.\n" +
                    "[Name<br>Line1<br>Line2<br>Line3]. Use <br> even if some of these components are blank.");
                    return;
                }
                // Optional todo: Maybe consider adding some of the dialog's other functions as tags in the string.
                var dialog = Dialogs[i];
                dialog.Name = dialogComponents[0];
                dialog.Line1 = dialogComponents[1];
                dialog.Line2 = dialogComponents[2];
                dialog.Line3 = dialogComponents[3];
            }
        }
    }
}