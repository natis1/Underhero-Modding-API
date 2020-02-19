using System;
using System.Collections;
using Modding;
using UnityEngine;

namespace ExampleMod3
{
    // A MonoBehaviour can be declared like so:
    public class ModBehaviour : MonoBehaviour
    {
        private GUIStyle style;
        // What text should be drawn
        private string drawString;
        // What color the text should be
        private Color drawColor;
        // Are we currently drawing text
        private bool drawingText;

        // All monobehaviors have a number of builtin methods which can be used
        // for your convenience. They effectively act like hooks (see Example Mod 2) or events (EM1)
        // In that they run when something triggers them. Their naming is usually quite straightforward.
        // Also:
        // There are many of these that I won't cover, like Awake, OnApplicationPause, OnMouseDown, etc etc.
        // So check out https://docs.unity3d.com/ScriptReference/MonoBehaviour.html if you want to know
        // what all your options are and what triggers them.


        // Start runs whenever your MonoBehavior is activated or added to a game object.
        // It runs before any other methods and provides you with the ability to setup everything you will need
        // Including adding any hooks
        private void Start()
        {
            // Start usually has code setting all the needed variables
            drawString = "";
            drawColor = Color.white;
            
            // Both hooks and events can be placed in MonoBehaviors, just like they can in Mods
            // Be sure to check out Example mods 2 and 1 to understand how these work.
            On.Explore_Movement.PlayRandomJumpSound += Jump;
            ModHooks.Instance.PlayerHurt += Ouch;
            Modding.Logger.Log("Added hooks");
        }

        // On Destroy is the opposite of Start. If you added any hooks or events to start you should
        // remove them in this method.
        // if your MonoBehaviour creates any game objects you should destroy them here to save ram
        // basically this method is for cleaning up your mess
        private void OnDestroy()
        {
            // With MonoBehaviors, you need to be sure to remove the hooks and events you were using
            // Just use -= instead of += to remove these hooks and events
            On.Explore_Movement.PlayRandomJumpSound -= Jump;
            ModHooks.Instance.PlayerHurt -= Ouch;
        }

        private int Ouch(int damage)
        {
            if (!drawingText)
            {
                drawString = "oof";
                drawColor = Color.red;
                StartCoroutine(FadeOut(2f));
            }
            return damage;
        }


        private void Jump(On.Explore_Movement.orig_PlayRandomJumpSound orig, Explore_Movement self)
        {
            if (!drawingText)
            {
                drawString = "Boing";
                drawColor = Color.green;
                StartCoroutine(FadeOut(1f));
            }
            orig(self);
        }

        private float _timer = 0f;
        // Update runs every frame, even while paused
        private void Update()
        {
            // Time.deltaTime is the amount of time
            // since the last frame. It is useful for Update since Update runs once per frame
            // Note that deltaTime will report 0 if the game is paused, this can be super useful for
            // not having things run while paused.
            _timer -= Time.deltaTime;
            
            // Let's make it so pressing the L key while in game will cause some text to printout
            // Unity engine, among many other things, allows you to test which buttons are being pressed
            // which can be super useful for custom powers
            if (_timer < 0f && UnityEngine.Input.GetKeyDown(KeyCode.L) && !drawingText)
            {
                // Reset the timer so that this effect can only happen once every 4 seconds.
                _timer = 4f;
                drawString = "wow";
                drawColor = Color.white;
                
                // Calling an IEnumerator here lets us slowly fade out the color over time
                StartCoroutine(FadeOut(3f));
            }
        }

        // The IEnumerator from System.Collections allows us to create a "Coroutine"
        // A coroutine is a special kind of method. It runs normally, just like any other method
        // but it can be "paused" at any time for a single frame.
        // It resumes from where it was paused and not from the start, allowing you to essentially
        // run code slowly over time. This is super useful for say, animations, or damage over time
        // or a wide number of other things.

        private IEnumerator FadeOut(float fadeTime)
        {
            // Tell the other functions that we are drawing text right now
            drawingText = true;
            
            float startingTime = fadeTime;
            Color currentColor = drawColor;
            while (fadeTime > 0f)
            {
                // a is the alpha value of the color
                // it ranges from 0 to 1 and represents how soild our text is
                // 0 is totally transparent like a ghost while 1 is completely solid
                // This formula will cause the alpha to fade from 1 to 0 over time
                currentColor.a = fadeTime / startingTime;

                drawColor = currentColor;
                // This pauses the method for a single frame
                yield return null;
                // The paused method will resume from right here.
                // Get the time that passed while the method was paused.
                fadeTime -= Time.deltaTime;
            }
            // Finally once we are done let's make sure it has completely faded
            drawColor = Color.clear;
            drawingText = false;
        }

        private float _timer2 = 0f;
        // FixedUpdate runs every 0.02 seconds (by default). This is a fixed length of time that will
        // never change regardless of the game framerate. It may be useful to run certain things in here.
        // FixedUpdate also runs while the game is paused.
        private void FixedUpdate()
        {
            // Fixed delta time will report the time between fixed updates, this is by default 0.02 seconds,
            // but can be set to different values in the unity editor.
            // It will report 0 seconds while the game is paused. For paused time, use Time.fixedUnscaledDeltaTime
            _timer2 -= Time.fixedDeltaTime;

            if (_timer2 < 0f && UnityEngine.Input.GetKeyDown(KeyCode.M) && !drawingText)
            {
                // Only activate this effect every 2 seconds
                _timer2 = 4f;
                drawColor = Color.blue;
                drawString = "M key pressed!";
                // Calling an IEnumerator here lets us slowly fade out the color over time
                StartCoroutine(FadeOut(1f));

            }
        }

        // OnGUI runs every single frame that actually gets rendered. A frame may not be rendered for many reasons
        // the most common of which is that the game is alt-tabbed.
        private void OnGUI()
        {
            // First, make sure our style is loaded. this contains important information like the font used.
            if (style == null)
            {
                style = new GUIStyle(GUI.skin.label);
            }

            // A Matrix4x4 is a unity object that allows us to place images and text overlaying the game.
            Matrix4x4 matrix = GUI.matrix;
            
            // Set our text to the current color we have selected
            GUI.backgroundColor = Color.clear;
            GUI.contentColor = drawColor;
            GUI.color = drawColor;
            
            
            // This essentially creates a 1920x1080 pixel screen on which to draw the text
            // This will overlay the game screen.
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
                new Vector3(Screen.width / 1920f, Screen.height / 1080f, -1f));
            
            // We want our text to appear in the middle of the screen, some number of pixels down from the top.
            // This alignment centers our text for us
            style.alignment = TextAnchor.UpperCenter;
            style.fontSize = 32;
            
            // The first two numbers represent our x and y positions for the text since it is anchored to the upper middle
            // For the upper-middle of the screen we can set x to 0 and y to around 300 pixels. This is the number of pixels
            // from the upper middle to move right and then down respectively.
            GUI.Label(new Rect((float) 0f, 300f, 1920f, 1080f), drawString, style);
            GUI.matrix = matrix;
        }
        
        // BUT WAIT. i hear you cry. TEXT IS BORING
        // I WANT IMAGES
        // i hear you
        // i understand you
        // it's coming soon
    }
}