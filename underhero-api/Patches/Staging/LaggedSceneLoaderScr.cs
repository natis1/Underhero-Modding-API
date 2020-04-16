using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::LaggedSceneLoaderScr")]
    public class LaggedSceneLoaderScr2 : LaggedSceneLoaderScr
    {
        private void orig_Start() { }

        private void Start()
        {
            orig_Start();
            LoadingText = TextStorage.Instance.GetString("Loading Text");
        }
    }
}