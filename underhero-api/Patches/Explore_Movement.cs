using MonoMod;

namespace Modding.Patches
{
    [MonoModPatch("global::Explore_Movement")]
    public class Explore_Movement2 : Explore_Movement
    {
        private static Explore_Movement _instance;
        
        public static Explore_Movement Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = UnityEngine.Object.FindObjectOfType<Explore_Movement>();
                }
                return _instance;
            }
        }

    }
}