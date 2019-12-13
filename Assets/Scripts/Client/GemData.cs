using System;
using UnityEngine;

namespace Match3
{
    [Serializable]
    public class GemData
    {
        public Sprite sprite;
        [Range(0.1f, 100.0f)]
        public float weight;

        public GemType type;
    }
}