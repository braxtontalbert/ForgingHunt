using System.Collections.Generic;
using ThunderRoad;
using UnityEngine;

namespace ForgingHunt
{
    public class Manager : ThunderScript
    { 
        public static Manager local;
        public static string Valuables = "Valuables";
        public static string Crystals = "Crystals";
        public override void ScriptLoaded(ModManager.ModData modData)
        {
            base.ScriptLoaded(modData);

            if (local == null)
            {
                local = this;
            }
        }
    }
}