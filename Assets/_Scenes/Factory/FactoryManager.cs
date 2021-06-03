using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scenes.Factory.Controller;

namespace Assets.Scenes.Factory
{
    public class FactoryManager : MonoBehaviour
    {
        private Assets.Graphic.GraphicManager m_graphicManager;
        private GameObject m_canvas;

        private Assets.Objects.UI.Title m_title;
        private MenuController m_menuController;
        private TicketResourceController m_ticketResourceController;
        private ProduceTDollController m_produceTDollController;
        private ProduceEquipmentController m_produceEquipmentController;
        private SpawnPopupController m_spawnPopupController;

        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            m_graphicManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Graphic.GraphicManager>();
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Objects.UI.Title>();
            m_title.Initialize("공장", BackAction);
            m_menuController = new MenuController();
            m_menuController.Initialize(m_canvas);
            m_ticketResourceController = new TicketResourceController();
            m_ticketResourceController.Initialize(m_graphicManager, m_canvas);
            m_produceTDollController = new ProduceTDollController();
            m_produceTDollController.Initialize(this, m_ticketResourceController, "ProduceTDoll");
            m_produceEquipmentController = new ProduceEquipmentController();
            m_produceEquipmentController.Initialize(this, m_ticketResourceController, "ProduceEquipment");
            m_spawnPopupController = new SpawnPopupController();
            m_spawnPopupController.Initialize(this);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public ProduceTDollController GetProduceTDollController() => m_produceTDollController;
        public ProduceEquipmentController GetProduceEquipmentController() => m_produceEquipmentController;
        public SpawnPopupController GetSpawnPopupController() => m_spawnPopupController;

        private void BackAction()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        }
    }
}
