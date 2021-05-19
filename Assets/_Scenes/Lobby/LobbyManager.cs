using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scenes.Lobby.Controller;

namespace Assets.Scenes.Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        private Assets.Common.ResourceManager m_resourceManager;
        private GameObject m_canvas;

        private BackgroundController m_backgroundController;
        private UserMonitorController m_userMonitorController;
        private MenuController m_menuController;
        private AdController m_adController;      

        private void Awake()
        {
            m_resourceManager = null;
            m_canvas = null;

            m_backgroundController = null;
            m_userMonitorController = null;
            m_menuController = null;
            m_adController = null;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_resourceManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.ResourceManager>();
            m_canvas = GameObject.Find("Canvas");

            m_backgroundController = new BackgroundController();
            m_backgroundController.Initialize(m_resourceManager, m_canvas);
            m_userMonitorController = new UserMonitorController();
            m_userMonitorController.Initialize(m_resourceManager, m_canvas);
            m_menuController = new MenuController();
            m_menuController.Initialize(m_canvas);
            m_adController = new AdController();
            m_adController.Initialize(m_resourceManager, m_canvas);

            m_resourceManager.GetResourceContorller().StartCollectWorkResource();
        }

        // Update is called once per frame
        void Update()
        {
            m_userMonitorController.ApplyData();            
        }
    }
}
