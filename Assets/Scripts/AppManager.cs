using System;
using System.Collections;
using System.Collections.Generic;
using Match3;
using UnityEngine;

namespace Match3
{
    public sealed class AppManager : MonoBehaviour
    {
        [SerializeField]
        private Settings settings;

        [SerializeField] private RectTransform gameplayCanvas;

        [SerializeField]
        private BoardController boardControllerPrefab;
        
        private BoardController boardController;
        
        private void Awake()
        {
            EventManager.NewGameRequest += OnNewGameRequest;
        }

        private void OnNewGameRequest()
        {
            if (this.boardController != null)
            {
                this.boardController.Dispose();
            }
            this.boardController = Instantiate<BoardController>(boardControllerPrefab);
            this.boardController.transform.SetParent(gameplayCanvas, false);
        }
    }
}