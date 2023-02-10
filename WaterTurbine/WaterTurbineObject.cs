// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Core.Utils;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Simulation.WorldLayers;
    using Eco.Simulation.WorldLayers.Layers;
    using Eco.World;
    using Eco.World.Blocks;
    using System;
    using System.Collections.Generic;

    public partial class WaterTurbineItem : WorldObjectItem<WaterTurbineObject>
    {
        public override Type[] Blockers { get { return AllowWaterPlacement; } }             // This allows the WaterTurbine to be placed inside of water.
    }

    public partial class WaterTurbineObject : WorldObject
    {
        static WaterTurbineObject()
        {                                                                                   // Some blocks intentionally left empty for the purposes of water-movement.
            WorldObject.AddOccupancy<WaterTurbineObject>(new List<BlockOccupancy>(){

            new BlockOccupancy(new Vector3i(0, -2, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -2, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -2, 0), typeof(WaterWorldObjectBlock)),  //bottom block
            new BlockOccupancy(new Vector3i(0, -2, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -2, 2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -1, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -1, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -1, 0), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -1, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, -1, 2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 0, -2), typeof(WaterWorldObjectBlock)),				// Left block.
            new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WaterWorldObjectBlock),   Quaternion.Identity, BlockOccupancyType.CustomSurfaceAttachment),// Center block.
            new BlockOccupancy(new Vector3i(0, 0, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 0, 2), typeof(WaterWorldObjectBlock)),					// Right block.                 
            new BlockOccupancy(new Vector3i(0, 1, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 1, 2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 2, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 2, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WaterWorldObjectBlock)),				// Top block.
            new BlockOccupancy(new Vector3i(0, 2, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(0, 2, 2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -2, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -2, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -2, 0), typeof(WaterWorldObjectBlock)),  //bottom block
            new BlockOccupancy(new Vector3i(1, -2, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -2, 2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -1, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -1, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -1, 0), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -1, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, -1, 2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 0, -2), typeof(WaterWorldObjectBlock)),				// Left block.
            new BlockOccupancy(new Vector3i(1, 0, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WaterWorldObjectBlock)),                  // Center block.
            new BlockOccupancy(new Vector3i(1, 0, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 0, 2), typeof(WaterWorldObjectBlock)),					// Right block.                 
            new BlockOccupancy(new Vector3i(1, 1, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 1, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 1, 0), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 1, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 1, 2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 2, -2), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 2, -1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 2, 0), typeof(WaterWorldObjectBlock)),				// Top block.
            new BlockOccupancy(new Vector3i(1, 2, 1), typeof(WaterWorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 2, 2), typeof(WaterWorldObjectBlock)),
            });
        }
    }
}

