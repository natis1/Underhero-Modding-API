using MonoMod;
using UnityEngine;
using UnityEngine.UI;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::PlayerJournalManagerScr")]
    public class PlayerJournalManagerScr2 : PlayerJournalManagerScr
    {

        private void orig_MakeAllPagesActiveBut() { }

        private void MakeAllPagesActiveBut()
        {
            orig_MakeAllPagesActiveBut();
            JournalPerPageManagerScr jppms = Pages[CurrPage].GetComponent<JournalPerPageManagerScr>();
            jppms.transform.Find("Page Title").GetComponent<Text>().text = TextStorage.Instance.GetString("Journal Page " + CurrPage);
            foreach (var go in jppms.Items)
            {
                var itemmgr = go.GetComponent<JournalPerItemManagerScr>();
                itemmgr.ObjectText.text = TextStorage.Instance.GetString("Journal Page " + CurrPage + " " + go.name);
            }
        }
    }
}