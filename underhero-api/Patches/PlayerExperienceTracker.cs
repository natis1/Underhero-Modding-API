using MonoMod;
using UnityEngine;

namespace Modding.Patches
{
    [MonoModPatch("global::PlayerExperienceTracker")]
    public class PlayerExperienceTracker2 : PlayerExperienceTracker
    {
        [MonoModIgnore]
        private int CompareEXP;
        
        public int _CompareEXP
        {
            get { return CompareEXP; }
            set { CompareEXP = value; }
        }


        private int trueCompareXP;
        
        
        private static PlayerExperienceTracker _instance;
        
        // ReSharper disable once UnusedMember.Global Used Implicitly
        public static PlayerExperienceTracker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = UnityEngine.Object.FindObjectOfType<PlayerExperienceTracker>();
                }
                return _instance;
            }
        }

        private void orig_LevelControlFunction() {}

        // ReSharper disable once UnusedMember.Local Used Implicitly
        private void LevelControlFunction()
        {
            trueCompareXP = CompareEXP;
            if (CompareEXP != this.LevelEXP)
            {
                LevelEXP = CompareEXP + ModHooks.Instance.OnGainXP(LevelEXP - CompareEXP);
            }

            orig_LevelControlFunction();
            
            if (trueCompareXP != CompareEXP)
            {
                if (CompareEXP - trueCompareXP > 0)
                {
                    PlayerTrackingFunctions2.MakeExpNumbersModded(GameObject.FindGameObjectWithTag("Player"),
                        (uint) (LevelEXP - CompareEXP));
                }
            }
        }
    }
}