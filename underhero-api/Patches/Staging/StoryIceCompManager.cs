using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::StoryIceCompManager")]
    public class StoryIceCompManager2 : StoryIceCompManager
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "StoryIceCompManager");
        }
    }
}