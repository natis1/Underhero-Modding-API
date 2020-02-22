using MonoMod;
using Steamworks;
using UnityEngine;

namespace Modding.Patches
{
    [MonoModPatch("global::NumberersSpawnerScr")]
    public class NumberersSpawnerScr2 : NumberersSpawnerScr
    {

        [MonoModReplace]
        public new void SpawnNumberersM(GameObject BaseObjt, string Stringer, Color ToColor,
            NumberersSpawnerScr.AdditActs Additter)
        {
            this.CurrColor = ToColor;
            Vector3 position1 = BaseObjt.transform.position;
            Vector3 position2 = (!(bool) ((Object) BaseObjt.GetComponent<EnemyHealthPointsScript>())
                                    ? (!(bool) ((Object) BaseObjt.GetComponent<BossHealthPointsScript>())
                                        ? position1 + this.PlayerOffsetAdder(BaseObjt)
                                        : position1 + this.BossOffsetAdderM(BaseObjt))
                                    : position1 + this.EnemOffsetAdderM(BaseObjt)) + this.AdditVectTurnerM(BaseObjt);
            if ((Object) this.BgFab != (Object) null)
                ObjectPool.Spawn<Component>(this.BgFab, position2, this.PlayerRottFinderM());
            char[] charArray = Stringer.ToCharArray();
            int[] numArray = new int[charArray.Length];
            for (int index = 0; index < charArray.Length; ++index)
                numArray[index] = int.Parse(charArray[index].ToString());
            Vector3 vector3 =
                position2 + Vector3.right * Random.Range(-this.Values[1].ParamValue, this.Values[1].ParamValue) +
                Vector3.up * Random.Range(-this.Values[2].ParamValue, this.Values[2].ParamValue);
            
            SpawnTheAdditM(new Vector3(vector3.x + ( (charArray.Length - 1) * this.Values[0].ParamValue / 2f), vector3.y, vector3.z), Additter);
            SpawnNumArrayAtPosition(vector3, numArray);
        }


        [MonoModReplace]
        public new void SpawnNumberersM(GameObject BaseObjt, string Stringer, Color ToColor)
        {
            this.CurrColor = ToColor;
            Vector3 position1 = BaseObjt.transform.position;
            Vector3 position2 = (!(bool) ((Object) BaseObjt.GetComponent<EnemyHealthPointsScript>())
                                    ? (!(bool) ((Object) BaseObjt.GetComponent<BossHealthPointsScript>())
                                        ? position1 + this.PlayerOffsetAdder(BaseObjt)
                                        : position1 + this.BossOffsetAdderM(BaseObjt))
                                    : position1 + this.EnemOffsetAdderM(BaseObjt)) + this.AdditVectTurnerM(BaseObjt);
            if ((Object) this.BgFab != (Object) null)
                ObjectPool.Spawn<Component>(this.BgFab, position2, this.PlayerRottFinderM());
            Vector3 Pooser =
                position2 + Vector3.right * Random.Range(-this.Values[1].ParamValue, this.Values[1].ParamValue) +
                Vector3.up * Random.Range(-this.Values[2].ParamValue, this.Values[2].ParamValue);
            SpawnNumbersAtPosition(Pooser, uint.Parse(Stringer));
        }

        [MonoModReplace]
        private void NumberersOverSpawnerM(GameObject BaseObjt, Vector3 Position, char[] Charerst, int[] numArray)
        {
            SpawnNumArrayAtPosition(Position, numArray);
        }

        
        public void SpawnNumbersAtPosition(Vector3 Position, uint Value)
        {
            char[] chars = Value.ToString().ToCharArray();
            int[] numArray = new int[Value.ToString().ToCharArray().Length];
            for (int index = 0; index < chars.Length; ++index)
                numArray[index] = int.Parse(chars[index].ToString());
            SpawnNumArrayAtPosition(Position, numArray);
        }
        
        private void SpawnNumArrayAtPosition(Vector3 Position, int[] numArray)
        {
            float middlePosition = numArray.Length / 2.0f - 0.5f;
            for (int i = 0; i < numArray.Length; i++)
            {
                float offset = (i - middlePosition);
                SpawnNumberAtM(numArray[i], new Vector3(Position.x + Values[0].ParamValue * offset, Position.y, Position.z));
            }
        }

        [MonoModIgnore]
        private void SpawnTheAdditM(Vector3 MostLeftPos, NumberersSpawnerScr.AdditActs Additter) { }
        
        [MonoModIgnore] private void SpawnNumberAtM(int Numberer, Vector3 Pooser) { }
        
        [MonoModIgnore] private Vector3 PlayerOffsetAdder(GameObject BaseObjt, ref bool Righter) {return Vector3.zero;}
        
        [MonoModIgnore] private Vector3 BossOffsetAdderM(GameObject Enem) {return Vector3.zero; }

        [MonoModIgnore] private Vector3 EnemOffsetAdderM(GameObject Enem) { return Vector3.zero;}
        
        [MonoModIgnore] private Vector3 PlayerOffsetAdder(GameObject BaseObjt) {return Vector3.zero;}
        
        [MonoModIgnore] private Vector3 AdditVectTurnerM(GameObject BaseObjt) {return Vector3.zero;}
        
        [MonoModIgnore] private Quaternion PlayerRottFinderM() {return Quaternion.identity;}
    }
}