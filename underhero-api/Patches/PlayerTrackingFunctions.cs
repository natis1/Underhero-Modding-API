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

        public static void MakeExpNumbersModded(GameObject BaseObjt, string Stringer)
        {
            NumberersSpawnerScr component = GameObject.FindWithTag("Item Database").GetComponent<NumberersSpawnerScr>();
            component.SpawnNumberersM(BaseObjt, Stringer, component.ExperienceColor, NumberersSpawnerScr.AdditActs.Exp);
        }

        public static void MakeExpNumbersModded(string drawText)
        {
            MakeExpNumbersModded(GameObject.FindGameObjectWithTag("Player"), drawText);
        }
    }
}