using Il2CppAlta.Liquid;
using MelonLoader;
using UnityEngine;

using hydrateordierate;
using CookingLib;   

[assembly: MelonInfo(typeof(MoreHydrated.Core), "More Hydrated", "1.0.3", "TheRavenSeb", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace MoreHydrated
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            CookingLib.Main.Setup += Setup;
            CookingLib.Main.PostSetup += RegisterThirst;
        }

        static void RegisterThirst()
        {
            foreach (LibLiquid item in Liquids.All)
            {
                if (item.Error != null || !item.Spec.Thirst.HasValue)
                    continue;
                HydrateApi.RegisterLiquidThirst(item.Definition, item.Spec.Thirst.Value, null, true);
            }
        }




        // blue berry float(0.275, 0.255, 0.588)
        static void Setup()
        {
            Liquids.RegisterServerOnly(new LiquidSpec
            {
                Id = "MoreHydrated.BoiledWater",
                Look = "Water Liquid Visual Data",
                Color = new Color(0.655f, 0.741f, 0.827f,0.72f),
                Thirst = 90f
            });

            Liquids.RegisterServerOnly(new LiquidSpec
            {
                Id = "MoreHydrated.BlueBerryTea",
                Look = "Water Liquid Visual Data",
                Color = new Color(0.275f, 0.255f, 0.588f,0.72f),
                Thirst = 50f,
                Effects = { new EffectSpec { Effect = "Nourish", Strength = 0.05f } }
            });

            Liquids.RegisterServerOnly(new LiquidSpec
            {
                Id = "MoreHydrated.Coffee",
                Look = "Water Liquid Visual Data",
                Color = new Color(0.275f, 0.255f, 0.588f, 0.72f),
                Thirst = -5f,
                Effects = { new EffectSpec { Effect = "Speed Indirect Effect", Strength = 0.2f } }
            });

            Liquids.RegisterServerOnly(new LiquidSpec
            {
                Id = "MoreHydrated.BoneBroth",
                Look = "Water Liquid Visual Data",
                Color = new Color(0.890f, 0.855f, 0.788f, 0.678f),
                Thirst = 100f,
                Effects = { new EffectSpec { Effect = "Nourish", Strength = 1.0f } }
            });





            Liquids.RegisterServerOnly(new LiquidSpec
            {
                Id = "MoreHydrated.MonsterEnergy",
                Look = "Water Liquid Visual Data",
                Color = new Color(0.894f, 0.941f, 0.561f,0.25f),
                Thirst = 70f,
                Effects = { new EffectSpec { Effect = "Speed Indirect Effect", Strength = 0.3f } }
            });

            Infusions.Register(new InfusionSpec
            {
                Id = "MoreHydrated.BoiledWaterInfusion",
                Item = "SandstoneStone",
                OutputLiquid = "MoreHydrated.BoiledWater"
            });

            Infusions.Register(new InfusionSpec
            {
                Id = "MoreHydrated.MonsterEnergyInfusion",
                Item = "WalnutTreeSeed",
                OutputLiquid = "MoreHydrated.MonsterEnergy"
            });

            Infusions.Register(new InfusionSpec
            {
                Id = "MoreHydrated.BlueBerryTeaInfusion",
                Item = "BlueberryFullRipe",
                OutputLiquid = "MoreHydrated.BlueBerryTea"
            });

            

            Infusions.Register(new InfusionSpec
            {
                Id = "MoreHydrated.BoneBrothInfusion",
                Item = "BabuLegBone",
                OutputLiquid = "MoreHydrated.BoneBroth"
            });






        }

    }
}