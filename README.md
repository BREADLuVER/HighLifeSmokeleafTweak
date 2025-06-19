# HighLifeSmokeleafTweak

## Overview
High Life Smokeleaf Tweak is a tiny quality-of-life mod for RimWorld that softens the harsh **-30 % Consciousness** penalty applied by the *Smokeleaf high* hediff – but **only** for pawns whose Ideology contains the *High Life* meme.

With the tweak enabled your stoner colonists can keep working, fighting and surviving while enjoying their favourite herb.

You can customise how much of the debuff is restored via a handy slider in the in-game mod settings.

## What exactly does it do?
* Hooks into `PawnCapacityUtility.CalculateCapacityLevel` with a Harmony **Postfix**.
* When the game calculates the **Consciousness** capacity:
  * Checks if the pawn is currently *Smokeleaf high* **and** has the *High Life* meme.
  * If so, almost cancels the debuff by adding back 99 % of the lost value.

The result is that the normal –30 % hit becomes roughly –0.3 %, a virtually negligible impact that still allows other factors (injuries, diseases, etc.) to matter.

## Compatibility
* ✅ Safe to add to existing saves and to remove again (it does not touch saved data).
* ✅ Works with Ideology, Biotech, Anomaly and other DLCs.
* ✅ No XML patches, no Def edits – pure C# Harmony patch.
* ❌ Will not affect pawns without the High Life meme.

## RimWorld 1.6 update
* Re-compiled against RimWorld 1.6 assemblies.
* `About.xml` updated – the mod now advertises support for **1.5 and 1.6**.
* No code changes were required – the `PawnCapacityUtility` method signature is unchanged in 1.6.

## Building from source
1. Install **.NET Framework 4.8** developer pack (same version the game uses).
2. Open `HighLifeSmokeleafTweak/HighLifeSmokeleafTweak.csproj` in your IDE.
3. Adjust the `<HintPath>` references so they point at your RimWorld installation and Harmony DLL (or copy the DLLs into a `Libs` folder and reference them there).
4. Compile in **Release** mode – the assembly will be placed in `Assemblies/` ready to copy into your mod folder.

## Credits
* Powered by [Harmony](https://harmony.pardeike.net/).
* Created by *YourNameHere* – PRs and forks are welcome!

## License
This project is released under the MIT license. See `LICENSE` for details.