using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Lobby.Controller
{
    public class AdController
    {
        private Assets.Project.GameManager m_gameManager;

        public AdController()
        {
        }

        public void Initialize(Assets.Project.GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;
        }
    }
}
