using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MonoMod.Utils;
using UnityEngine;
using Object = System.Object;

namespace Modding
{
    internal static class ModLoader
    {
        private static bool loaded;
        private static List<Mod> loadedMods;

        private static ModVersionDraw _draw;

        public const string MODS_FOLDER = "Mods";
        public const string RELINK_FOLDER = ".relinked";

        public static void LoadMods()
        {
            if (loaded) return;

            if (!Directory.Exists(MODS_FOLDER))
            {
                Directory.CreateDirectory(MODS_FOLDER);
            }

            if (!Directory.Exists($"{MODS_FOLDER}{Path.DirectorySeparatorChar}{RELINK_FOLDER}"))
            {
                Directory.CreateDirectory($"{MODS_FOLDER}{Path.DirectorySeparatorChar}{RELINK_FOLDER}");
            }

            DirectoryInfo relinkInfo = new DirectoryInfo($"{MODS_FOLDER}{Path.DirectorySeparatorChar}{RELINK_FOLDER}");
            relinkInfo.Attributes |= FileAttributes.Hidden;

            loadedMods = new List<Mod>();

            string ModText = "Underhero Modding API - Version " + ModHooks.API_VERSION;

            //Init mods from dlls. GetFiles is case-insensitive
            foreach (string name in Directory.GetFiles(MODS_FOLDER, "*.dll"))
            {
                Logger.LogDebug($"[API] Loading mods from assembly: \"{name}\"");
                try
                {
                    //Relinker.Combine(stream, Path.GetFileNameWithoutExtension(name));
                    Assembly asm = Assembly.LoadFile(name);
                    foreach (Type type in asm.GetExportedTypes())
                    {
                        if (type.IsSubclassOf(typeof(Mod)))
                        {
                            Mod mod = (Mod)Activator.CreateInstance(type);

                            if (mod == null)
                            {
                                Logger.LogWarn($"[API] Could not instantiate mod \"{type}\" from file \"{name}\"");
                                continue;
                            }

                            loadedMods.Add(mod);
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    Logger.LogError($"[API] Failed to load mod: \"{name}\"\n{e}");
                }
            }

            //Sort can't take a lambda for some reason, gotta use this messier OrderBy implementation
            loadedMods = loadedMods.OrderBy(mod =>
            {
                try
                {
                    return mod.LoadPriority();
                }
                catch (Exception e)
                {
                    Logger.LogError($"[API] Failed to get load priority from mod: \"{mod.GetModNameSafe()}\"\n{e}");
                    return Mod.DEFAULT_PRIORITY;
                }
            }).ToList();

            List<Mod> failedInit = new List<Mod>();

            foreach (Mod mod in loadedMods)
            {
                string name = mod.GetModNameSafe();
                Logger.LogDebug($"[API] Attempting to initialize mod \"{name}\"");
                try
                {
                    mod.Initialize();
                    Logger.Log($"[API] Mod \"{name}\" initialized");
                    ModText += "\n" + mod.GetModName() + " - Version: " + mod.GetVersion();
                }
                catch (Exception e)
                {
                    Logger.LogError($"[API] Failed to initialize mod \"{name}\"\n{e}");
                    failedInit.Add(mod);
                }
            }

            loadedMods.RemoveAll(mod => failedInit.Contains(mod));
            
            GameObject gameObject = new GameObject();
            _draw = gameObject.AddComponent<ModVersionDraw>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            _draw.drawString = ModText;
            
            loaded = true;
        }
        
    }
}
