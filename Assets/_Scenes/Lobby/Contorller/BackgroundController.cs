using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Lobby.Controller
{
    public class BackgroundController
    {
        private Assets.Graphic.GraphicManager m_graphicManager;

        private RectTransform m_background;


        public BackgroundController()
        {
        }

        public void Initialize(Assets.Graphic.GraphicManager graphicManager, GameObject canvas)
        {
            m_graphicManager = graphicManager;

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
