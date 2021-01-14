using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scene_Dormitory.Controller
{
    public class MenuController
    {
        private Assets.GameManager.GameManager m_gameManager;

        private Button m_buttonBack;

        public MenuController()
        {
            m_gameManager = null;

            m_buttonBack = null;
        }

        public void Initialize(Assets.GameManager.GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;

            var title = canvas.transform.Find("Title");
            m_buttonBack = title.Find("Back").GetComponent<Button>();

            var menu = canvas.transform.Find("Menu");

            ApplyAction();            
        }

        private void ApplyAction()
        {
            m_buttonBack.onClick.AddListener(Handle_Back);
        }

        private void Handle_Back()
        {
            SceneManager.LoadScene("Lobby");
        }        
    }
}
