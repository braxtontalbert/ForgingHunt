using System.Collections.Generic;

namespace ForgingHunt.Forge.ForgeItems
{
    public class MixtureRatioValues
    {
        private int FireRatio;
        private int GravityRatio;
        private int LightningRatio;
        private int MetalRatio;

        public MixtureRatioValues(int fireRatio, int gravityRatio, int lightningRatio, int metalRatio)
        {
            FireRatio = fireRatio;
            GravityRatio = gravityRatio;
            LightningRatio = lightningRatio;
            MetalRatio = metalRatio;
        }

        public class Builder
        {
            private int fireRatio = 0;
            private int gravityRatio = 0;
            private int lightningRatio = 0;
            private int metalRatio = 0;

            public Builder WithFireRatio(int fireRation)
            {
                this.fireRatio = fireRatio;
                return this;
            }
            
            public Builder WithGravityRatio(int gravityRatio)
            {
                this.gravityRatio = gravityRatio;
                return this;
            }

            public Builder WithLightningRatio(int lightningRatio)
            {
                this.lightningRatio = lightningRatio;
                return this;
            }

            public Builder WithMetalRatio(int metalRatio)
            {
                this.metalRatio = metalRatio;
                return this;
            }

            public MixtureRatioValues Build()
            {
                return new MixtureRatioValues(fireRatio, gravityRatio, lightningRatio, metalRatio);
            }
        }
    }
}