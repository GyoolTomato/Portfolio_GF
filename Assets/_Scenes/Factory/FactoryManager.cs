using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scenes.Factory.Controller;

namespace Assets.Scenes.Factory
{
    public class FactoryManager : MonoBehaviour
    {
        private Assets.Common.ResourceManager m_resourceManager;
        private GameObject m_canvas;

        private Assets.Resources.Object.Title m_title;
        private MenuController m_menuController;
        private TicketResourceController m_ticketResourceController;
        private ProduceTDollController m_produceTDollController;
        private ProduceEquipmentController m_produceEquipmentController;

        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            m_resourceManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.ResourceManager>();
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
            m_title.Initialize(m_resourceManager, "공장", BackAction);
            m_menuController = new MenuController();
            m_menuController.Initialize(m_canvas);
            m_ticketResourceController = new TicketResourceController();
            m_ticketResourceController.Initialize(m_resourceManager, m_canvas);
            m_produceTDollController = new ProduceTDollController();
            m_produceTDollController.Initialize(m_resourceManager, m_ticketResourceController, "ProduceTDoll");
            m_produceEquipmentController = new ProduceEquipmentController();
            m_produceEquipmentController.Initialize(m_resourceManager, m_ticketResourceController, "ProduceEquipment");
        }

        // Update is called once per frame
        void Update()
        {
            //m_userMonitorController.ApplyData();
        }

        public ProduceTDollController ProduceTDollController
        {
            get
            {
                return m_produceTDollController;
            }
        }

        public ProduceEquipmentController ProduceEquipmentController
        {
            get
            {
                return m_produceEquipmentController;
            }
        }

        private void BackAction()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        }
    }
}
