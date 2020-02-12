using MonoMod;

//We don't care about XML docs for these as they are being patched into the original code
#pragma warning disable 1591
namespace Modding.Patches
{
    [MonoModPatch("global::MainMenuScript")]
    public class MainMenuScript2 : MainMenuScript
    {
        private bool loadedMods = false;
        private void orig_AtStartButtonPress() { }

        private void AtStartButtonPress()
        {
            if (!loadedMods)
            {
                Logger.Log("[API] - Main menu loading");
                ModLoader.LoadMods();
                loadedMods = true;
            }

            orig_AtStartButtonPress();
        }
    }
}