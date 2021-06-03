using System;
using UnityEngine;
using Assets.Scenes.Dormitory.Controller;
using Assets.Objects.UI;

namespace Assets.Scenes.Dormitory
{
    public class DormitoryManager : MonoBehaviour
    {
        private Assets.Graphic.GraphicManager m_graphicManager;
        private GameObject m_canvas;

        private Title m_title;
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
            m_graphicManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Graphic.GraphicManager>();
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Title>();
            m_title.Initialize(m_graphicManager, "숙소", BackAction);
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

        private void BackAction()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        }
    }
}
