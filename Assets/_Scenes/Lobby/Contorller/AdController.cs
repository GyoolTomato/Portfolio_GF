using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Lobby.Controller
{
    public class AdController
    {
        private Assets.Graphic.GraphicManager m_graphicManager;

        public AdController()
        {
        }

        public void Initialize(Assets.Graphic.GraphicManager graphicManager, GameObject canvas)
        {
            m_graphicManager = graphicManager;
        }
    }
}
