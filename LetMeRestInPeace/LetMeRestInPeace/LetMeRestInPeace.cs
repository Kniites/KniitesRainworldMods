using System.Linq;
using BepInEx;

namespace LetMeRestInPeace
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class LetMeRestInPeace : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "kniites.letmerestinpeace";
        public const string PLUGIN_NAME = "Let me rest in peace";
        public const string PLUGIN_VERSION = "0.1.0";
        
        public void OnEnable()
        {
            Logger.LogInfo("Let me rest in peace - OnEnable");
            On.RainWorld.OnModsInit += OnModsInit;
        }

        public void OnModsInit(On.RainWorld.orig_OnModsInit origOnModsInit, RainWorld self)
        {
            Logger.LogInfo("OnModsInit");
            origOnModsInit(self);
            On.Menu.SleepAndDeathScreen.GetDataFromGame += (orig, screen, package) =>
            {
                orig(screen, package);
                if (screen.pages[0].subObjects.Exists(x => x is MoreSlugcats.CollectiblesTracker))
                {
                    var collectibleTracker = screen.pages[0].subObjects.FirstOrDefault(x => x is MoreSlugcats.CollectiblesTracker);
                    screen.pages[0].RemoveSubObject(collectibleTracker);
                }
            };
        }
    }
}