using UnityEngine;

namespace ForgingHunt.Forge.ForgeItems.Metal
{
    public class Metal : MonoBehaviour
    {
        public int MeltTime { get; set; }
        public MetalTypes MetalType { get; set; }

        public void Setup(int meltTime, MetalTypes metalType)
        {
            MeltTime = meltTime;
            MetalType = metalType;
        }
    }
}