using System.Collections.Generic;
using ThunderRoad;
using UnityEngine;

namespace ForgingHunt
{
    public class Manager : ThunderScript
    { 
        public static Manager local;
        private List<ItemData> meltables = new List<ItemData>();
        public override void ScriptLoaded(ModManager.ModData modData)
        {
            base.ScriptLoaded(modData);

            if (local == null)
            {
                local = this;
            }

            Item.OnItemSpawn += ItemSpawnEvent;
        }

        /**
         * Subscribe to Item Spawn event to dynamically determine if an item can be melted down.
         */
        private void ItemSpawnEvent(Item obj)
        {
            if (obj.data.category.Equals("Valuables"))
            {
                if (!meltables.Contains(obj.data))
                {
                    meltables.Add(obj.data);
                    Debug.Log(obj.name + " has been spawned and added!");
                }
            }
        }
    }
}