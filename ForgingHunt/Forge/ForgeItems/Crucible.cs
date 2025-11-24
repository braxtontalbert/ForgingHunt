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

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<Item>() is Item item)
            {
                if (item.data.category.Equals(Manager.Valuables) || item.data.category.Equals(Manager.Crystals))
                {
                    AddMetal(item);
                }
            }
        }

        public virtual void AddMetal(Item item)
        {
            MetalTypes type = MetalTypes.LowQuality;
            if (item.data.category.Equals(Manager.Valuables))
            {
                if (item.data.value <= 50.0)
                {
                    type = MetalTypes.LowQuality;
                }
                else type = MetalTypes.HighQuality;
            }
            else if (item.data.category.Equals(Manager.Crystals))
            {
                switch (item.data.displayName.ToLower())
                {
                    case string s when s.Contains("fire"):
                        type = MetalTypes.FireCrystal;
                        break;
                    case string s when s.Contains("lightning"):
                        type = MetalTypes.LightningCrystal;
                        break;
                    case string s when s.Contains("gravity"):
                        type = MetalTypes.GravityCrystal;
                        break;
                    case string s when s.Contains("body"):
                        type = MetalTypes.BodyCrystal;
                        break;
                    case string s when s.Contains("mind"):
                        type = MetalTypes.MindCrystal;
                        break;
                    default:
                        type = MetalTypes.LowQuality;
                        break;
                }
            }

            Metal.Metal metal = new Metal.Metal((int) item.data.value / 2, type);
            
            if(!CurrentMetalMixtureRatio.ContainsKey(metal)) CurrentMetalMixtureRatio.Add(metal, 1);
            else  CurrentMetalMixtureRatio[metal]++;
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

            int totalTimeToMelt = CurrentMetalMixtureRatio.Max(p => p.Key.MeltTime) / CurrentMetalMixtureRatio.Count;
            
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