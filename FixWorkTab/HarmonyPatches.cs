using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace FixWorkTab
{

    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            //Log.Message("Hello from Harmony in scope: com.github.harmony.rimworld.maarx.fixworktab");
            var harmony = new Harmony("com.github.harmony.rimworld.maarx.fixworktab");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
    public class HarmonyPatches
    {
        [HarmonyPatch(typeof(LordToil_Siege))]
        [HarmonyPatch("SetAsBuilder")]
        [HarmonyPatch(new Type[] { typeof(Pawn) })]
        class ThingLabel
        {
            static void Postfix(LordToilData_Siege __instance, Pawn p)
            {
                if (p.workSettings.GetPriority(WorkTypeDefOf.Construction) > 0)
                {
                    p.workSettings.SetPriority(DefDatabase<WorkTypeDef>.GetNamed("BasicWorker"), 1);
                }
            }
        }

    }
}
