using MonoMod;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modding.Patches
{
    [MonoModPatch("global::PlayerTrackingFunctions")]
    public class PlayerTrackingFunctions2 : PlayerTrackingFunctions
    {
        public new void MakeExpNumbers(GameObject BaseObjt, string Stringer)
        {
            
        }

        public static void MakeExpNumbersModded(GameObject BaseObjt, uint Stringer)
        {
            NumberersSpawnerScr component = GameObject.FindWithTag("Item Database").GetComponent<NumberersSpawnerScr>();
            component.SpawnNumberersM(BaseObjt, Stringer.ToString(), component.ExperienceColor, NumberersSpawnerScr.AdditActs.Exp);
        }

        public static void MakeExpNumbersModded(uint numbers)
        {
            MakeExpNumbersModded(GameObject.FindGameObjectWithTag("Player"), numbers);
        }
    }
}