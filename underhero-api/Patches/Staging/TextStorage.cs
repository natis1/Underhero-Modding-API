using System;
using System.Collections.Generic;
using MonoMod;
using UnityEngine;
using UnityEngine.SceneManagement;


// TODO: attach this monobehavior to a gameobject that is instantiated exactly once
// and is never destroyed.
public class TextStorage : MonoBehaviour
{
    public List<string> _keys = new List<string>();
    public List<string> _values = new List<string>();
        
    // This dictionary should not be set from outside this class as this class alone should hold all
    // of the game's text.
    private Dictionary<string, string> gameStrings;

    // This code lets you get this monobehavior from ANYWHERE in code without needing to Find it.
    private static TextStorage _instance;
    public static TextStorage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType<TextStorage>();
            }
            return _instance;
        }
    }

    public static void SetDialogsFromKey(List<DialogBuilder> Dialogs, string InputKey)
    {
        string inputText = TextStorage.Instance.GetString(InputKey);
        SetDialogsFromText(Dialogs, inputText);
    }
    
    public static void SetDialogsFromKey(List<DialogPrefChooserScript> Dialogs, string InputKey)
    {
        string inputText = TextStorage.Instance.GetString(InputKey);
        SetDialogsFromText(Dialogs, inputText);
    }
    
    public static void SetDialogsFromText(List<DialogPrefChooserScript> Dialogs, string inputText)
    {
        string[] splitDialogs = inputText.Split(new string[] {"<pg>"}, StringSplitOptions.None);
        for (int i = 0; i < Math.Min(Dialogs.Count, splitDialogs.Length); i++)
        {
            SetDialogsFromText(Dialogs[i].Dialogs, splitDialogs[i]);
        }
    }

    public static void SetDialogsFromText(List<DialogBuilder> Dialogs, string inputText)
    {
        inputText = inputText.Replace("<hero>", PlayerPrefs.GetString("FileName" + PlayerPrefs.GetInt("CurrentFilePref")));
        string[] splitDialogs = inputText.Split(new string[] {"<nl>"}, StringSplitOptions.None);
        for (int i = 0; i < Math.Min(Dialogs.Count, splitDialogs.Length); i++)
        {
            string[] dialogComponents = splitDialogs[i].Split(new string[] {"<br>"}, StringSplitOptions.None);

            if (dialogComponents.Length != 4)
            {
                Debug.Log("Invalid dialog string " + dialogComponents[i] + "\nShould have 4 components separated by <br>.\n" +
                          "[Name<br>Line1<br>Line2<br>Line3]. Use <br> even if some of these components are blank.");
                return;
            }
            // Optional todo: Maybe consider adding some of the dialog's other functions as tags in the string.
            var dialog = Dialogs[i];
            dialog.Name = dialogComponents[0];
            dialog.Line1 = dialogComponents[1];
            dialog.Line2 = dialogComponents[2];
            dialog.Line3 = dialogComponents[3];
        }
    }


    public string GetString(string key)
    {
        // Check if our dictionary contains the data and that our key isn't empty
        return !string.IsNullOrEmpty(key) && gameStrings.ContainsKey(key) ? gameStrings[key] : "";
    }

    // Copy this method to automatically setup your language strings after loading them from unity
    public void OnAfterDeserialize()
    {
        gameStrings = new Dictionary<string, string>();

        for (var i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
        {
            gameStrings[_keys[i]] = _values[i];
        }
    }
        
    // Copy this method exactly as is to automatically serialize your language strings from a dict (if needed)
    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();
        foreach (var kvp in gameStrings)
        {
            _keys.Add(kvp.Key);
            _values.Add(kvp.Value);
        }
    }

    // WARNING
    // DO NOT UNDER ANY CIRCUMSTANCES ALLOW THIS FUNCTION TO MAKE IT TO PROD.
    // DO NOT COPY THIS FUNCTION, DATA SHOULD BE SET IN UNITY NOT IN CODE.
    public void DeserializeDataButWeArentUnityEngine()
    {
        
    }
}