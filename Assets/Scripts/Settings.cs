using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3
{
    [CreateAssetMenu(order = 0, fileName = "Settings", menuName = "Custom/Settings")]
    public sealed class Settings : ScriptableObject
    {
        [SerializeField]
        public List<GemData> gemsData;

        /// <summary>
        /// Used for creating list of settings for each gem respectively for <see cref="GemType"/> types count.
        /// Set <see cref="gemsData"/> count to 0 via inspector, and it will be automatically created.
        /// </summary>
        private void OnValidate()
        {
            if (gemsData == null || gemsData.Count == 0)
            {
                GemType[] gemTypes = (GemType[]) Enum.GetValues(typeof(GemType));
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