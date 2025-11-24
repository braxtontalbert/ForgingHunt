using UnityEngine;

namespace ForgingHunt.Forge.ForgeItems.Metal
{
    public class Metal
    {
        public int MeltTime { get; set; }
        public MetalTypes MetalType { get; set; }

        public Metal(int meltTime, MetalTypes metalType)
        {
            MeltTime = meltTime;
            MetalType = metalType;
        }
    }
}