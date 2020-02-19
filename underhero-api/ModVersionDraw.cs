using Modding.Patches;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable All
#pragma warning disable 1591

namespace Modding
{
    /// <inheritdoc />
    /// <summary>
    ///     Class to draw the version information for the mods on the main menu.
    /// </summary>
    public class ModVersionDraw : MonoBehaviour
    {
        private static GUIStyle style;

        /// <summary>
        ///     String to Draw
        /// </summary>
        public string drawString;

        /// <summary>
        ///     Run When Gui is shown.
        /// </summary>
        public void OnGUI()
        {
            //Logger.Log("Current screen is " + SceneManager.GetActiveScene().name);
            
            if (SceneManager.GetActiveScene().name != "Main Menu")
            {
                return;
            }

            if (style == null)
            {
                style = new GUIStyle(GUI.skin.label);
            }
            Color backgroundColor = GUI.backgroundColor;
            Color contentColor = GUI.contentColor;
            Color color = GUI.color;
            Matrix4x4 matrix = GUI.matrix;
            GUI.backgroundColor = Color.white;
            GUI.contentColor = Color.white;
            GUI.color = Color.white;
            style.alignment = TextAnchor.UpperRight;
            style.fontSize = 18;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
                new Vector3(Screen.width / 1920f, Screen.height / 1080f, -1f));
            GUI.Label(new Rect(0f, 0f, 1918f, 1080f), drawString, style);
            GUI.backgroundColor = backgroundColor;
            GUI.contentColor = contentColor;
            GUI.color = color;
            GUI.matrix = matrix;
        }
    }
}