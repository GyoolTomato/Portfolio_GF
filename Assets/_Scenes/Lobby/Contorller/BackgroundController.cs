using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Lobby.Controller
{
    public class BackgroundController
    {
        private RectTransform m_background;


        public BackgroundController()
        {
        }

        public void Initialize(GameObject canvas)
        {
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
