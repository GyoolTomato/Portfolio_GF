using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scenes.Lobby.Controller;

namespace Assets.Scenes.Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        private Assets.Graphic.GraphicManager m_graphicManager;
        private Common.WorkResource.WorkResourceManager m_workResourceManager;
        private GameObject m_canvas;

        private BackgroundController m_backgroundController;
        private UserMonitorController m_userMonitorController;
        private MenuController m_menuController;
        private AdController m_adController;      

        private void Awake()
        {
            m_graphicManager = null;
            m_canvas = null;

            m_backgroundController = null;
            m_userMonitorController = null;
            m_menuController = null;
            m_adController = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_graphicManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Graphic.GraphicManager>();
            m_workResourceManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.WorkResource.WorkResourceManager>();
            m_canvas = GameObject.Find("Canvas");

            m_backgroundController = new BackgroundController();
            m_backgroundController.Initialize(m_canvas);
            m_userMonitorController = new UserMonitorController();
            m_userMonitorController.Initialize(m_canvas);
            m_menuController = new MenuController();
            m_menuController.Initialize(m_canvas);
            m_adController = new AdController();
            m_adController.Initialize(m_canvas);

            m_workResourceManager.StartCollectWorkResource();
        }

        // Update is called once per frame
        void Update()
        {
            m_userMonitorController.ApplyData();            
        }
    }
}
