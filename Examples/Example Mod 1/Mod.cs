namespace ExampleMod1
{
	// All mods must extend the Modding.Mod class, this allows them to automatically
	// be loaded and recognized. A single dll file can contain multiple Mods which will
	// be loaded separately.
	public class Mod : Modding.Mod
	{
		// Use this function to start the mod. this code is run right when the mod is being
		// loaded and it allows you to set things up (eg add methods to all the events and hooks you intend to use)
		public override void Init()
		{
			// We can set the mod name here, this tells other mods, and the api, what we are called
			this._modName = "Example Mod 1";
			
			// These things are called Events. an Event is basically an object that you can add methods to
			// Just like this code suggests. Simply type [event name] += [method name]; as you see below
			// An event will run your method at a certain time, in this case, whenever the player is hurt
			Modding.ModHooks.Instance.PlayerHurt += InstanceOnPlayerHurt;
			// Whenever the player gains experience
			Modding.ModHooks.Instance.GainXP += InstanceOnGainXP;
			// And whenever an enemy takes damage
			Modding.ModHooks.Instance.EnemyDamage += InstanceOnEnemyDamage;
			
			// Modding.Logger.Log is a function that lets us print messages to a log file.
			// This log file is located in Mod Logs, a folder in your game install location
			// This can be helpful for finding bugs (the bad kind)
			Modding.Logger.Log("Example mod 1 loaded. This mod makes the game much easier");
		}

		// This method is provided with the damage dealt to the enemy, and whatever it returns becomes
		// the new damage dealt. So in this case it takes the existing damage and doubles it
		// Meaning the enemy would be twice as hurt
		private int InstanceOnEnemyDamage(int damage)
		{
			return damage * 2;
		}

		// This method is provided with the xp the user gained, and whatever it returns becomes
		// the new xp gained. So in this case the user would gain twice as much experience.
		private int InstanceOnGainXP(int xp)
		{
			return xp * 2;
		}

		// This method is provided the damage dealt to the player, and whatever it returns becomes
		// the new damage dealt. So in this case the user would take half as much damage.
		private int InstanceOnPlayerHurt(int damage)
		{
			if (damage > 1)
				return damage / 2;
			return damage;
		}
	}
}