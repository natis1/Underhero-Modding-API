using MonoMod;

namespace Modding.Patches
{
    [MonoModPatch("global::PauseMenuScript")]
    public class PauseMenuScript2 : PauseMenuScript
    {
        private static PauseMenuScript _instance;
        public static PauseMenuScript Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = UnityEngine.Object.FindObjectOfType<PauseMenuScript>();
                }
                return _instance;
            }
        }

    }
}