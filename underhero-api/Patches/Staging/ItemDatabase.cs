using System;
using System.Collections.Generic;
using MonoMod;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::ItemDatabase")]
    public class ItemDatabase2 : ItemDatabase
    {
        public void CreateDatabaseM()
        {
            if ((Object) LinersFab != (Object) null)
                ObjectPool.CreatePool<Component>(LinersFab);
            Object.DontDestroyOnLoad((Object) gameObject);
            ItemsCompendium = new List<ItemAspects>();
            for (int i = 0; i <= 93; i++)
            {
                string s = TextStorage.Instance.GetString("Inventory " + i);
                string[] itemText = s.Split(new string[] {"<br>"}, StringSplitOptions.None);
                if (itemText.Length < 6)
                {
                    continue;
                }

                ItemAspects.ItemType iType = GetItemType(i);
                if (iType == ItemAspects.ItemType.Cocktail)
                {
                    ItemsCompendium.Add(new ItemAspects(itemText[0], i, itemText[1],
                        GetAlcoholContent(i), 0, iType, itemText[2],
                        itemText[3], itemText[4], itemText[5]));
                }
                else
                {
                    ItemsCompendium.Add(new ItemAspects(itemText[0], i, itemText[1],
                        0, 0, iType, itemText[2], itemText[3], itemText[4], itemText[5]));
                }
            }
        }
        
        
        
        private static int GetAlcoholContent(int itemNum)
        {
            switch (itemNum)
            {
                case 12:
                    return 3;
                case 13:
                    return 1;
                case 14:
                    return 2;
                case 15:
                    return 1;
                case 16:
                    return 2;
                case 17:
                    return 3;
                case 18:
                    return 2;
                case 19:
                    return 1;
                case 20:
                    return 1;
                case 21:
                    return 2;
                case 22:
                    return 2;
                case 23:
                    return 3;
                case 24:
                    return 2;
                case 25:
                    return 2;
                case 26:
                    return 3;
                case 27:
                    return 1;
                case 28:
                    return 2;
                case 29:
                    return 1;
                case 30:
                    return 3;
                case 31:
                    return 1;
                case 32:
                    return 2;
                case 33:
                    return 1;
                case 34:
                    return 1;
                case 35:
                    return 2;
                case 36:
                    return 1;
            }

            return 0;
        }

        private static ItemAspects.ItemType GetItemType(int itemNum)
        {
            if (itemNum == 0 || itemNum == 2 || itemNum == 44 || itemNum == 60 || itemNum == 63)
                return ItemAspects.ItemType.Consumable;
            if (itemNum == 64 || (itemNum >= 6 && itemNum <= 10))
                return ItemAspects.ItemType.QuestItem;
            if (itemNum >= 12 && itemNum <= 36)
                return ItemAspects.ItemType.Cocktail;
            if (itemNum >= 48 && itemNum <= 53)
                return ItemAspects.ItemType.Chilli;
            if (itemNum >= 55 && itemNum <= 57)
                return ItemAspects.ItemType.Salsa;
            if (itemNum == 43)
                return ItemAspects.ItemType.Equipment;
            return ItemAspects.ItemType.ImportantItem;
        }
        
    }
}