using System;
using UnityEngine;

namespace Assets.Scenes.Combat
{
    public class CombatManager : MonoBehaviour
    {
        private GameObject m_canvas;

        private Assets.Objects.UI.Title m_title;
        //private MenuController m_menuController;

        public CombatManager()
        {
        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Objects.UI.Title>();
            m_title.Initialize("전투", BackAction);
            //m_menuController = new Controller.MenuController();
            //m_menuController.Initialize(m_gameManager, m_canvas);
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