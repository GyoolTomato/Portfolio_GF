using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Lobby.Controller
{
    public class AdController
    {
        private Assets.Common.ResourceManager m_resourceManager;

        public AdController()
        {
        }

        public void Initialize(Assets.Common.ResourceManager resourceManager, GameObject canvas)
        {
            m_resourceManager = resourceManager;
        }
    }
}
