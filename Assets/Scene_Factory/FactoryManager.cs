using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scene_Factory.Controller;

namespace Assets.Scene_Factory
{
    public class FactoryManager : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private GameObject m_canvas;

        private MenuController m_menuController;
        private ProduceTDollController m_produceTDollController;
        private ProduceEquipmentController m_produceEquipmentController;

        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.GameManager>();
            m_canvas = GameObject.Find("Canvas");

            m_menuController = new MenuController();
            m_menuController.Initialize(m_gameManager, m_canvas);
            m_produceTDollController = new ProduceTDollController();
            m_produceTDollController.Initialize(m_gameManager);
            m_produceEquipmentController = new ProduceEquipmentController();
            m_produceEquipmentController.Initialize();
        }

        // Update is called once per frame
        void Update()
        {

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
    }
}
