using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Lobby.Controller
{
    public class AdController
    {
        private Assets.Common.GameManager m_gameManager;

        public AdController()
        {
        }

        public void Initialize(Assets.Common.GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;
        }
    }
}
