using System;
using MonoMod;

namespace Modding.Patches.Staging
{
    [MonoModPatch("global::DemoProgScr")]
    public class DemoProgScr2 : DemoProgScr
    {
        private void orig_Start() { }
        private void Start()
        {
            orig_Start();
            string FullText = TextStorage.Instance.GetString("Intro Prologue Text");
            string[] pages = FullText.Split(new[] {"<pg>"}, StringSplitOptions.None);
            for (int i = 0; i < Sliders.Count; i++)
            {
                var slides = Sliders[i];
                string[] page = pages[i].Split(new []{"<nl>"}, StringSplitOptions.None);
                for (int j = 0; j < slides.Texters.Count; j++)
                {
                    var text = slides.Texters[j];
                    text.TextLines = page[j].Split(new[] {"<br>"}, StringSplitOptions.None);
                }
            }
        }
    }
}