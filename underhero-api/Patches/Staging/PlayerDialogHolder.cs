using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::PlayerDialogHolder")]
    public class PlayerDialogHolder2 : PlayerDialogHolder
    {
        private void orig_Awake()
        {
            
        }
        private void Awake()
        {
            orig_Awake();
            for (int i = 0; i < EnemDialogs.Count; i++)
            {
                TextStorage.SetDialogsFromKey(EnemDialogs[i].Dialogs, "Elizabeth" +  EnemDialogs[i].EnemType.ToString());
            }

            for (int i = 0; i < BossDialogs.Count; i++)
            {
                TextStorage.SetDialogsFromKey(BossDialogs[i].Dialogs, "Elizabeth" + BossDialogs[i].BossType.ToString());
            }
        }
    }
}