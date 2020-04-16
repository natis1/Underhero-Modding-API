using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::NeddleRoOmIntroManager")]
    public class NeddleRoOmIntroManager2 : NeddleRoOmIntroManager
    {
        private void orig_Awake() { }
        private void Awake()
        {
            orig_Awake();
            TextStorage.SetDialogsFromKey(LordDialogs, "NeddleRoOmIntroManager-Lord");
            TextStorage.SetDialogsFromKey(AminoDialogs, "NeddleRoOmIntroManager-Amino");
        }
    }
}