using System;
using UnityEngine;
using Assets.Common;

namespace Assets.Scene_Dormitory.Base
{
    public class DormitoryBase
    {
        protected GameObject m_viewPortContent;
        protected GameObject m_album;

        protected GameManager m_gameManager;

        public DormitoryBase()
        {
        }

        public void Initialize(string menuViewName, string albumName)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            var canvas = GameObject.Find("Canvas");
            var menuView = canvas.transform.Find("MenuView");
            var view = menuView.Find(menuViewName);
            var scrollView = view.Find("ScrollView");
            var viewPort = scrollView.Find("Viewport");
            m_viewPortContent = viewPort.Find("Content").gameObject;
            m_album = UnityEngine.Resources.Load<GameObject>("Album/" + albumName);
        }
    }
}