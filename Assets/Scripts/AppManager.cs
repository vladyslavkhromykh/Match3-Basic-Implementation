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
        
        private GameSession gameSession;
        
        private void Awake()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var session = new GameSession(settings);
            }
        }

        private void OnNewGameRequest()
        {
            
        }
    }
}