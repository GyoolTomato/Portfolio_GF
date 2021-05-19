using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Lobby.Controller
{
    public class BackgroundController
    {
        private Assets.Common.ResourceManager m_resourceManager;

        private RectTransform m_background;


        public BackgroundController()
        {
        }

        public void Initialize(Assets.Common.ResourceManager resourceManager, GameObject canvas)
        {
            m_resourceManager = resourceManager;

            ApplayImage(canvas);
        }

        public void ApplayImage(GameObject canvas)
        {
            m_background = canvas.transform.Find("Background").GetComponent<RectTransform>();

            m_background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
            m_background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
        }
    }
}
