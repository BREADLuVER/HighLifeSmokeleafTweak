using Verse;
using UnityEngine;

namespace HighLifeSmokeleafTweak
{
    // Handles saving/loading the slider value
    public class HighLifeSettings : ModSettings
    {
        // How much of the lost consciousness to restore (0 = none, 1 = full 100%)
        public float restorePercent = 0.99f;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref restorePercent, "restorePercent", 0.99f);
            base.ExposeData();
        }
    }

    // Draws the settings window and provides global access to the settings instance
    public class HighLifeSmokeleafTweakMod : Mod
    {
        public static HighLifeSettings Settings;

        public HighLifeSmokeleafTweakMod(ModContentPack content) : base(content)
        {
            Settings = GetSettings<HighLifeSettings>();
        }

        public override string SettingsCategory() => "HighLife Smokeleaf Tweak";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);

            listing.Label("Percent of lost consciousness to restore:".Translate());
            Settings.restorePercent = listing.Slider(Settings.restorePercent, 0f, 1f);
            listing.GapLine();
            listing.Label($"Current: {Settings.restorePercent:P0}");

            listing.End();
        }
    }
} 