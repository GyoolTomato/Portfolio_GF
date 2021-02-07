using System;
using UnityEngine;
using Assets.Scene_Dormitory.Controller;

namespace Assets.Scene_Dormitory
{
    public class DormitoryManager : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private GameObject m_canvas;

        private Assets.Common.Object.Title m_title;
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
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.GameManager>();
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Common.Object.Title>();
            m_title.Initialize(m_gameManager, "숙소");
            m_menuController = new Controller.MenuController();
            m_menuController.Initialize(m_canvas);
            m_viewPort_TDollController = new ViewPort_TDollController();
            m_viewPort_TDollController.Initialize("TDoll", "Album_TDoll");
            m_viewPort_EquipmentsController = new ViewPort_EquipmentsController();
            m_viewPort_EquipmentsController.Initialize("Equipment", "Album_Equipment");

            m_viewPort_TDollController.Load();
            m_viewPort_EquipmentsController.Load();
        }

        private void Update()
        {

        }
    }
}
