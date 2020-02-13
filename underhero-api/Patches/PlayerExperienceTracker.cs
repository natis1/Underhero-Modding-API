using MonoMod;
using UnityEngine;

namespace Modding.Patches
{
    [MonoModPatch("global::PlayerExperienceTracker")]
    public class PlayerExperienceTracker2 : PlayerExperienceTracker
    {
        [MonoModIgnore]
        private int CompareEXP;

        private void orig_LevelControlFunction() {}

        private void LevelControlFunction()
        {
            if (CompareEXP != this.LevelEXP)
            {
                LevelEXP = CompareEXP + ModHooks.Instance.OnGainXP(LevelEXP - CompareEXP);
            }

            if (LevelEXP != CompareEXP)
            {
                PlayerTrackingFunctions2.MakeExpNumbersModded(GameObject.FindGameObjectWithTag("Player"),
                    (LevelEXP - CompareEXP).ToString());
            }

            orig_LevelControlFunction();
        }
    }
}