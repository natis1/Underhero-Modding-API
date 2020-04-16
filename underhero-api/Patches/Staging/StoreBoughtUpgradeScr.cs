using System;
using MonoMod;
using UnityEngine;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::StoreBoughtUpgradeScr")]
    public class StoreBoughtUpgradeScr2 : StoreBoughtUpgradeScr
    {
        private void orig_OnEnable() { }

        private void OnEnable()
        {
            orig_OnEnable();
            string[] s = new string[0];
            int splitNum = 0;
            string nums = "";

            switch (CurrentUpgrade)
            {
                case StoreBoughtUpgradeScr.TypesOfUpgrades.AttackUpgrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade Attack").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    break;
                case StoreBoughtUpgradeScr.TypesOfUpgrades.LifeUpgrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade HP").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    break;
                case StoreBoughtUpgradeScr.TypesOfUpgrades.ShieldUpgrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade Shield").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    break;
                case StoreBoughtUpgradeScr.TypesOfUpgrades.PotionUpGrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade Potions").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    break;
                case StoreBoughtUpgradeScr.TypesOfUpgrades.SwordUpgrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade Sword").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    nums = TextStorage.Instance.GetString("Store Bought Upgrade Sword Level");
                    if (PlayerPrefs.GetInt("SwordChargeUpgrade1") == 1)
                    {
                        if (PlayerPrefs.GetInt("SwordChargeUpgrade2") == 1)
                        {
                            splitNum++;
                            if (PlayerPrefs.GetInt("SwordStaminaUpgrade1") == 1)
                            {
                                splitNum++;
                            }
                        }
                    }
                    else
                        nums = "";
                    break;
                case StoreBoughtUpgradeScr.TypesOfUpgrades.SlingUpgrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade Slingshot").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    nums = TextStorage.Instance.GetString("Store Bought Upgrade Slingshot Level");
                    if (PlayerPrefs.GetInt("SlingshotSizeUpgrade1") == 1)
                    {
                        if (PlayerPrefs.GetInt("SlingshotSizeUpgrade2") == 1)
                        {
                            splitNum++;
                            if (PlayerPrefs.GetInt("SlingshotReticuleUpgrade") == 1)
                            {
                                splitNum++;
                                if (PlayerPrefs.GetInt("SlingshotSizeUpgrade3") == 1)
                                {
                                    splitNum++;
                                }
                            }
                        }
                    }
                    else
                        nums = "";
                    break;
                case StoreBoughtUpgradeScr.TypesOfUpgrades.StaminaUpgrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade Stamina").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    nums = TextStorage.Instance.GetString("Store Bought Upgrade Stamina Level");
                    if (PlayerPrefs.GetInt("StaminaRegenUpgrade1") == 1)
                    {
                        if (PlayerPrefs.GetInt("StaminaRegenUpgrade2") == 1)
                        {
                            splitNum++;
                            if (PlayerPrefs.GetInt("StaminaRegenUpgrade3") == 1)
                            {
                                splitNum++;
                            }
                        }
                    }
                    else
                        nums = "";

                    break;
                case StoreBoughtUpgradeScr.TypesOfUpgrades.HammerUpgrade:
                    s = TextStorage.Instance.GetString("Store Bought Upgrade Hammer").Split(new string[] {"<br>"}, StringSplitOptions.None);
                    nums = TextStorage.Instance.GetString("Store Bought Upgrade Hammer Level");
                    if (PlayerPrefs.GetInt("HammerStaminaUpgrade1") == 1)
                    {
                        if (PlayerPrefs.GetInt("HammerStaminaUpgrade2") == 1)
                        {
                            splitNum++;
                            if (PlayerPrefs.GetInt("HammerStunUpgrade") == 1)
                            {
                                splitNum++;
                            }
                        }
                    }
                    else
                        nums = "";
                    break;
            }

            if (s.Length != 2)
            {
                return;
            }

            HeaderHolder.ParamText = s[0];
            BottomHolder.ParamText = s[1];

            if (nums.Length > 0)
            {
                Numberer = nums.Split(new []{"<br>"}, StringSplitOptions.None)[splitNum];
            }
        }
        
    }
}