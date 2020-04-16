using System;
using MonoMod;
using UnityEngine;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::EvilStoreManagerScript")]
    public class EvilStoreManagerScript2 : EvilStoreManagerScript
    {

        [MonoModIgnore]
        private int Price;
        private void orig_StoreStringsFillerMethod(StoreItemsBuilderScript Item, int PriceDisp) { }

        private void StoreStringsFillerMethod(StoreItemsBuilderScript Item, int PriceDisp)
        {
            orig_StoreStringsFillerMethod(Item, PriceDisp);
            
            // keep item.ItemName in english as the reference for the item. true ItemName will be set by the program.
            string s = TextStorage.Instance.GetString("EvilStore Item " + Item.ItemName);
            
            // Replace this reflection silliness with a simple direct access to price.
            if (Price == 10000 || Price == 15000)
            {
                s = TextStorage.Instance.GetString("EvilStore Item Unavailable");
                PriceString.GetComponent<TextMesh>().text = TextStorage.Instance.GetString("EvilStore Item Full");
            } else if (Price == 0)
            {
                s = TextStorage.Instance.GetString("EvilStore Item Unavailable");
            }
            string[] split = s.Split(new[] {"<br>"}, StringSplitOptions.None);
            if (split.Length != 5)
            {
                return;
            }

            // Replace with direct access to the private vars obviously
            ItemName.GetComponent<TextMesh>().text = split[0];
            ItemLine1.GetComponent<TextMesh>().text = split[1];
            ItemLine2.GetComponent<TextMesh>().text = split[2];
            ItemLine3.GetComponent<TextMesh>().text = split[3];
            ItemLine4.GetComponent<TextMesh>().text = split[4];
        }
    }
}