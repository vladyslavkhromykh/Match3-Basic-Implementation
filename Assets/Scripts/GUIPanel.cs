using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match3
{
    public sealed class GUIPanel : MonoBehaviour
    {
        [SerializeField]
        private Button newGame;

        private void Awake()
        {
            newGame.onClick.AddListener(OnNewGameButtonClicked);
        }

        private void OnNewGameButtonClicked()
        {
            EventManager.RaiseNewGameRequest();
        }
    }
}