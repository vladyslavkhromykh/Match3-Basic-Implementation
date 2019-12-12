using UnityEngine;
using UnityEngine.UI;

namespace Match3.View
{
    public sealed class CellView : MonoBehaviour
    {
        [SerializeField]
        private Image gemIcon;

        public void SetIcon(Sprite sprite)
        {
            gemIcon.sprite = sprite;
        }
    }
}
