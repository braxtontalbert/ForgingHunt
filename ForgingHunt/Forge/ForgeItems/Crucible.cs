using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ForgingHunt.Forge.Exceptions;
using ThunderRoad;
using UnityEngine;

namespace ForgingHunt.Forge.ForgeItems
{
    public enum MetalTypes
    {
        LowQuality,
        HighQuality,
        FireCrystal,
        LightningCrystal,
        GravityCrystal,
        BodyCrystal,
        MindCrystal
    }
    public class Crucible : MonoBehaviour
    { 
        public Item Item { get; set; }
        public int MaxMetalCount { get; set; }
        public int MinMetalCount { get; set; }
        Dictionary<Metal.Metal, int> CurrentMetalMixtureRatio { get; set; }

        public void Setup(Item item, int maxMetalCount, int minMetalCount)
        {
            Item = item;
            MaxMetalCount = maxMetalCount;
            MinMetalCount = minMetalCount;
        }

        public virtual void AddMetal(MetalTypes type)
        {
        }

        public virtual int GenerateMixtureHardness()
        {
            //determine if carnage reborn is sufficient and implement api for sword deformation.
            return 0;
        }

        public virtual List<string> GeneratePropertiesOfMixture()
        {
            //implement when mixture is determined for abilities
            return new List<string>();
        }

        public IEnumerator Melt()
        {
            var ex = HandleCountExceptions();
            if (ex != null) throw ex;
            
            int totalTimeToMelt = CurrentMetalMixtureRatio.Max(p => p.Key.MeltTime);
            
            //allow melt in update
            //sudo code here
            
            yield return new WaitForSeconds(totalTimeToMelt);
            
            //stop melt process in update
            //sudo code here
        }

        MetalException HandleCountExceptions()
        {
            if (CurrentMetalMixtureRatio.Count < MinMetalCount) return new MetalException("Metal count does not meet minimum metal node requirements.");
            if(CurrentMetalMixtureRatio.Count > MaxMetalCount) return new MetalException("Metal count exceeds maximum metal node requirements.");
            if (CurrentMetalMixtureRatio.Count == 0) return new MetalException("Metal count is zero. No metal is in the crucible.");
            return null;
        }
        private void Update()
        {
            //run code to do a shader and deform metal nodes
        }
    }
}