using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::EndsHallwayIntroManagerScr")]
    public class EndsHallwayIntroManagerScr2 : EndsHallwayIntroManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "EndsHallwayIntroManagerScr");
        }
    }
}