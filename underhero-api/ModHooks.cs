using System;

namespace Modding
{
    public class ModHooks
    {
        private static ModHooks _instance;

        public static readonly int API_VERSION = 1;
        public static ModHooks Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModHooks();
                }

                return _instance;
            }
        }
        private static string GetModNameFromDelegate(Delegate del) => (del.Target as Mod)?.GetModNameSafe() ?? del.Method.DeclaringType?.Name;
        
        
        public delegate int PlayerHurtHook(int damage);
        private event PlayerHurtHook _playerHurtHook;

        public event PlayerHurtHook PlayerHurt
        {
            add
            {
                Logger.LogDebug($"[{GetModNameFromDelegate(value)}] Adding PlayerHurt");
                _playerHurtHook += value;
            }
            remove
            {
                Logger.LogDebug($"[{GetModNameFromDelegate(value)}] Removing PlayerHurt");
                _playerHurtHook -= value;
            }
        }

        internal int OnPlayerHurt(int damage)
        {
            if (_playerHurtHook == null) return damage;

            foreach (Delegate toInvoke in _playerHurtHook.GetInvocationList())
            {
                try
                {
                    damage = (int) toInvoke.DynamicInvoke(damage);
                }
                catch (Exception e)
                {
                    Logger.LogError($"[{GetModNameFromDelegate(toInvoke)}] Error running PlayerHurt\n{e}");
                }
            }

            return damage;
        }
        
        
        public delegate int GainXPHook(int xp);
        private event GainXPHook _gainXPHook;

        public event GainXPHook GainXP
        {
            add
            {
                Logger.LogDebug($"[{GetModNameFromDelegate(value)}] Adding GainXP");
                _gainXPHook += value;
            }
            remove
            {
                Logger.LogDebug($"[{GetModNameFromDelegate(value)}] Removing GainXP");
                _gainXPHook -= value;
            }
        }

        internal int OnGainXP(int xp)
        {
            if (_gainXPHook == null) return xp;

            foreach (Delegate toInvoke in _gainXPHook.GetInvocationList())
            {
                try
                {
                    xp = (int) toInvoke.DynamicInvoke(xp);
                }
                catch (Exception e)
                {
                    Logger.LogError($"[{GetModNameFromDelegate(toInvoke)}] Error running PlayerHurt\n{e}");
                }
            }

            return xp;
        }
        
        
        public delegate int EnemyDamageHook(int damage);
        private event EnemyDamageHook _enemyDamageHook;

        public event EnemyDamageHook EnemyDamage
        {
            add
            {
                Logger.LogDebug($"[{GetModNameFromDelegate(value)}] Adding EnemyDamage");
                _enemyDamageHook += value;
            }
            remove
            {
                Logger.LogDebug($"[{GetModNameFromDelegate(value)}] Removing EnemyDamage");
                _enemyDamageHook -= value;
            }
        }

        internal int OnEnemyDamage(int damage)
        {
            if (_enemyDamageHook == null) return damage;

            foreach (Delegate toInvoke in _enemyDamageHook.GetInvocationList())
            {
                try
                {
                    damage = (int) toInvoke.DynamicInvoke(damage);
                }
                catch (Exception e)
                {
                    Logger.LogError($"[{GetModNameFromDelegate(toInvoke)}] Error running EnemyDamage\n{e}");
                }
            }

            return damage;
        }
    }
}