using System;
using UnityEngine;

namespace Assets.Scene_Platoon.Controller
{
    public class PlatoonManager : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private GameObject m_canvas;

        private Assets.Resources.Object.Title m_title;
        private MenuController m_menuController;
        private PlatoonController m_platoonController;

        public PlatoonManager()
        {
        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.GameManager>();
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
            m_title.Initialize(m_gameManager, "편성", BackAction);
            m_menuController = new MenuController();
            m_menuController.Initialize(m_canvas);
            m_platoonController = new PlatoonController();
            m_platoonController.Initialize(m_canvas);
        }

        private void Update()
        {

        }

        private void BackAction()
        {
            if (m_platoonController.IsOpen())
            {
                m_platoonController.CloseDormitory();
            }
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        }
    }
}