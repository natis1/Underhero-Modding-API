using MonoMod;
using UnityEngine;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::PlayerCardScript")]
    public class PlayerCardScript2 : PlayerCardScript
    {
        [MonoModIgnore] private int SaveLocationHash;
        private void orig_RafaCardDrawingM() { }

        private void RafaCardDrawingM()
        {
            orig_RafaCardDrawingM();
            
            string location = TextStorage.Instance.GetString(GamePlayerPrefList.Database.RunningLists.StringsList[1].Text);
            if (location == "")
            {
                location = TextStorage.Instance.GetString("Not Saved");
            }
            DrawManagerScr.Drawer.DrawTextM(SaveLocationHash,
                GuiDepther, Color.black, Texters[5].Recter, location, Style2);

        }
        
    }
}