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

        }
        public bool CanEdit<T>(IAssetInfo asset)
        {

            if (asset.AssetNameEquals("Data/CraftingRecipes"))
            {
                return true;
            }

            return false;
        }

        public void Edit<T>(IAssetData asset)
        {
            if (asset.AssetNameEquals("Data/CraftingRecipes"))
            {
                asset.AsDictionary<string, string>().Data.Add("Pumpkin Seeds", "276 1/Field/490 5/false/Foraging 1");
                asset.AsDictionary<string, string>().Data.Add("SpringSeeds2", "16 1 18 1 20 1 22 1/Field/495 10/false/Foraging 1");
                this.Monitor.Log("Edit called, added Pumpkin Seeds entry:" + asset.AsDictionary<string, string>().Data["Pumpkin Seeds"]);
                foreach (KeyValuePair<string, string> entry in asset.AsDictionary<string, string>().Data)
                {
                    if (entry.Key.Contains("Seed"))
                    {
                        this.Monitor.Log(entry.Key + " " + entry.Value);
                    }
                }
            }
        }
    }
}