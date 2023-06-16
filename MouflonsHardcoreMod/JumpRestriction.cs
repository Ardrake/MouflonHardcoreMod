using System;
using Vintagestory.API;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using System.Windows;
using Vintagestory.API.Client;
using Vintagestory.API.Server;
using Vintagestory.GameContent;


namespace MouflonsHardcoreMod 
{
    public class JumpRestriction : BlockBehavior
    {
        public JumpRestriction(Block block) : base(block)
        {

        }

        public override bool TryPlaceBlock(IWorldAccessor world, IPlayer byPlayer, ItemStack itemstack, BlockSelection blockSel, ref EnumHandling handling, ref string failureCode)
         {
            handling = EnumHandling.PreventDefault;

            if (byPlayer.Entity.Controls.Jump)
             {
                failureCode = " Non Non faut pas sauter";
                return false;
            }

            return base.TryPlaceBlock(world, byPlayer, itemstack, blockSel, ref handling, ref failureCode);
        }
    }
}


