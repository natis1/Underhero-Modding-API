using UnityEngine;

namespace ExampleMod2
{
	// As before all mods must extend the Modding.Mod class, this allows them to automatically
	// be loaded and recognized.
	public class Mod : Modding.Mod
	{
		// This init code is run right when the mod is being loaded and it allows you to set things up
		// (eg add methods to all the events and hooks you intend to use)
		public override void Initialize()
		{
			// We can set the mod name here, this tells other mods, and the api, what we are called
			this._modName = "Example Mod 2";
			
			// These things are called Events. an Event is basically an object that you can add methods to
			// Just like this code suggests. Simply type [event name] += [method name]; as you see below
			// An event will run your method at a certain time, in this case, whenever the player does damage
			Modding.ModHooks.Instance.EnemyDamage += InstanceOnEnemyDamage;
			
			
			// This is a special kind of event, called a generated hook. These are made by monomod hookgen
			// a generated hook will, instead of running the main game's code when a method is called
			// run your code. Within your code you are capable of running the base
			// game's code after it is done. We will be using a hook to track when the player got a groovy hit.
			//
			// Notice the naming scheme. On.Class.Method. It's very explicit what it is doing
			// On in this case means "when Class.Method occurs".
			On.Explore_Movement.NotesEffectsMethod += GroovyHit;

			// Normally, the player experience tracker will play a snazzy sound effect whenever the player gets any XP
			// We want it to only run outside of combat so the player won't hear the xp sound effect while in battle
			// every time they get a hit
			On.PlayerExperienceTracker.LevelControlFunction += OnlyRunOutsideCombat;
			
			// Modding.Logger.Log is a method that lets us print messages to a log file.
			// This log file is located in Mod Logs, a folder in your game install location
			// This can be helpful for finding less mothy bugs (the bad kind)
			Modding.Logger.Log("Example mod 2 loaded. This mod makes groovin more fun");
		}

		private void OnlyRunOutsideCombat(On.PlayerExperienceTracker.orig_LevelControlFunction orig, PlayerExperienceTracker self)
		{
			// Check that the player is not in the middle of a battle
			if (Explore_Movement.Instance.Over_State != Explore_Movement.Player_States.Fighting)
			{
				// If not then reward them with the xp they have earned.
				orig(self);
			}
			
		}

		// We are going to store if the last hit was groovy or not in a global variable. this can be set and read
		// by any code in this file.

		private bool _lastHitGroovy = false;
		
		private void GroovyHit(On.Explore_Movement.orig_NotesEffectsMethod orig, Explore_Movement self,
			GameObject hittedenemy, Vector3 impactpoint,
			Explore_Movement.Attack_HUD_Objects typeofattack, bool recieverright)
		{
			// This method is only called if the player got a groovy hit so it being called means
			// that the hit they got was groovy
			_lastHitGroovy = true;
			
			// We can run the original method by passing it all of the arguments given to us in this hook
			orig(self, hittedenemy, impactpoint, typeofattack, recieverright);
		}

		// This method is provided with the damage dealt to the enemy, and whatever it returns becomes
		// the new damage dealt.
		
		// Our goal is to make it so that the player gains experience based on the damage dealt and does extra damage
		// when groovy attacking (and less otherwise)
		private int InstanceOnEnemyDamage(int damage)
		{
			// This method only provides us with the raw damage that we dealt, however
			// we have access to all of the singleton game classes.
			// These are provided to us through the modding api through a standard format: Class.Instance
			
			// To find out what information we can gain from these classes, you need to use a decompiler to look
			// at the assembly-csharp.dll file. The recommended way is to use the program dnspy. dnspy can be used interactively
			// on windows, or on windows and linux it can generate a static decompilation with the dnspy.console program
			// This decompilation can then be opened in an ide like Rider or visual studio code.
			
			// ALSO: in rider you can right click on any class and click go to -> declaration, and it will decompile that
			// class for you and show you what the contents of it are.
			
			// Let's if we are using the beatbox at all in this fight or not. If not, we want to not affect the damage done at all
			// This variable was originally private, but the modding api made it public so you can access it from a mod.
			// All formerly private variables made public will have an underscore before them.
			// It is common practice to name private variables with an underscore so this helps make it explicit that the variable
			// you are trying to access is supposed to be private.
			
			// HEY YOU, MODDER. Is there a private variable that you wish was exposed by the modding api?
			// Why not let me know, I can add it to the api, or if you know how you can too. The way that these variables are exposed
			// is very easy to do with the api. Your contribution would make it easier for everyone to mod.
			// Although you could just use reflection it would be better if you contributed to making
			// modding better for everyone!
			if (!Explore_Movement.Instance._UseBeat)
			{
				// Modding.Helpers are useful methods that can be called to make your modding easier without the need
				// for hooks. One nifty example is AddXP, which adds experience and draws the numbers. It WILL NOT
				// play the xp adding jingle.
				Modding.Helpers.AddXP(damage);
				
				// Since we are stopping the original method responsible for drawing numbers, we will need to draw our own
				// We can do this here
				PlayerTrackingFunctions.MakeExpNumbersModded(damage.ToString());
				PlayerExperienceTracker.Instance._CompareEXP = PlayerExperienceTracker.Instance.LevelEXP;
				
				return damage;
			}


			// Another variable that we can access from this class is the current selected weapon on attacking. We could for instance
			// decide that the hammer should be twice as strong as the others since it is harder to get groovy hits on

			if (Explore_Movement.Instance.Attack_HUD_Select == Explore_Movement.Attack_HUD_Objects.Hammer)
			{
				damage = damage * 2;
			}
			// Or maybe make the slingshot slightly weaker since it is easier to hit
			if (Explore_Movement.Instance.Attack_HUD_Select == Explore_Movement.Attack_HUD_Objects.Slingshot)
			{
				damage = (int) (damage * 0.75);
			}
			// In either case AUTOCOMPLETE IS YOUR FRIEND. It will help show you what options you have.
			
			// Finally, let's check if the player hit the beat. if not let's make them do 1 damage and if so let's give them
			// an extra 3 damage

			if (_lastHitGroovy)
			{
				damage = damage + 3;
			}
			else
			{
				damage = 1;
			}

			// The modding API gives us a quick and easy way to add experience!
			Modding.Helpers.AddXP(damage);
			// Since we are stopping the original method responsible for drawing numbers, we will need to draw our own
			PlayerTrackingFunctions.MakeExpNumbersModded(damage.ToString());
			PlayerExperienceTracker.Instance._CompareEXP = PlayerExperienceTracker.Instance.LevelEXP;


			// If they got a groovy hit, set this variable to false so we don't double count their groove.
			_lastHitGroovy = false;
			return damage;
		}

	}
}
