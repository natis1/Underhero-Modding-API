using UnityEngine;

namespace ExampleMod3
{
	// All mods must extend the Modding.Mod class, this allows them to automatically
	// be loaded and recognized. A single dll file can contain multiple Mods which will
	// be loaded separately.
	public class Mod : Modding.Mod
	{
		// Use this method to start the mod. this code is run right when the mod is being
		// loaded and it allows you to set things up (eg add methods to all the events and hooks you intend to use)
		public override void Init()
		{
			// We can set the mod name here, this tells other mods, and the api, what we are called
			this._modName = "Example Mod 3";
			// With the new modding api we can also set a version like so:
			this._modVersion = "1.0";
			
			
			// Instead of doing any hooking in this class, let's make a monobehavior.
			// This is a special unity class that attaches to game objects.
			// Gameobjects can be anything in the world (eg, an enemy, player, camera, or wall)
			// Monobehaviors allow us to run code on top of these objects. A good gameobject to attach to
			// is one that is persistent, as when a gameobject is destroyed, its monobehaviors are lost with it
			
			
			// Let's make a persistent GameObject that we can add our component to:
			GameObject go = new GameObject();
			// Don't destroy on load is a special flag that unity uses
			// which tells it to keep the game object alive between different scenes
			Object.DontDestroyOnLoad(go);
			// Now we can add our component to this new GameObject.
			go.AddComponent<ModBehaviour>();

			// To understand Modding.Logger.Log, please go back into example mod 2 or 1.
			// You can log whatever you want, and logging can be useful for
			// checking the status of your mod
			Modding.Logger.Log("Example mod 3 loaded. This mod adds a monobehavior that annotates your actions");
		}
	}
}