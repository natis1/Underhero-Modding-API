using Modding.Patches;

namespace Modding
{
    public class Helpers
    {
        
        // This new useful function lets you add xp from other mods
        public static void AddXP(int xp)
        {
            // We do not need to add the on gain xp hook because changing the amount of xp gained
            // will automatically proc the conditions needed for that hook to be run.
            PlayerExperienceTracker2.Instance.LevelEXP += xp;
            PlayerExperienceTracker2.Instance.TotalEXP += xp;
        }
    }
}