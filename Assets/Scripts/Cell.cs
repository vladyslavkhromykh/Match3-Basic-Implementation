using System;
using UnityEngine;

namespace Match3
{
    public class Cell
    {
        private GemType type;

        public GemType Type
        {
            get { return type; }
        }
        
        public Cell(GemType gemType)
        {
            if (gemType == GemType.None)
            {
                throw new ArgumentException(string.Format("Cell should not be initialized with {0}.", GemType.None));
            }
            
            this.type = gemType;
        }

        public void Clear()
        {
            this.type = GemType.None;
        }
    }
}