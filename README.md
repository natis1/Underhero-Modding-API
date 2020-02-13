# Preface

An Underhero Modding API and modloader built with the help of https://github.com/0x0ade/MonoMod. This program makes it easy to mod the game Underhero, and has a number of useful features including forwards compatibility with newer versions of the game, the ability to install many mods at once all together, and built in hooks to simplify the development process.

Much of the work behind this api was made possible by [Seanpr96](https://github.com/seanpr96). This modding api was built using much code from his Salt and Sanctuary and Hollow Knight modding apis, and his guidance helped bring this api to life.

# Getting the API

A binary version of this API can be downloaded HERE (TBD)

# Building the API from scratch

0. Download and install Underhero
1. Clone this repository
2. Go to your Underhero installation folder and copy the contents of Underhero_Data/Managed into a folder named Vanilla inside this repository clone

### Windows:

3. Open the solution in Visual Studio 2017
4. Set the build configuration to debug and click build

### Linux:

3. Install msbuild from your repository
4. Run `msbuild underhero-api.sln`

---

5. Copy the Assembly-CSharp.dll file from the Output folder into the Underhero_Data/Managed folder, overwriting the existing Assembly-CSharp.dll file
6. Run the game, if you see on the main menu the modding api in the top right corner, you successfully built it.
