using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Lobby.Controller
{
    public class AdController
    {
        private GameManager m_gameManager;

        public AdController()
        {
        }

        public void Initialize(GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;
        }
    }
}
