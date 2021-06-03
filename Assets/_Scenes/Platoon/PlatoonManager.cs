using System;
using UnityEngine;

namespace Assets.Scenes.Platoon.Controller
{
    public class PlatoonManager : MonoBehaviour
    {
        private GameObject m_canvas;

        private Assets.Objects.UI.Title m_title;
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
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Objects.UI.Title>();
            m_title.Initialize("편성", BackAction);
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