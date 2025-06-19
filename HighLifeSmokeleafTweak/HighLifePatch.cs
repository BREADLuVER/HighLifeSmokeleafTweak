using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Verse;
using RimWorld;

namespace HighLifeSmokeleafTweak
{
    [StaticConstructorOnStartup]
    public static class HighLifePatch
    {
        static HighLifePatch()
        {
            var harmony = new Harmony("yourname.highlife.smokeleaftweak");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(PawnCapacityUtility), nameof(PawnCapacityUtility.CalculateCapacityLevel))]
    public static class Patch_CalculateCapacityLevel
    {
        static void Postfix(HediffSet diffSet, PawnCapacityDef capacity, bool forTradePrice, ref float __result)
        {
            Pawn pawn = diffSet.pawn;

            if (pawn != null && capacity == PawnCapacityDefOf.Consciousness)
            {
                HediffDef smokeleafHigh = DefDatabase<HediffDef>.GetNamed("SmokeleafHigh");
                bool hasSmokeleaf = pawn.health.hediffSet.HasHediff(smokeleafHigh);

                if (hasSmokeleaf && pawn.Ideo?.HasMeme(DefDatabase<MemeDef>.GetNamed("HighLife")) == true)
                {
                    float boost = (1f - __result) * 0.99f;
                    __result += boost;

                    Log.Message($"[HighLifeSmokeleafTweak] Consciousness patch applied to {pawn.NameShortColored}. New value: {__result}");
                }
            }
        }
    }



}
