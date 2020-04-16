using MonoMod;
using UnityEngine;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::GuiCharacterElements3")]
    public class GuiCharacterElements32 : GuiCharacterElements3
    {
        [MonoModIgnore]
        private PlayerHeatlhScript HealthChecker;
        
        [MonoModIgnore]
        private int PlayerStateHash;

        private void orig_StatusDrawerMethod(Rect coord, float alpha) { }

        private void StatusDrawerMethod(Rect coord, float alpha)
        {
            orig_StatusDrawerMethod(coord, alpha);
            switch (HealthChecker.CurrStatus)
            {
                case PlayerHeatlhScript.Statuses.Normal:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Normal"), StatusStyle);
                    break;
                case PlayerHeatlhScript.Statuses.Poisoned:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Poisoned"), StatusStyle);
                    break;
                case PlayerHeatlhScript.Statuses.Burnt:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Burnt"), StatusStyle);
                    break;
                case PlayerHeatlhScript.Statuses.Frightened:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Scared"), StatusStyle);
                    break;
            }
        }

        private void orig_StatusDrawerMethod(Rect coord) { }

        private void StatusDrawerMethod(Rect coord)
        {
            orig_StatusDrawerMethod(coord);
            switch (HealthChecker.CurrStatus)
            {
                case PlayerHeatlhScript.Statuses.Normal:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Normal"), StatusStyle);
                    break;
                case PlayerHeatlhScript.Statuses.Poisoned:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Poisoned"), StatusStyle);
                    break;
                case PlayerHeatlhScript.Statuses.Burnt:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Burnt"), StatusStyle);
                    break;
                case PlayerHeatlhScript.Statuses.Frightened:
                    DrawManagerScr.Drawer.DrawTextM(PlayerStateHash,
                        GuiLayerDepth, StatusStyle.normal.textColor, coord, TextStorage.Instance.GetString("Status Scared"), StatusStyle);
                    break;
            }
        }
    }
}