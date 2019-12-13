using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Match3
{
    public class GemDistributionAlgorithm
    {
        private float sumOfWeights;
        private List<GemData> gemsData;

        public GemDistributionAlgorithm(Settings settings)
        {
            if (settings.GemsData == null || settings.GemsData.Count == 0)
            {
                throw new ArgumentException(
                    "Gems data is null or gems data count is zero. No data for fetch to distribute values for gems");
            }

            this.gemsData = settings.GemsData;

            foreach (var gemData in gemsData)
            {
                this.sumOfWeights += gemData.weight;
            }
        }
        
        public GemType GetNext()
        {
            float seed = GetRandomDistributionSeed();
            GemType type = LookupGemType(seed);
            return type;
        }
        
        private GemType LookupGemType(float seed)
        {
            float cumulativeWeight = 0.0f;
            foreach (var gemData in this.gemsData)
            {
                cumulativeWeight += gemData.weight;
                if (seed < cumulativeWeight)
                {
                    return gemData.type;
                }
            }

            return GemType.None;
        }

        private float GetRandomDistributionSeed()
        {
            return Random.Range(0.0f, this.sumOfWeights);
        }
    }
  
}
