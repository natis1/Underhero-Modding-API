using System;
using MonoMod;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::NpcConversationScript")]
    public class NpcConversationScript2 : NpcConversationScript
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
        
        
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            
            string text;
            if (!String.IsNullOrEmpty(DialogKey))
            {
                text = TextStorage.Instance.GetString(DialogKey);
            }
            else
            {
                text = TextStorage.Instance.GetString("NpcConversationScript-" + SceneManager.GetActiveScene().name + "/" +
                                                      gameObject.name);
                if (String.IsNullOrEmpty(text))
                {
                    text = TextStorage.Instance.GetString("NpcConversationScript-" + gameObject.name);
                }
            }

            string[] dialogCollections = text.Split(new[] {"<pg>"}, StringSplitOptions.None);
            for (int i = 0; i < DialogsArray.Count; i++)
            {
                TextStorage.SetDialogsFromText(DialogsArray[i].Dialogs, dialogCollections[i]);
            }

        }
    }
}