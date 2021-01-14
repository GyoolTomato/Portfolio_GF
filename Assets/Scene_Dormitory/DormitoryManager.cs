using System;
using UnityEngine;

namespace Assets.Scene_Dormitory
{
    public class DormitoryManager : MonoBehaviour
    {
        private Assets.GameManager.GameManager m_gameManager;
        private GameObject m_canvas;

        private Controller.MenuController m_menuController;

        public DormitoryManager()
        {

        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.GameManager.GameManager>();
            m_canvas = GameObject.Find("Canvas");

            m_menuController = new Controller.MenuController();
            m_menuController.Initialize(m_gameManager, m_canvas);
        }

        private void Update()
        {

        }


    }
}
