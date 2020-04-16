using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::HeroesDropManagerScr")]
    public class HeroesDropManagerScr2 : HeroesDropManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "HeroesDropManagerScr");
        }
    }
}