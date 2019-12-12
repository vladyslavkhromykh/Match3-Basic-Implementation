using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3
{
    [CreateAssetMenu(order = 0, fileName = "Settings", menuName = "Custom/Settings")]
    public sealed class Settings : ScriptableObject
    {
        [Range(5, 10)]
        [SerializeField]
        private int boardSize;
        
        public int BoardSize
        {
            get { return boardSize; }
        }
        
        [SerializeField]
        private List<GemData> gemsData;

        public List<GemData> GemsData
        {
            get { return gemsData; }
        }

        /// <summary>
        /// Used for creating list of settings for each gem respectively for <see cref="GemType"/> types count.
        /// Set <see cref="gemsData"/> count to 0 via inspector, and it will be automatically created.
        /// </summary>
        private void OnValidate()
        {
            if (gemsData == null || gemsData.Count == 0)
            {
                GemType[] gemTypes = ((GemType[]) Enum.GetValues(typeof(GemType))).Except(new[] {GemType.None}).ToArray();

                gemsData = new List<GemData>(gemTypes.Length);
                foreach (var gemType in gemTypes)
                {
                    gemsData.Add(new GemData()
                    {
                        sprite = null,
                        type = gemType,
                        weight = 0.1f
                    });
                }
            }
        }
    }
}