using System;
using Vintagestory.API;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.Client;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using Vintagestory.API.Config;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MouflonsHardcoreMod
{
    public class Core : ModSystem
    {
        ICoreAPI api;
        List<string> lesblocs = new List<string> { "packeddirt", "aridpackeddirt", "etc" };
        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            this.api = api;
            this.api.RegisterBlockBehaviorClass("JumpRestriction", typeof(JumpRestriction));

            this.api.World.Logger.Event("started 'Les Mouflons sont Hardcore' mod");
            this.api.World.Logger.StoryEvent(Lang.Get("Les Mouflons sont Hardcore...", Array.Empty<object>()));
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            base.StartClientSide(api);
            api.World.Logger.Event("started 'Les Mouflons sont Hardcore' mod");
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            base.StartServerSide(api);
            api.World.Logger.Event("started 'Les Mouflons sont Hardcore' mod");
        }
        
        public override void AssetsFinalize(ICoreAPI api)
        {
            foreach (var block in api.World.Blocks)
            {
                
                if (block.BlockMaterial.ToString() == "Soil")
                {
                    //MessageBox.Show(block.Code.GetName());
                    block.BlockBehaviors = block.BlockBehaviors.Append(new JumpRestriction(block));
                }
            }
        }
    }
}
