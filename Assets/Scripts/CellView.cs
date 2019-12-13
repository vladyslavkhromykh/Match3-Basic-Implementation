using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Match3.View
{
    public sealed class CellView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image gemIcon;

        [SerializeField]
        private Image selectedMark;

        private Cell cell;
        
        public void UpdateView(Cell cell, Settings settings)
        {
            this.cell = cell;
            this.selectedMark.enabled = cell.IsSelected;
            this.gemIcon.enabled = this.cell.Type != GemType.None;
            if (this.cell.Type != GemType.None)
            {
                this.gemIcon.sprite = settings.GemsData.Single(data => data.type == this.cell.Type).sprite;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            EventManager.RaiseCellViewClicked((this.cell));
        }
    }
}
