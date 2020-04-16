using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::StitchesRoomManagerScr")]
    public class StitchesRoomManagerScr2 : StitchesRoomManagerScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            TextStorage.SetDialogsFromKey(Dialogs, "StitchesRoomManagerScr");
        }
    }
}