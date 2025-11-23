using ThunderRoad;
using UnityEngine;

namespace ForgingHunt.Forge.ForgeItems.Metal
{
    public class MetalModule : ItemModule
    {
        private int meltTime;
        private MetalTypes metalType;

        public override void OnItemLoaded(Item item)
        {
            base.OnItemLoaded(item);
            item.gameObject.AddComponent<Metal>().Setup(meltTime, metalType);
        }
    }
}