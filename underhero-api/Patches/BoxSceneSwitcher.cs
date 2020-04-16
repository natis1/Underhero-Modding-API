using MonoMod;

namespace Modding.Patches
{
    [MonoModPatch("global::BoxSceneSwitcher")]
    public class BoxSceneSwitcher2 : BoxSceneSwitcher
    {
        [MonoModIgnore] private string SpecialSceneName;
        
        public string _SpecialSceneName
        {
            get => SpecialSceneName;
            set { SpecialSceneName = value; }
        }
    }
}