using System;
using MonoMod;
using UnityEngine.SceneManagement;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::FloodedTreeTalkPromptScr")]
    public class FloodedTreeTalkPromptScr2 : FloodedTreeTalkPromptScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            string text = TextStorage.Instance.GetString("FloodedTreeTalkPromptScr-" +
                                                         SceneManager.GetActiveScene().name + "/" + gameObject.name);
            if (String.IsNullOrEmpty(text))
            {
                text = TextStorage.Instance.GetString("FloodedTreeTalkPromptScr-" + SceneManager.GetActiveScene().name);
            }
            TextStorage.SetDialogsFromText(Dialogs, text);
        }
    }
}