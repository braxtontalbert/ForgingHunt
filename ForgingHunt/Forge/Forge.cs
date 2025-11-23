using System;
using System.Collections.Generic;
using ForgingHunt.Forge.ForgeItems;
using ThunderRoad;
using UnityEngine;

namespace ForgingHunt.Forge
{
    public class Forge : MonoBehaviour
    {
        private Item forgeItem;
        List<CrucibleRack> crucibleRacks = new List<CrucibleRack>();

        private void Start()
        {
            forgeItem = GetComponent<Item>();
            var rack1 = forgeItem.GetCustomReference("Rack1");
            var rack2 = forgeItem.GetCustomReference("Rack2");
            var rack3 = forgeItem.GetCustomReference("Rack3");
            
            crucibleRacks.Add(rack1.gameObject.AddComponent<CrucibleRack>());
            crucibleRacks.Add(rack2.gameObject.AddComponent<CrucibleRack>());
            crucibleRacks.Add(rack3.gameObject.AddComponent<CrucibleRack>());
        }
        
    }
}