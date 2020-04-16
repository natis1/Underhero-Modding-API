using MonoMod;
using UnityEngine.UI;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::SaveAlbumPerTapeManagerScr")]
    public class SaveAlbumPerTapeManagerScr2 : SaveAlbumPerTapeManagerScr
    {
        [MonoModIgnore] private Text ObjectText;

        [MonoModIgnore] private Text MisteryObjectText;
        private void orig_Awake() { }
        private void Awake()
        {
            orig_Awake();

            MisteryObjectText.text = TextStorage.Instance.GetString("Unknown Tape Name");
            ObjectText.text =
                TextStorage.Instance.GetString("SaveAlbumPerTapeManagerScr-" + ObjectText.gameObject.name);
        }
    }
}