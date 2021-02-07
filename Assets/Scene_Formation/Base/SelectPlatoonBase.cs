using System;
using UnityEngine;
using Assets.Common;

namespace Assets.Scene_Formation.Base
{
    public class SelectPlatoonBase
    {
        private GameObject m_view;
        protected GameObject m_viewPortContent;
        protected GameObject m_album;

        protected GameManager m_gameManager;

        public SelectPlatoonBase()
        {
        }

        public void Initialize(string viewName, string albumName)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            var canvas = GameObject.Find("Canvas");
            m_view = canvas.transform.Find("SelectPlatoon").gameObject;
            var view = m_view.transform.Find(viewName);
            var scrollView = view.Find("ScrollView");
            var viewPort = scrollView.Find("Viewport");
            m_viewPortContent = viewPort.Find("Content").gameObject;
            m_album = UnityEngine.Resources.Load<GameObject>("Object/" + albumName);
        }

        public GameObject View()
        {
            return m_view;
        }
    }
}