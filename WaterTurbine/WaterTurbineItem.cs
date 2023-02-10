﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from WorldObjectTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(WaterRiverGeneratorComponent))]
    [RequireComponent(typeof(StatusComponent))]
    [PowerGenerator(typeof(ElectricPower))]
    public partial class WaterTurbineObject : WorldObject, IRepresentsItem
    {
        [Serialized] public bool Spinning = true;
        public override LocString DisplayName { get { return Localizer.DoStr("Water Turbine"); } }
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public virtual Type RepresentedItemType { get { return typeof(WaterTurbineItem); } }

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<PowerGridComponent>().Initialize(30, new ElectricPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(2000);
            this.ModsPostInitialize();
        }

        public override void Tick()
        {
            base.Tick();
            SetAnimatedState("waterturbine", this.Operating && Spinning);
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Water Turbine")]
    [Ecopedia("Crafted Objects", "Power Generation", createAsSubPage: true)]
    public partial class WaterTurbineItem : WorldObjectItem<WaterTurbineObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Uses the power of flowing water to produce electrical power. Must be placed in fresh water and produces double power when placed in both a river and waterfall.");

        [TooltipChildren] public HomeFurnishingValue HousingTooltip { get { return HomeValue; } }
        public static readonly HomeFurnishingValue HomeValue = new HomeFurnishingValue()
        {
            Category = RoomCategory.Industrial,
            TypeForRoomLimit = Localizer.DoStr(""),
        };

        [Tooltip(8)] private LocString PowerProductionTooltip => Localizer.Do($"Produces: {Text.Info(1000)}w of {new ElectricPower().Name} power");
    }

    [RequiresSkill(typeof(MechanicsSkill), 6)]
    public partial class WaterTurbineRecipe : RecipeFamily
    {
        public WaterTurbineRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "WaterTurbine",  //noloc
                Localizer.DoStr("Water Turbine"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronPlateItem), 30, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    new IngredientElement(typeof(IronGearItem), 20, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    new IngredientElement(typeof(IronAxleItem), 2, true),
                    new IngredientElement("Lumber", 15, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<WaterTurbineItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 30;
            this.LaborInCalories = CreateLaborInCaloriesValue(800, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WaterTurbineRecipe), 12, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Water Turbine"), typeof(WaterTurbineRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
