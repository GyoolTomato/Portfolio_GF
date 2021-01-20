using System;
using UnityEngine;
using Assets.Scene_Dormitory.Controller;

namespace Assets.Scene_Dormitory
{
    public class DormitoryManager : MonoBehaviour
    {
        private Assets.Project.GameManager m_gameManager;
        private GameObject m_canvas;

        private MenuController m_menuController;
        private ViewPort_TDollController m_viewPort_TDollController;
        private ViewPort_EquipmentsController m_viewPort_EquipmentsController;

        public DormitoryManager()
        {

        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Project.GameManager>();
            m_canvas = GameObject.Find("Canvas");

            m_menuController = new Controller.MenuController();
            m_menuController.Initialize(m_gameManager, m_canvas);
            m_viewPort_TDollController = new ViewPort_TDollController();
            m_viewPort_TDollController.Initialize(m_gameManager);
            m_viewPort_EquipmentsController = new ViewPort_EquipmentsController();

            m_viewPort_TDollController.Load();
        }

        private void Update()
        {

        }


    }
}
