using MonoMod;
using UnityEngine.InputSystem;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::MainMenuScript")]
    public class MainMenuScript2 : MainMenuScript
    {
        private void orig_LetterInputCommandKeyboard() { }
        
        [MonoModIgnore] private void LeaveNameInputM() { }
        [MonoModIgnore] private PlayerTrackingFunctions Trackingtong;
        
        private void LetterInputCommandKeyboard()
        {
            if (Keyboard.current.backspaceKey.wasPressedThisFrame && !NewInputListenerRafaScr.Instance.UniversalBackLimiter)
            {
                if (this.NameInput.Length == 0)
                {
                    this.LeaveNameInputM();
                }
                else
                {
                    this.NameInput = this.NameInput.Remove(this.NameInput.Length - 1);
                }
            }
            else if (!Keyboard.current.backspaceKey.isPressed && !Keyboard.current.enterKey.isPressed && !Keyboard.current.tabKey.isPressed && this.NameInput.Length < 9 && this.Trackingtong.RetrieveLastCharM() != null)
            {
                string c = Trackingtong.RetrieveLastCharM();
                // Prevent control characters in player name.
                if (c != "<" && c != ">")
                    this.NameInput += Trackingtong.RetrieveLastCharM();
            }
            if (this.NameInput.Length > 9)
            {
                this.NameInput = this.NameInput.Remove(9);
            }
        }
    }
}