using System;
using MonoMod;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::RandomGossipScript")]
    public class RandomGossipScript2 : RandomGossipScript
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

        private void Start()
        {
            string text;
            if (!String.IsNullOrEmpty(DialogKey))
            {
                text = TextStorage.Instance.GetString(DialogKey);
            }
            else
            {
                text = TextStorage.Instance.GetString("RandomGossipScript-" + SceneManager.GetActiveScene().name + "/" +
                                                      gameObject.name);
                if (String.IsNullOrEmpty(text))
                {
                    text = TextStorage.Instance.GetString("RandomGossipScript-" + gameObject.name);
                }
            }

            string[] gossipLines = text.Split(new[] {"<nl>", "<br>"}, StringSplitOptions.None);
            if (gossipLines.Length != 12)
            {
                Debug.Log("Invalid dialog string " + text + "\nShould have 12 components separated by <br> or <nl>.\n" +
                          "Use <br> even if some of these components are blank.");
                return;
            }

            Opt1Line1 = gossipLines[0];
            Opt1Line2 = gossipLines[1];
            Opt1Line3 = gossipLines[2];
            Opt1Line4 = gossipLines[3];
            Opt2Line1 = gossipLines[4];
            Opt2Line2 = gossipLines[5];
            Opt2Line3 = gossipLines[6];
            Opt2Line4 = gossipLines[7];
            Opt3Line1 = gossipLines[8];
            Opt3Line2 = gossipLines[9];
            Opt3Line3 = gossipLines[10];
            Opt3Line4 = gossipLines[11];
        }
        
    }
}