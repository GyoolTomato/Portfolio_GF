using System;
using UnityEngine;
using Assets.Graphic;

namespace Assets.Scenes.Dormitory.Base
{
    public class DormitoryBase
    {
        protected GameObject m_viewPortContent;
        protected GameObject m_album;

        protected GraphicManager m_graphicManager;
        protected DB.DbManager m_dbManager;

        public DormitoryBase()
        {
        }

        public void Initialize(string menuViewName, string albumName)
        {
            m_graphicManager = GameObject.Find("GameManager").GetComponent<GraphicManager>();
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();
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