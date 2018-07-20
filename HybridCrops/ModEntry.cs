using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace HybridCrops
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod, IAssetEditor
    {
        public override void Entry(IModHelper helper)
        {
            SaveEvents.AfterLoad += this.SaveEvents_AfterLoad;
        }
        public bool CanEdit<T>(IAssetInfo asset)
        {

            if (asset.AssetNameEquals("Data/CraftingRecipes"))
            {
                return true;
            }

            return false;
        }
        private void SaveEvents_AfterLoad(object sender, EventArgs e){
            Game1.player.craftingRecipes.Add("Pumpkin Seeds", 0);
        }

        public void Edit<T>(IAssetData asset)
        {
            if (asset.AssetNameEquals("Data/CraftingRecipes"))
            {
                asset.AsDictionary<string, string>().Data.Add("Pumpkin Seeds", "276 1/Field/490 5/false/Foraging 1"); 
            }
        }
    }
}