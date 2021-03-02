using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Common;

namespace Assets.Scene_Platoon.Base
{
    public class SelectPlatoonBase
    {
        protected GameManager m_gameManager;
        protected Controller.PlatoonController m_platoonController;
        protected List<GameObject> m_list;

        private GameObject m_view;
        protected GameObject m_viewPortContent;
        protected GameObject m_album;        

        public SelectPlatoonBase()
        {
        }

        public void Initialize(Controller.PlatoonController platoonController, string viewName, string albumName)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            m_platoonController = platoonController;
            m_list = new List<GameObject>();
            var canvas = GameObject.Find("Canvas");
            var menuView = canvas.transform.Find("SelectPlatoon");
            m_view = menuView.Find(viewName).gameObject;
            var scrollView = m_view.transform.Find("ScrollView");
            var viewPort = scrollView.Find("Viewport");
            m_viewPortContent = viewPort.Find("Content").gameObject;
            m_album = UnityEngine.Resources.Load<GameObject>("Album/" + albumName);
        }

        public GameObject View()
        {
            return m_view;
        }
    }
}